using Microsoft.Extensions.Configuration;
using PaySpace.Domain.Model;
using PaySpace.Domain.Repository;
using PaySpaceApplication.Method.Strategies;
using System;
using System.Threading.Tasks;

namespace PaySpaceApplication.Services
{
    public class CalcService : ICalcServices
    {
        public readonly IProgressiveStrategy progressiveStrategy;
        public readonly IFlatRateStrategy flatRateStrategy;
        public readonly IFlatValueStrategy flatValueStrategy;

        public readonly ICalcMethodRepository calcMethodRepository;

        public CalcService(
            IProgressiveStrategy progressiveStrategy,
            IFlatRateStrategy flatRateStrategy,
            IFlatValueStrategy flatValueStrategy,
            ICalcMethodRepository calcMethodRepository)
        {
            this.progressiveStrategy = progressiveStrategy;
            this.flatRateStrategy = flatRateStrategy;
            this.flatValueStrategy = flatValueStrategy;
            this.calcMethodRepository = calcMethodRepository;
        }

        public async Task<Calc> Calc(string postalCode, decimal income)
        {
            ICalcMethod calcStrategy = this.GetCalcStrategy(postalCode);

            return await calcStrategy.Calc(income, postalCode);
        }

        private ICalcMethod GetCalcStrategy(string postalCode)
        {
            var calcMethod = calcMethodRepository.Get(postalCode);

            if (calcMethod == null)
            {
                throw new ApplicationException("Postal code not covered");
            }

            switch (calcMethod.Method)
            {
                case "Progressive":
                    return this.progressiveStrategy;
                case "FlatValue":
                    return this.flatValueStrategy;
                case "FlatRate":
                    return this.flatRateStrategy;
                default:
                    throw new ApplicationException("Calc method not covered by the application");
            }
        }
    }
}
