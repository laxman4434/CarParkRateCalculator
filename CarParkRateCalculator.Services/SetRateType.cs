using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkRateCalculator.Services
{
    public class SetRateType : ISetRateType
    {
        private readonly IEnumerable<IRateCalculatorService> _rateCalculatorService;

        public SetRateType(IEnumerable<IRateCalculatorService> rateCalculatorService)
        {
            _rateCalculatorService = rateCalculatorService;
        }

        public RateRequestResponse RateCalculation(DateTime entryDateTime, DateTime exitDateTime)
        {
            IRateCalculatorService setRate = null;

            //Use reflection to get the list of all classes that implements IRateCalculatorService
            //var types = AppDomain.CurrentDomain.GetAssemblies()
            //            .SelectMany(s => s.GetTypes())
            //            .Where(p => typeof(IRateCalculatorService).IsAssignableFrom(p) && !p.IsInterface);

            //create interface and use Dependency Injection to populate all classes that implements interface

            foreach (var calc in _rateCalculatorService)
            {
                var result = calc.IsRateType(entryDateTime, exitDateTime);
                if (result)
                {
                    setRate = calc;
                    break;
                }
            }

            return setRate.CalculateRate(entryDateTime, exitDateTime);
        }

    }
}
