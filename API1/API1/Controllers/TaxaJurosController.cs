using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Controllers
{
    [ApiController]
    [Route("api1/[controller]")]
    public class TaxaJurosController : Controller
    {
        [HttpGet("taxaJuros")]
        public IActionResult Get()
        {
            double resul = 0.01;
            return Ok(resul);
        }
    }
}
