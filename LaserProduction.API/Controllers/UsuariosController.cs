using LaserProduction.API.Data;
using LaserProduction.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace LaserProduction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly DbConnectionService _dbService;

        public UsuariosController(DbConnectionService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            var lista = new List<UsuarioDto>();
            using (var connection = _dbService.CreateConnection())
            {
                connection.Open();
                string query = "SELECT id, nome, login, senha, perfil, ativo FROM usuarios";
                using (var cmd = new MySqlCommand(query, (MySqlConnection)connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new UsuarioDto
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nome = reader["nome"].ToString(),
                            Login = reader["login"].ToString(),
                            Senha = reader["senha"].ToString(),
                            Perfil = reader["perfil"].ToString(),
                            Ativo = Convert.ToInt32(reader["ativo"])
                        });
                    }
                }
            }
            return Ok(lista);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] UsuarioDto dto)
        {
            using (var connection = _dbService.CreateConnection())
            {
                connection.Open();
                string senhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha);
                string query = "INSERT INTO usuarios (nome, login, senha, perfil, ativo, data_cadastro) VALUES (@nome, @login, @senha, @perfil, @ativo, NOW())";
                using (var cmd = new MySqlCommand(query, (MySqlConnection)connection))
                {
                    cmd.Parameters.AddWithValue("@nome", dto.Nome);
                    cmd.Parameters.AddWithValue("@login", dto.Login);
                    cmd.Parameters.AddWithValue("@senha", senhaHash);
                    cmd.Parameters.AddWithValue("@perfil", dto.Perfil);
                    cmd.Parameters.AddWithValue("@ativo", dto.Ativo);
                    cmd.ExecuteNonQuery();
                }
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] UsuarioDto dto)
        {
            using (var connection = _dbService.CreateConnection())
            {
                connection.Open();
                string query = "UPDATE usuarios SET nome = @nome, login = @login, senha = @senha, perfil = @perfil WHERE id = @id";
                using (var cmd = new MySqlCommand(query, (MySqlConnection)connection))
                {
                    cmd.Parameters.AddWithValue("@nome", dto.Nome);
                    cmd.Parameters.AddWithValue("@login", dto.Login);
                    cmd.Parameters.AddWithValue("@senha", dto.Senha);
                    cmd.Parameters.AddWithValue("@perfil", dto.Perfil);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            using (var connection = _dbService.CreateConnection())
            {
                connection.Open();
                string query = "DELETE FROM usuarios WHERE id = @id";
                using (var cmd = new MySqlCommand(query, (MySqlConnection)connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            return Ok();
        }
    }
}