using System;
using System.Threading.Tasks;

namespace API2.Domain.Interfaces
{
    public interface ICalcRepository : IDisposable
    {
        Task<double> FindInterest();
    }
}
