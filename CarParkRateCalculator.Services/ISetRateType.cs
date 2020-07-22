using System;

namespace CarParkRateCalculator.Services
{
    public interface ISetRateType
    {
        double RateCalculation(DateTime entryDateTime, DateTime exitDateTime);
    }
}