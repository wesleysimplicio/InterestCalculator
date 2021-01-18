using System;
using System.Threading.Tasks;

namespace API2.Domain.Interfaces
{
    public interface ICalcBusiness : IDisposable
    {
        Task<string> Calculator(double valorinicial, int meses);
    }
}
