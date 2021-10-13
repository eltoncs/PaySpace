using PaySpace.Domain.Model;
using System.Threading.Tasks;

namespace PaySpaceApplication.Method.Strategies
{
    public interface ICalcMethod
    {
        public Task<Calc> Calc(decimal income, string postalCode, bool save = true);
    }
}
