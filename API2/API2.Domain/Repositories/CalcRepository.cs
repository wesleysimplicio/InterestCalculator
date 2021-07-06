using API2.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
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
                var response = await _httpClient.GetAsync("http://localhost:52271/taxaJuros");
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }

                return double.Parse(result, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                string error = string.IsNullOrWhiteSpace(ex.Message) ? "Não foi possível buscar taxaJuros" : ex.Message;
                this._logger.LogError(ex, error);
                return 0;
            }
        }

        public void Dispose()
        {
        }
    }
}
