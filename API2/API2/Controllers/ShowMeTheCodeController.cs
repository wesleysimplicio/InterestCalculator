using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowMeTheCodeController : Controller
    {
        /// <summary>
        /// Retorna caminho do projeto
        /// </summary>
        /// <returns>URL do projeto que está no GitHub</returns>
        /// <response code="200">Retorna caminho do projeto no GitHub</response>
        [HttpGet("/showmethecode")]
        public IActionResult Index()
        {
            return Redirect("https://github.com/wesleysimplicio/InterestCalculator/");
        }
    }
}
