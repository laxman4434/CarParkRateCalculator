using System;
using System.Collections.Generic;
using System.Text;

namespace CarParkRateCalculator.Services
{
    public class WeekendRateService : IRateCalculatorService
    {
        public double CalculateRate(DateTime entryDateTime, DateTime exitdateTime)
        {
            return 10;
        }

        public bool IsRateType(DateTime entryDateTime, DateTime exitDateTime)
        {

            if (entryDateTime.DayOfWeek == DayOfWeek.Saturday || entryDateTime.DayOfWeek == DayOfWeek.Sunday)
            {
                return (exitDateTime.DayOfWeek == DayOfWeek.Saturday || exitDateTime.DayOfWeek == DayOfWeek.Sunday);
            }

            return false;
        }
    }
}
