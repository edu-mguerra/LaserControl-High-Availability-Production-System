using Microsoft.AspNetCore.Mvc;
using LaserProduction.API.Data;
using LaserProduction.Shared.DTOs;
using MySql.Data.MySqlClient;

namespace LaserProduction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametrosController : ControllerBase
    {
        private readonly DbConnectionService _dbService;

        public ParametrosController(DbConnectionService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("obter")]
        public IActionResult ObterParametros()
        {
            using (var connection = _dbService.CreateConnection())
            {
                connection.Open();
                string query = "SELECT porta_laser, prefixo_lote, caminho_backup FROM parametros LIMIT 1";

                using (var command = new MySqlCommand(query, (MySqlConnection)connection))
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return Ok(new ParametrosDto
                        {
                            PortaLaser = reader.IsDBNull(0) ? "COM1" : reader.GetString(0),
                            PrefixoLote = reader.IsDBNull(1) ? "LT-" : reader.GetString(1),
                            CaminhoBackup = reader.IsDBNull(2) ? "C:\\" : reader.GetString(2)
                        });
                    }
                }
            }
            return NotFound(new { mensagem = "Nenhum parâmetro encontrado no banco." });
        }

        [HttpPut("atualizar")]
        public IActionResult AtualizarParametros([FromBody] ParametrosDto request)
        {
            using (var connection = _dbService.CreateConnection())
            {
                connection.Open();
                string query = "UPDATE parametros SET porta_laser = @Porta, prefixo_lote = @Prefixo, caminho_backup = @Backup";

                using (var command = new MySqlCommand(query, (MySqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@Porta", request.PortaLaser);
                    command.Parameters.AddWithValue("@Prefixo", request.PrefixoLote);
                    command.Parameters.AddWithValue("@Backup", request.CaminhoBackup);

                    command.ExecuteNonQuery();
                    return Ok(new { mensagem = "Parâmetros atualizados com sucesso!" });
                }
            }
        }
    }
}