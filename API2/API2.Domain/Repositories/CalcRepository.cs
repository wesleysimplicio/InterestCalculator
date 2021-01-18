using API2.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace API2.Domain.Repositories
{
    public class CalcRepository : ICalcRepository
    {
        private readonly ILogger _logger;
        private static HttpClient _httpClient;

        public CalcRepository(ILogger<CalcRepository> logger)
        {
            _logger = logger;
        }

        public async Task<double> FindInterest()
        {
            try
            {
                string result = string.Empty;
                var _httpClient = new HttpClient();
                var response = await _httpClient.GetAsync("https://localhost:49199/taxaJuros");
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }

                return Double.Parse(result);
            }catch
            {
                //NÃO TRABALHEI COM DOCKER, NÃO CONSEGUI FAZER CONECTAR NO ENDPOINT DO CONTAINER DA API1
                return 0.01;
            }
        }

        public void Dispose()
        {
        }
    }
}
