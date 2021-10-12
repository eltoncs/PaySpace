using Microsoft.Extensions.Configuration;
using PaySpace.Domain.Model;
using PaySpace.Domain.Repository;
using PaySpaceApplication.Models;
using System;
using System.Threading.Tasks;

namespace PaySpaceApplication.Method.Strategies
{
    public class FlatRateStrategy : IFlatRateStrategy
    {
        public readonly IConfiguration configuration;
        public readonly IRepository<Calc> calcRepository;

        public FlatRateStrategy(IConfiguration configuration, IRepository<Calc> calcRepository)
        {
            this.configuration = configuration;
            this.calcRepository = calcRepository;
        }

        public async Task<Calc> Calc(decimal income, string postalCode)
        {
            var flatRate = configuration.GetValue<CalcMethods>(nameof(CalcMethods)).FlatRate;
            decimal result = income * flatRate.Tax;

            var calc = new Calc()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.UtcNow,
                Income = income,
                PostalCode = postalCode,
                TaxValue = result
            };

            return await this.calcRepository.Add(calc);
        }
    }
}
