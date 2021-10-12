using PaySpace.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaySpaceApplication.Services
{
    public interface ICalcServices
    {
        public Task<Calc> Calc(string postalCode, decimal income);
    }
}
