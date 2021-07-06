using API2.Domain.Interfaces;
using API2.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalcController : Controller
    {
        private readonly ICalcBusiness _calcBusiness;
        private readonly ILogger _logger;

        public CalcController(
          ICalcBusiness calcBusiness,
          ILogger<CalcController> logger
            )
        {
            _calcBusiness = calcBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Calculo de Juros
        /// </summary>
        /// <returns>Retorna o resultado da operação</returns>
        /// <param name="valorinicial">Valor decimal do campo Valor inicial</param>
        /// <param name="meses">Valor inteiro dos meses</param>
        /// <response code="200">Retorna o valor calculado do juros conforme parametros</response>
        /// <response code="400">Retorna erro caso não seja o que foi esperado</response>

        [HttpGet("/calculajuros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery] double valorinicial, [FromQuery] int meses)
        {
            try
            {
                var result = await _calcBusiness.Calculator(valorinicial, meses);
                return Ok(result);
            }
            catch (Exception ex)
            {
                string error = string.IsNullOrWhiteSpace(ex.Message) ? "Não foi possível realizar o cálculo" : ex.Message;
                this._logger.LogError(ex, error);
                return BadRequest(new ErrorItem(1, error));
            }
        }
    }
}
