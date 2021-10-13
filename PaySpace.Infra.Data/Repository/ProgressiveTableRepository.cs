using PaySpace.Domain.Model;
using PaySpace.Domain.Repository;
using System.Linq;

namespace PaySpace.Infra.Data.Repository
{
    public class ProgressiveTableRepository : Repository<ProgressiveTable, PaySpaceDbContext>, IProgressiveTableRepository
    {
        public ProgressiveTableRepository(PaySpaceDbContext context) : base(context)
        {
        }

        public ProgressiveTable Get(decimal income)
        {
            return this.context.Set<ProgressiveTable>().Where(
                p => income >= p.From && income <= p.To).FirstOrDefault();
        }
    }
}
