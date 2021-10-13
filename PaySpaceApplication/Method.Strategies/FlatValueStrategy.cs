using PaySpace.Domain.Model;
using PaySpace.Domain.Repository;
using PaySpaceApplication.Models;
using System;
using System.Threading.Tasks;

namespace PaySpaceApplication.Method.Strategies
{
    public class FlatValueStrategy : IFlatValueStrategy
    {
        public readonly ICalcMethods calcMethods;
        public readonly IRepository<Calc> calcRepository;

        public FlatValueStrategy(ICalcMethods calcMethods, IRepository<Calc> calcRepository)
        {
            this.calcMethods = calcMethods;
            this.calcRepository = calcRepository;
        }

        public async Task<Calc> Calc(decimal income, string postalCode, bool save = true)
        {
            var flatValue = calcMethods.FlatValue;
            decimal result = income >= flatValue.MaxValue ? flatValue.YearValue : flatValue.Tax * income;

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

            return await calcRepository.Add(calc);
        }
    }
}
