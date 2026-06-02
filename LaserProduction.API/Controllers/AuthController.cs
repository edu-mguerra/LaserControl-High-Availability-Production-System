using Microsoft.AspNetCore.Mvc;
using LaserProduction.API.Data;
using LaserProduction.Shared.Models;
using LaserProduction.Shared.DTOs;
using MySql.Data.MySqlClient;


namespace LaserProduction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DbConnectionService _dbService;

        public AuthController(DbConnectionService dbService)
        {
            _dbService = dbService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto request)
        {
            using (var connection = _dbService.CreateConnection())
            {
                connection.Open();

                string query = "SELECT Id, Nome, Login, Senha, Perfil FROM usuarios WHERE login = @Login AND ativo = TRUE;";

                using (var command = new MySqlCommand(query, (MySqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@Login", request.Login);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string hashSalvoNoBanco = reader.GetString("Senha");

                            try
                            {
                                bool senhaValida = BCrypt.Net.BCrypt.Verify(request.Senha, hashSalvoNoBanco);

                                if (senhaValida)
                                {
                                    var usuario = new Usuario
                                    {
                                        Id = reader.GetInt32("Id"),
                                        Nome = reader.GetString("Nome"),
                                        Login = reader.GetString("Login"),
                                        Perfil = reader.GetString("Perfil")
                                    };
                                    return Ok(usuario);
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                }
            }

            return Unauthorized(new { mensagem = "Usuário ou senha inválidos." });
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromBody] NovoUsuarioDto request)
        {
            string senhaComHash = BCrypt.Net.BCrypt.HashPassword(request.Senha);

            using (var connection = _dbService.CreateConnection())
            {
                connection.Open();

                string query = "INSERT INTO usuarios (nome, login, senha, perfil) VALUES (@Nome, @Login, @Senha, @Perfil)";

                using (var command = new MySqlCommand(query, (MySqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@Nome", request.Nome);
                    command.Parameters.AddWithValue("@Login", request.Login);
                    command.Parameters.AddWithValue("@Senha", senhaComHash);
                    command.Parameters.AddWithValue("@Perfil", request.Perfil);

                    try
                    {
                        command.ExecuteNonQuery();
                        return Ok(new { mensagem = "Usuário cadastrado com sucesso!" });
                    }
                    catch (MySqlException ex) when (ex.Number == 1062)
                    {
                        return BadRequest(new { mensagem = "Esse login já existe no sistema." });
                    }
                }
            }
        }
    }


}