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
    public class FlatRateStrategyTests
    {
        private readonly Mock<ICalcMethods> mockCalcMethods;
        private readonly Mock<IRepository<Calc>> mockCalcRepo;

        public FlatRateStrategyTests()
        {
            mockCalcMethods = new Mock<ICalcMethods>();
            mockCalcRepo = new Mock<IRepository<Calc>>();

            mockCalcMethods.Setup<FlatRate>(x => x.FlatRate).Returns(new FlatRate() { Tax = 0.175M });
        }

        [TestCase(10000, 1750)]
        public async Task Tax_Calculation_Returns_Expected_Tax_Value(decimal input, decimal expectedResult)
        {
            var flatRateCalc = new FlatRateStrategy(mockCalcMethods.Object, mockCalcRepo.Object);
            var result = await flatRateCalc.Calc(input, "7000", false);

            Assert.That(expectedResult, Is.EqualTo(result.TaxValue));
        }
    }
}
