using Microsoft.Extensions.Configuration;

namespace PaySpaceApplication.Models
{
    public class CalcMethods : ICalcMethods
    {
        private readonly IConfiguration configuration;

        public CalcMethods()
        {
        }

        public CalcMethods(IConfiguration configuration)
        {
            this.configuration = configuration;
            var calcMethods = configuration.GetSection(nameof(CalcMethods)).Get<CalcMethods>();

            FlatValue = calcMethods.FlatValue;
            FlatRate = calcMethods.FlatRate;
        }

        public FlatValue FlatValue { get; set; }
        public FlatRate FlatRate { get; set; }
    }
}
