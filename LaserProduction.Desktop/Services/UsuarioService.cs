using LaserProduction.Shared.DTOs;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LaserProduction.Desktop.Services
{
    public class UsuarioService
    {
        private readonly HttpClient _httpClient;

        public UsuarioService()
        {
            _httpClient = new HttpClient { BaseAddress = new System.Uri("https://localhost:7075/api/") };
        }

        public async Task<List<UsuarioDto>> ObterTodosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<UsuarioDto>>("usuarios");
        }

        public async Task<bool> CriarAsync(UsuarioDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("usuarios", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> AtualizarAsync(UsuarioDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"usuarios/{dto.Id}", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"usuarios/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}