using PaySpace.Domain.Model;
using PaySpace.Domain.Repository;
using PaySpaceApplication.Models;
using System;
using System.Threading.Tasks;

namespace PaySpaceApplication.Method.Strategies
{
    public class FlatRateStrategy : IFlatRateStrategy
    {
        private readonly ICalcMethods calcMethods;
        private readonly IRepository<Calc> calcRepository;

        public FlatRateStrategy(ICalcMethods calcMethods, IRepository<Calc> calcRepository)
        {
            this.calcMethods = calcMethods;
            this.calcRepository = calcRepository;
        }

        public async Task<Calc> Calc(decimal income, string postalCode, bool save = true)
        {
            var flatRate = calcMethods.FlatRate;
            decimal result = income * flatRate.Tax;

            var calc = new Calc()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.UtcNow,
                Income = income,
                PostalCode = postalCode,
                TaxValue = result
            };

            if (!save)
            {
                return calc;
            }

            return await this.calcRepository.Add(calc);
        }
    }
}
