using API2.Domain.Business;
using API2.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace API2.Test
{
    [TestClass]
    public class CalcBusinessTest
    {
        [TestMethod]
        public void CalculatorTest()
        {
            var mockClientR = new Mock<ICalcRepository>();
            var juros = 0.01;
            CalcBusiness clientBusiness = new CalcBusiness(mockClientR.Object);
            mockClientR.Setup(p => p.FindInterest()).ReturnsAsync(juros);

            var result = clientBusiness.Calculator(100, 5);
            Assert.IsTrue(result.Result == "105,10");
        }
    }
}
