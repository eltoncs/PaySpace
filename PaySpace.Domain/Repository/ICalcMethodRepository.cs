using PaySpace.Domain.Model;

namespace PaySpace.Domain.Repository
{
    public interface ICalcMethodRepository
    {
        public CalcMethod Get(string postalCode);
    }
}
