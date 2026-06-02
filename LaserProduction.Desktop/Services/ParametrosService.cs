using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LaserProduction.Shared.DTOs;

namespace LaserProduction.Desktop.Services
{
    public class ParametrosService
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl = "https://localhost:7075/api/parametros";

        public ParametrosService()
        {
            _client = new HttpClient();
        }

        public async Task<ParametrosDto> ObterParametrosAsync()
        {
            var response = await _client.GetAsync($"{_baseUrl}/obter");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ParametrosDto>();
            }
            throw new Exception("Falha ao carregar os parâmetros.");
        }

        public async Task AtualizarParametrosAsync(ParametrosDto parametros)
        {
            var response = await _client.PutAsJsonAsync($"{_baseUrl}/atualizar", parametros);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Falha ao salvar as alterações.");
            }
        }
    }
}