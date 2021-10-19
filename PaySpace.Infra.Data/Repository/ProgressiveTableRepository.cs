using PaySpace.Domain.Model;
using PaySpace.Domain.Repository;
using System.Collections.Generic;
using System.Linq;

namespace PaySpace.Infra.Data.Repository
{
    public class ProgressiveTableRepository : Repository<ProgressiveTable, PaySpaceDbContext>, IProgressiveTableRepository
    {
        public ProgressiveTableRepository(PaySpaceDbContext context) : base(context)
        {
        }

        List<ProgressiveTable> IProgressiveTableRepository.GetAll()
        {
            return this.context.Set<ProgressiveTable>().OrderBy(x => x.From).ToList();
        }
    }
}
