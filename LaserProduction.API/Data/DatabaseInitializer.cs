using LaserProduction.API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace LaserProduction.API.Data
{
    public static class DatabaseInitializer
    {
        public static void InitializeDatabase(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                var dbService = scope.ServiceProvider.GetRequiredService<DbConnectionService>();

                try
                {
                    string conexaoOriginal = config.GetConnectionString("MySqlConnection");

                    var builder = new MySqlConnectionStringBuilder(conexaoOriginal);
                    string nomeBanco = builder.Database;

                    builder.Database = "";
                    using (var serverConnection = new MySqlConnection(builder.ConnectionString))
                    {
                        serverConnection.Open();
                        using (var cmd = new MySqlCommand($"CREATE DATABASE IF NOT EXISTS `{nomeBanco}`;", serverConnection))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    using (var connection = dbService.CreateConnection())
                    {


                        connection.Open();

                        ExecuteCommand(@"
                        CREATE TABLE IF NOT EXISTS usuarios (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            nome VARCHAR(100) NOT NULL,
                            login VARCHAR(50) NOT NULL UNIQUE,
                            senha VARCHAR(255) NOT NULL,
                            perfil ENUM('COMUM', 'MASTER') DEFAULT 'COMUM',
                            ativo BOOLEAN DEFAULT TRUE,
                            data_cadastro DATETIME DEFAULT CURRENT_TIMESTAMP
                        );", connection);

                        ExecuteCommand(@"
                        CREATE TABLE IF NOT EXISTS parametros (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            porta_laser VARCHAR(10) NOT NULL,
                            prefixo_lote VARCHAR(20) NOT NULL,
                            caminho_backup VARCHAR(255) NOT NULL
                        );", connection);

                        ExecuteCommand(@"
                        CREATE TABLE IF NOT EXISTS maquinas (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            nome VARCHAR(50) NOT NULL,
                            ativa BOOLEAN DEFAULT TRUE
                        );", connection);

                        ExecuteCommand(@"
                        CREATE TABLE IF NOT EXISTS producoes (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            pedido VARCHAR(50) NOT NULL,
                            cliente VARCHAR(100) NOT NULL,
                            numero_tag VARCHAR(50) NOT NULL UNIQUE,
                            status ENUM('AGUARDANDO INÍCIO', 'EM ANDAMENTO', 'FINALIZADO') DEFAULT 'AGUARDANDO INÍCIO',
                            maquina_atual_id INT,
                            usuario_id INT,
                            data_registro DATETIME DEFAULT CURRENT_TIMESTAMP,
                            data_finalizacao DATETIME NULL,
                            FOREIGN KEY (maquina_atual_id) REFERENCES maquinas(id),
                            FOREIGN KEY (usuario_id) REFERENCES usuarios(id)
                        );", connection);

                        ExecuteCommand(@"
                        CREATE TABLE IF NOT EXISTS historico_transferencias (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            producao_id INT NOT NULL,
                            maquina_origem_id INT NOT NULL,
                            maquina_destino_id INT NOT NULL,
                            usuario_id INT NOT NULL,
                            data_transferencia DATETIME DEFAULT CURRENT_TIMESTAMP,
                            FOREIGN KEY (producao_id) REFERENCES producoes(id),
                            FOREIGN KEY (maquina_origem_id) REFERENCES maquinas(id),
                            FOREIGN KEY (maquina_destino_id) REFERENCES maquinas(id),
                            FOREIGN KEY (usuario_id) REFERENCES usuarios(id)
                        );", connection);

                        ExecuteCommand(@"
                        INSERT INTO usuarios (nome, login, senha, perfil) 
                        SELECT 'Administrador do Sistema', 'admin', '$2a$12$gxJbZRYsE5RNai33MOYSAuHzDC0U2nm.tTGkLi5DNFMLjIo/9n0Rm', 'MASTER'
                        WHERE NOT EXISTS (SELECT 1 FROM usuarios WHERE login = 'admin');", connection);

                        ExecuteCommand(@"
                        INSERT INTO parametros (porta_laser, prefixo_lote, caminho_backup)
                        SELECT 'COM1', 'LT-', 'C:\\Laser\\'
                        WHERE NOT EXISTS (SELECT 1 FROM parametros);", connection);

                        ExecuteCommand(@"
                        INSERT INTO maquinas (nome) SELECT 'Máquina Laser 01' WHERE NOT EXISTS (SELECT 1 FROM maquinas WHERE nome = 'Máquina Laser 01');
                        INSERT INTO maquinas (nome) SELECT 'Máquina Laser 02' WHERE NOT EXISTS (SELECT 1 FROM maquinas WHERE nome = 'Máquina Laser 02');
                        INSERT INTO maquinas (nome) SELECT 'Máquina Laser 03' WHERE NOT EXISTS (SELECT 1 FROM maquinas WHERE nome = 'Máquina Laser 03');", connection);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[AVISO] Falha ao inicializar estrutura do banco: {ex.Message}");
                }
            }
        }

        private static void ExecuteCommand(string query, IDbConnection connection)
        {
            using (var cmd = new MySqlCommand(query, (MySqlConnection)connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}