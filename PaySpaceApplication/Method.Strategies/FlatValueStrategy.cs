using Microsoft.Extensions.Configuration;
using PaySpace.Domain.Model;
using PaySpace.Domain.Repository;
using PaySpaceApplication.Models;
using System;
using System.Threading.Tasks;

namespace PaySpaceApplication.Method.Strategies
{
    public class FlatValueStrategy : IFlatValueStrategy
    {
        public readonly IConfiguration configuration;
        public readonly IRepository<Calc> calcRepository;

        public FlatValueStrategy(IConfiguration configuration, IRepository<Calc> calcRepository)
        {
            this.configuration = configuration;
            this.calcRepository = calcRepository;
        }

        public async Task<Calc> Calc(decimal income, string postalCode)
        {
            var flatValue = configuration.GetValue<CalcMethods>(nameof(CalcMethods)).FlatValue;
            decimal result = income <= flatValue.MaxValue ? flatValue.YearValue : flatValue.Tax * income;

            var calc = new Calc()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.UtcNow,
                Income = income,
                PostalCode = postalCode,
                TaxValue = result
            };

            return await calcRepository.Add(calc);
        }
    }
}
