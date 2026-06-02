using Microsoft.AspNetCore.Mvc;
using LaserProduction.API.Data;
using LaserProduction.Shared.DTOs;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace LaserProduction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducaoController : ControllerBase
    {
        private readonly DbConnectionService _dbService;

        public ProducaoController(DbConnectionService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("listar")]
        public IActionResult ListarProducoes()
        {
            var producoes = new List<ProducaoDto>();

            using (var connection = _dbService.CreateConnection())
            {
                connection.Open();

                string query = @"
            SELECT p.id, p.pedido, p.cliente, p.numero_tag, p.status, p.data_registro, 
                   m.nome as maquina, 
                   u.nome as nome_usuario 
            FROM producoes p 
            LEFT JOIN maquinas m ON p.maquina_atual_id = m.id 
            LEFT JOIN usuarios u ON p.usuario_id = u.id 
            ORDER BY p.data_registro DESC";

                using (var command = new MySqlCommand(query, (MySqlConnection)connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        producoes.Add(new ProducaoDto
                        {
                            Id = reader.GetInt32("id"),
                            Pedido = reader.GetString("pedido"),
                            Cliente = reader.GetString("cliente"),
                            NumeroTag = reader.GetString("numero_tag"),
                            Status = reader.GetString("status"),
                            DataRegistro = reader.GetDateTime("data_registro"),
                            MaquinaAtual = reader.IsDBNull(reader.GetOrdinal("maquina")) ? "Sem Máquina" : reader.GetString("maquina"),
                            NomeUsuario = reader.IsDBNull(reader.GetOrdinal("nome_usuario")) ? "Sem Usuário" : reader.GetString("nome_usuario")
                        });
                    }
                }
            }
            return Ok(producoes);
        }

        [HttpPost("iniciar")]
        public IActionResult IniciarProducao([FromBody] NovaProducaoDto request)
        {
            using (var connection = _dbService.CreateConnection())
            {
                connection.Open();

                string query = @"
            INSERT INTO producoes (pedido, cliente, numero_tag, maquina_atual_id, usuario_id) 
            VALUES (@Pedido, @Cliente, @Tag, 
                   (SELECT id FROM maquinas WHERE nome = @Maquina LIMIT 1), 
                   @UsuarioId)";

                using (var command = new MySqlCommand(query, (MySqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@Pedido", request.Pedido);
                    command.Parameters.AddWithValue("@Cliente", request.Cliente);
                    command.Parameters.AddWithValue("@Tag", request.NumeroTag);
                    command.Parameters.AddWithValue("@Maquina", request.MaquinaAtual);
                    command.Parameters.AddWithValue("@UsuarioId", request.UsuarioId);

                    try
                    {
                        command.ExecuteNonQuery();
                        return Ok(new { mensagem = "Produção iniciada com sucesso!" });
                    }
                    catch (MySqlException ex) when (ex.Number == 1062)
                    {
                        return BadRequest(new { mensagem = "Já existe uma produção ativa com esta TAG." });
                    }
                }
            }
        }



        [HttpPost("gerar-proxima")]
        public IActionResult GerarProximaTag([FromBody] NovaProducaoDto request)
        {
            using (var connection = _dbService.CreateConnection())
            {
                connection.Open();

                string prefixo = "LT-";
                using (var cmdParam = new MySqlCommand("SELECT prefixo_lote FROM parametros LIMIT 1", (MySqlConnection)connection))
                {
                    var res = cmdParam.ExecuteScalar();
                    if (res != null) prefixo = res.ToString();
                }

                int maquinaId = 0;
                using (var cmdMachine = new MySqlCommand("SELECT id FROM maquinas WHERE nome = @Maquina LIMIT 1", (MySqlConnection)connection))
                {
                    cmdMachine.Parameters.AddWithValue("@Maquina", request.MaquinaAtual);
                    var machineResult = cmdMachine.ExecuteScalar();
                    if (machineResult != null)
                    {
                        maquinaId = Convert.ToInt32(machineResult);
                    }
                }

                if (maquinaId == 0)
                {
                    return BadRequest($"Máquina '{request.MaquinaAtual}' não encontrada no banco de dados. Verifique o cadastro.");
                }

                int proximoNumero = 1;
                string queryContagem = "SELECT COUNT(*) FROM producoes";
                using (var cmdCount = new MySqlCommand(queryContagem, (MySqlConnection)connection))
                {
                    proximoNumero = Convert.ToInt32(cmdCount.ExecuteScalar()) + 1;
                }

                string novaTag = $"{prefixo}{proximoNumero:D4}";

                string queryInsert = @"
            INSERT INTO producoes (pedido, cliente, numero_tag, status, maquina_atual_id, usuario_id) 
            VALUES (@Pedido, @Cliente, @Tag, 'EM ANDAMENTO', @MaquinaId, @UsuarioId);
            SELECT LAST_INSERT_ID();";

                using (var command = new MySqlCommand(queryInsert, (MySqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@Pedido", request.Pedido);
                    command.Parameters.AddWithValue("@Cliente", request.Cliente);
                    command.Parameters.AddWithValue("@Tag", novaTag);
                    command.Parameters.AddWithValue("@MaquinaId", maquinaId);
                    command.Parameters.AddWithValue("@UsuarioId", request.UsuarioId);

                    int idInserido = Convert.ToInt32(command.ExecuteScalar());

                    return Ok(new { id = idInserido, tag = novaTag });
                }
            }
        }


        [HttpPut("finalizar/{id}")]
        public IActionResult FinalizarTag(int id)
        {
            using (var connection = _dbService.CreateConnection())
            {
                connection.Open();
                string query = "UPDATE producoes SET status = 'FINALIZADO', data_finalizacao = CURRENT_TIMESTAMP WHERE id = @Id";
                using (var command = new MySqlCommand(query, (MySqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                    return Ok();
                }
            }
        }

        [HttpPut("regravar/{id}")]
        public IActionResult Regravar(int id)
        {
            try
            {
                using (var connection = _dbService.CreateConnection())
                {
                    connection.Open();

                    string query = @"
                UPDATE producoes 
                SET status = 'AGUARDANDO INÍCIO', 
                    data_finalizacao = NULL 
                WHERE id = @id";

                    using (var command = new MySqlCommand(query, (MySqlConnection)connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        int linhasAfetadas = command.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            return Ok(new { mensagem = "Regravação iniciada com sucesso" });
                        }

                        return NotFound(new { erro = "Produção não encontrada" });
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = ex.Message });
            }
        }


        [HttpPut("transferir/{tag}/{idMaquina}")]
        public IActionResult Transferir(string tag, int idMaquina)
        {
            try
            {
                using (var connection = _dbService.CreateConnection())
                {
                    connection.Open();

                    string query = "UPDATE producoes SET maquina_atual_id = @idMaquina, status = 'AGUARDANDO INÍCIO' WHERE numero_tag = @tag";

                    using (var command = new MySqlCommand(query, (MySqlConnection)connection))
                    {
                        command.Parameters.AddWithValue("@idMaquina", idMaquina);
                        command.Parameters.AddWithValue("@tag", tag);

                        int linhasAfetadas = command.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            return Ok();
                        }

                        return NotFound("Nenhuma produção encontrada com esta TAG no banco de dados.");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

    }


}