using Moq;
using NUnit.Framework;
using PaySpace.Domain.Model;
using PaySpace.Domain.Repository;
using PaySpaceApplication.Method.Strategies;
using System.Threading.Tasks;

namespace PaySpace.Application.Test
{
    [TestFixture]
    public class ProgressiveStrategyTests
    {
        private readonly Mock<IRepository<Calc>> mockCalcRepo;
        private readonly Mock<IProgressiveTableRepository> mockProgressiveRepo;

        public ProgressiveStrategyTests()
        {
            mockCalcRepo = new Mock<IRepository<Calc>>();
            mockProgressiveRepo = new Mock<IProgressiveTableRepository>();

            SetupMocks();
        }

        [TestCase(8000, 800)]
        [TestCase(9000, 1350)]
        [TestCase(34000, 8500)]
        [TestCase(83000, 23240)]
        [TestCase(172000, 56760)]
        [TestCase(273000, 95550)]
        public async Task Tax_Calculation_Returns_Expected_Tax_Values(decimal input, decimal expectedResult)
        {
            var progressiveCalc = new ProgressiveStrategy(mockCalcRepo.Object, mockProgressiveRepo.Object);
            var result = await progressiveCalc.Calc(input, "7441", false);

            Assert.That(expectedResult, Is.EqualTo(result.TaxValue));
        }

        private void SetupMocks()
        {
            mockProgressiveRepo.Setup<ProgressiveTable>(
                x => x.Get(8000M)).Returns(new ProgressiveTable()
                {
                    From = 0M,
                    To = 8350M,
                    Rate = 0.1M
                }
            );

            mockProgressiveRepo.Setup<ProgressiveTable>(
                x => x.Get(9000M)).Returns(new ProgressiveTable()
                {
                    From = 8351M,
                    To = 33950M,
                    Rate = 0.15M
                }
            );

            mockProgressiveRepo.Setup<ProgressiveTable>(
                x => x.Get(34000M)).Returns(new ProgressiveTable()
                {
                    From = 33951M,
                    To = 82250M,
                    Rate = 0.25M
                }
            );

            mockProgressiveRepo.Setup<ProgressiveTable>(
                x => x.Get(83000M)).Returns(new ProgressiveTable()
                {
                    From = 82251M,
                    To = 171550M,
                    Rate = 0.28M
                }
            );

            mockProgressiveRepo.Setup<ProgressiveTable>(
                x => x.Get(172000M)).Returns(new ProgressiveTable()
                {
                    From = 171551M,
                    To = 372950M,
                    Rate = 0.33M
                }
            );

            mockProgressiveRepo.Setup<ProgressiveTable>(
                x => x.Get(273000M)).Returns(new ProgressiveTable()
                {
                    From = 372951M,
                    To = 99999999999999,
                    Rate = 0.35M
                }
            );
        }
    }
}
