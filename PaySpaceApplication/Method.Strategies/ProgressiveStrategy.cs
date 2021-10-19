using PaySpace.Domain.Model;
using PaySpace.Domain.Repository;
using PaySpaceApplication.Exceptions;
using System;
using System.Threading.Tasks;

namespace PaySpaceApplication.Method.Strategies
{
    public class ProgressiveStrategy : IProgressiveStrategy
    {
        public readonly IRepository<Calc> calcRepository;
        public readonly IProgressiveTableRepository progressiveTableRepository;

        public ProgressiveStrategy(
            IRepository<Calc> calcRepository,
            IProgressiveTableRepository progressiveTableRepository)
        {
            this.calcRepository = calcRepository;
            this.progressiveTableRepository = progressiveTableRepository;
        }

        public async Task<Calc> Calc(decimal income, string postalCode, bool save = true)
        {
            var progressiveTable = this.progressiveTableRepository.GetAll();

            if (progressiveTable == null || progressiveTable.Count == 0)
            {
                throw new CustomNotFoundException("Tax data for progressive calc not found");
            }

            decimal remainingIncome = income;
            decimal totalTax = 0;

            foreach(var taxItem in progressiveTable)
            {
                if (remainingIncome >= taxItem.To)
                {
                    totalTax += taxItem.Rate * taxItem.To;                    
                }
                else
                {
                    totalTax += taxItem.Rate * remainingIncome;
                }

                remainingIncome -= taxItem.To;

                if (remainingIncome <= 0)
                {
                    break;
                }
            }

            var calc = new Calc()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.UtcNow,
                Income = income,
                PostalCode = postalCode,
                TaxValue = totalTax
            };

            if (!save)
            {
                return calc;
            }

            return await this.calcRepository.Add(calc);
        }
    }
}
