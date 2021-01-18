using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaJurosController : Controller
    {
        /// <summary>
        /// Retorna 0.01
        /// </summary>
        /// <returns>Valor 0.01</returns>
        /// <response code="200">Retorna 0.01</response>
        [HttpGet("/taxaJuros")]
        public IActionResult Get()
        {
            double resul = 0.01;
            return Ok(resul);
        }
    }
}
