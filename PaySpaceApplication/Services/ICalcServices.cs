using PaySpace.Domain.Model;
using System.Threading.Tasks;

namespace PaySpaceApplication.Services
{
    public interface ICalcServices
    {
        public Task<Calc> Calc(string postalCode, decimal income);
    }
}
