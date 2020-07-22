using System;

namespace CarParkRateCalculator.Services
{
    public interface ISetRateType
    {
        RateRequestResponse RateCalculation(DateTime entryDateTime, DateTime exitDateTime);
    }
}