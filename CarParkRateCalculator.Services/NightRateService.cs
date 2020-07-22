using System;
using System.Collections.Generic;
using System.Text;

namespace CarParkRateCalculator.Services
{
    public class NightRateService : IRateCalculatorService
    {
        public double CalculateRate(DateTime entryDateTime, DateTime exitDateTime)
        {
            return 6.5;
        }

        public bool IsRateType(DateTime entryDateTime, DateTime exitDateTime)
        {
            //This condition is not clear
            var startTime = new DateTime(entryDateTime.Year, entryDateTime.Month, entryDateTime.Day, 18, 0, 0);
            var exitTime = new DateTime(entryDateTime.Year, entryDateTime.Month, entryDateTime.Day, 15, 30, 0);

            if(entryDateTime.DayOfWeek != DayOfWeek.Saturday || entryDateTime.DayOfWeek != DayOfWeek.Sunday)
            {
                return ((entryDateTime >= startTime && entryDateTime <= startTime.AddHours(6)) && (exitDateTime >= exitTime && exitDateTime <= exitTime.AddHours(8)));
            }

            return false;
        }
    }
}
