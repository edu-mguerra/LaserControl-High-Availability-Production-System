using LaserProduction.Shared.DTOs;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text.Json;

namespace LaserProduction.Desktop.Services
{
    public class DatabaseLocalService
    {
        private readonly string _connectionString;

        public DatabaseLocalService()
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "producao_offline.db");
            _connectionString = $"Data Source={dbPath}";

            InicializarBancoLocal();
        }

        private void InicializarBancoLocal()
        {
            using (var conexao = new SqliteConnection(_connectionString))
            {
                conexao.Open();

                string query = @"
            CREATE TABLE IF NOT EXISTS ProducaoOffline (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                DadosJson TEXT,
                DataRegistro TEXT
            );";
                using (var comando = new SqliteCommand(query, conexao)) { comando.ExecuteNonQuery(); }

            }
        }

        public void SalvarOffline(NovaProducaoDto dto, string tagGerada)
        {
            using (var conexao = new SqliteConnection(_connectionString))
            {
                conexao.Open();

                string json = JsonSerializer.Serialize(dto);
                string query = "INSERT INTO ProducaoOffline (DadosJson, DataRegistro) VALUES ($json, $data);";

                using (var comando = new SqliteCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("$json", json);
                    comando.Parameters.AddWithValue("$data", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<ProducaoOffline> ObterTodasProducoesOffline()
        {
            var lista = new List<ProducaoOffline>();
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT Id, DadosJson FROM ProducaoOffline"; 
                using (var cmd = new SqliteCommand(sql, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new ProducaoOffline
                        {
                            Id = reader.GetInt32(0),
                            Dados = JsonSerializer.Deserialize<NovaProducaoDto>(reader.GetString(1))
                        });
                    }
                }
            }
            return lista;
        }

        public void RemoverProducaoOffline(int id)
        {
            using (var connection = new SQLiteConnection("Data Source=producao_offline.db;Version=3;"))
            {
                connection.Open();
                string sql = "DELETE FROM producoes_offline WHERE id = @id";
                using (var cmd = new SQLiteCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public async Task SincronizarTudoAsync(ProducaoService apiService)
        {
            var pendentes = ObterTodasProducoesOffline();

            if (pendentes == null || pendentes.Count == 0) return;

            foreach (var item in pendentes)
            {
                try
                {
                    var resultado = await apiService.GerarProximaTagAsync(item.Dados);

                    if (resultado != null)
                    {
                        RemoverProducaoOffline(item.Id);
                    }
                }
                catch
                {
                    break;
                }
            }
        }


    }
}