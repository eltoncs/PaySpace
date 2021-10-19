using PaySpace.Domain.Model;
using System.Collections.Generic;

namespace PaySpace.Domain.Repository
{
    public interface IProgressiveTableRepository
    {
        List<ProgressiveTable> GetAll();
    }
}
