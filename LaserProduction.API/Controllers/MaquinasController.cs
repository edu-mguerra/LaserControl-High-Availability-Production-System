using Microsoft.AspNetCore.Mvc;
using LaserProduction.API.Data;
using LaserProduction.Shared.DTOs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace LaserProduction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinasController : ControllerBase
    {
        private readonly DbConnectionService _dbService;

        public MaquinasController(DbConnectionService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult ObterMaquinas()
        {
            try
            {
                var listaMaquinas = new List<MaquinaDto>();

                using (var connection = _dbService.CreateConnection())
                {
                    connection.Open();

                    string query = "SELECT id, nome FROM maquinas ORDER BY nome ASC";

                    using (var command = new MySqlCommand(query, (MySqlConnection)connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listaMaquinas.Add(new MaquinaDto
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Nome = reader["nome"].ToString()
                                });
                            }
                        }
                    }
                }

                return Ok(listaMaquinas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = ex.Message });
            }
        }
    }
}