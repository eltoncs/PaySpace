using Microsoft.Extensions.Configuration;
using PaySpace.Domain.Model;
using PaySpace.Domain.Repository;
using PaySpaceApplication.Exceptions;
using System;
using System.Threading.Tasks;

namespace PaySpaceApplication.Method.Strategies
{
    public class ProgressiveStrategy : IProgressiveStrategy
    {
        public readonly IConfiguration configuration;
        public readonly IRepository<Calc> calcRepository;
        public readonly IProgressiveTableRepository progressiveTableRepository;

        public ProgressiveStrategy(
            IConfiguration configuration, 
            IRepository<Calc> calcRepository,
            IProgressiveTableRepository progressiveTableRepository)
        {
            this.configuration = configuration;
            this.calcRepository = calcRepository;
            this.progressiveTableRepository = progressiveTableRepository;
        }

        public async Task<Calc> Calc(decimal income, string postalCode)
        {
            var progressiveTax = this.progressiveTableRepository.Get(income);

            if (progressiveTax == null)
            {
                throw new CustomNotFoundException("Tax range not found");
            }

            decimal result = progressiveTax.Rate * income;

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
