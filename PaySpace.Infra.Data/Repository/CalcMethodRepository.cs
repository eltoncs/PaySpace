using PaySpace.Domain.Model;
using PaySpace.Domain.Repository;
using System.Linq;

namespace PaySpace.Infra.Data.Repository
{
    public class CalcMethodRepository : Repository<CalcMethod, PaySpaceDbContext>, ICalcMethodRepository
    {
        public CalcMethodRepository(PaySpaceDbContext context) : base(context)
        {
        }

        public CalcMethod Get(string postalCode)
        {
            return this.context.Set<CalcMethod>().Where(c => c.PostalCode == postalCode).FirstOrDefault();
        }
    }
}
