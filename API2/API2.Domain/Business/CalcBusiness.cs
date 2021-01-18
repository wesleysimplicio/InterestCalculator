using API2.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace API2.Domain.Business
{
    public class CalcBusiness : ICalcBusiness
    {
        private readonly ICalcRepository _calcRepository;
        private readonly ILogger _logger;

        public CalcBusiness(
             ICalcRepository calcRepository,
            ILogger<CalcBusiness> logger
            )
        {
            _calcRepository = calcRepository;
            _logger = logger;
        }

        public async Task<string> Calculator(double valorinicial, int meses)
        {
            if (!(valorinicial > 0) && !(meses > 0)) throw new Exception("Parametros inválidos");

            var interest = await _calcRepository.FindInterest();
            var resulPotencial = Math.Pow((1 + interest), Convert.ToDouble(meses));
            var resul = valorinicial * resulPotencial;
            return resul.ToString("F");
        }

        public void Dispose()
        {
        }
    }

}
