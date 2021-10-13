using Moq;
using NUnit.Framework;
using PaySpace.Domain.Model;
using PaySpace.Domain.Repository;
using PaySpaceApplication.Method.Strategies;
using PaySpaceApplication.Models;
using System.Threading.Tasks;

namespace PaySpace.Application.Test
{
    [TestFixture]
    public class FlatValueStrategyTests
    {
        private readonly Mock<ICalcMethods> mockCalcMethods;
        private readonly Mock<IRepository<Calc>> mockCalcRepo;

        public FlatValueStrategyTests()
        {
            mockCalcMethods = new Mock<ICalcMethods>();
            mockCalcRepo = new Mock<IRepository<Calc>>();

            mockCalcMethods.Setup<FlatValue>(
                x => x.FlatValue).Returns(new FlatValue() 
                { 
                    Tax = 0.05M, 
                    MaxValue = 200000M,
                    YearValue = 10000M
                }
            );
        }

        [TestCase(100000, 5000)]
        public async Task When_Income_LowerThan_200000_Tax_Calculation_Returns_FivePercent_Tax_Value(decimal input, decimal expectedResult)
        {
            var flatRateCalc = new FlatValueStrategy(mockCalcMethods.Object, mockCalcRepo.Object);
            var result = await flatRateCalc.Calc(input, "A100", false);

            Assert.That(expectedResult, Is.EqualTo(result.TaxValue));
        }

        [TestCase(300000, 10000)]
        public async Task When_Income_HigherThan_200000_Tax_Calculation_Returns_Fixed_Tax_Value(decimal input, decimal expectedResult)
        {
            var flatRateCalc = new FlatValueStrategy(mockCalcMethods.Object, mockCalcRepo.Object);
            var result = await flatRateCalc.Calc(input, "A100", false);

            Assert.That(expectedResult, Is.EqualTo(result.TaxValue));
        }
    }
}
