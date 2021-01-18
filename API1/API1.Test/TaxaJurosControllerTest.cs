

using API1.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;

namespace API1.Test
{
    [TestClass]
    public class TaxaJurosControllerTest
    {
        [TestMethod]
        public void GetResul()
        {
            TaxaJurosController controller = new TaxaJurosController();

            var result = controller.Get() as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.IsTrue((double)result.Value == 0.01);
        }

 
    }
}
