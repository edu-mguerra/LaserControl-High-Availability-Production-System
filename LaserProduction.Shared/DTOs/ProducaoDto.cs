using System.Text.Json.Serialization; 
using System;

namespace LaserProduction.Shared.DTOs
{
    public class ProducaoDto
    {
        public int Id { get; set; }

        [JsonPropertyName("pedido")]
        public string Pedido { get; set; }

        [JsonPropertyName("cliente")]
        public string Cliente { get; set; }

        [JsonPropertyName("numero_tag")]
        public string NumeroTag { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("nome_usuario")]
        public string NomeUsuario { get; set; }

        [JsonPropertyName("maquina")]
        public string MaquinaAtual { get; set; }

        [JsonPropertyName("data_registro")]
        public DateTime DataRegistro { get; set; }
    }
}