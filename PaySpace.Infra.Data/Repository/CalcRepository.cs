using PaySpace.Domain.Model;

namespace PaySpace.Infra.Data.Repository
{
    public class CalcRepository : Repository<Calc, PaySpaceDbContext>
    {
        public CalcRepository(PaySpaceDbContext context) : base(context)
        {
        }
    }
}
