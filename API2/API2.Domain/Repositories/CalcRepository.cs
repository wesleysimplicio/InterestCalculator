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
        private static HttpClient HttpClient => _httpClient ?? (_httpClient = new HttpClient());

        public CalcRepository(ILogger<CalcRepository> logger)
        {
            _logger = logger;
        }

        public async Task<double> FindInterest()
        {
            string result = string.Empty;
             HttpResponseMessage response = await HttpClient.GetAsync(new Uri("https://localhost:49179/taxaJuros"));
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }

            return Double.Parse(result);
        }

        public void Dispose()
        {
        }
    }
}
