using PaySpace.Domain.Model;

namespace PaySpace.Domain.Repository
{
    public interface IProgressiveTableRepository
    {
        public ProgressiveTable Get(decimal income);
    }
}
