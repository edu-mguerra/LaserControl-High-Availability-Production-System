using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LaserProduction.Shared.DTOs;

namespace LaserProduction.Desktop.Services
{
    public class ProducaoService
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl = "https://localhost:7075/api/producao";

        public ProducaoService()
        {
            _client = new HttpClient();
        }

        public async Task<List<ProducaoDto>> ObterTodasAsync()
        {
            try
            {
                var response = await _client.GetAsync($"{_baseUrl}/listar");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<ProducaoDto>>() ?? new List<ProducaoDto>();
                }

                throw new Exception($"Erro da API: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                throw new Exception("Falha na comunicação com o servidor.\nDetalhes: " + ex.Message);
            }
        }

        public async Task IniciarProducaoAsync(NovaProducaoDto novaProducao)
        {
            try
            {
                var response = await _client.PostAsJsonAsync($"{_baseUrl}/iniciar", novaProducao);

                if (!response.IsSuccessStatusCode)
                {
                    var erro = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Erro da API: {erro}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao registrar produção.\nDetalhes: " + ex.Message);
            }
        }

        public async Task<dynamic> GerarProximaTagAsync(NovaProducaoDto dto)
        {
            var response = await _client.PostAsJsonAsync($"{_baseUrl}/gerar-proxima", dto);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<dynamic>();
            }

            var erroDetalhado = await response.Content.ReadAsStringAsync();
            throw new Exception($"API Erro: {erroDetalhado}");
        }

        public async Task FinalizarTagAsync(int id)
        {
            await _client.PutAsync($"{_baseUrl}/finalizar/{id}", null);
        }



        public async Task<bool> RegravarAsync(int idProducao)
        {
            try
            {
                var response = await _client.PutAsync($"{_baseUrl}/regravar/{idProducao}", null);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                string erroReal = await response.Content.ReadAsStringAsync();
                throw new Exception(erroReal);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro de Conexão: {ex.Message}");
            }
        }

        public async Task<List<MaquinaDto>> ObterMaquinasAtivasAsync()
        {
            try
            {
                string urlMaquinas = _baseUrl.Replace("/producao", "/maquinas");

                return await _client.GetFromJsonAsync<List<MaquinaDto>>(urlMaquinas);
            }
            catch
            {
                return null;
            }
        }

        public async Task<string> TransferirMaquinaAsync(string tag, int idNovaMaquina)
        {
            try
            {
                var response = await _client.PutAsync($"{_baseUrl}/transferir/{tag}/{idNovaMaquina}", null);

                if (response.IsSuccessStatusCode)
                {
                    return "OK";
                }

                return await response.Content.ReadAsStringAsync(); 
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
