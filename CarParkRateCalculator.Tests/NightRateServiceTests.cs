using CarParkRateCalculator.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarParkRateCalculator.Tests
{
    [TestClass]
    public class NightRateServiceTests
    {
        private NightRateService _nightRateService;

        [TestInitialize]
        public void Setup()
        {
            _nightRateService = new NightRateService();
        }

        [TestMethod]
        public void IsRateType_WhenEntryAndExitTimesAreInSpeciFiedTimes_ReturnTrue()
        {

            bool result = _nightRateService.IsRateType(new DateTime(2020, 07, 16, 18, 30, 25), new DateTime(2020, 07, 16, 22, 30, 25));

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void CalculateRate_WhenEntryAndExitTimesAreInSpeciFiedTimes_ReturnCorrectAmount()
        {

            var result = _nightRateService.CalculateRate(new DateTime(2020, 07, 17, 19, 30, 25), new DateTime(2020, 07, 17, 21, 30, 25));

            Assert.AreEqual(6.5, result.FinalRate);

        }

        [TestMethod]
        public void IsRateType_WhenEntryTimeInSpeciFiedTimesButNotExitTime_ReturnFalse()
        {

            bool result = _nightRateService.IsRateType(new DateTime(2020, 07, 17, 19, 30, 25), new DateTime(2020, 07, 18, 02, 30, 25));

            Assert.IsFalse(result);

        }

        [TestMethod]
        public void IsRateType_WhenExitTimeInSpeciFiedTimesButNotEntryTime_ReturnFalse()
        {

            bool result = _nightRateService.IsRateType(new DateTime(2020, 07, 17, 16, 30, 25), new DateTime(2020, 07, 17, 22, 30, 25));

            Assert.IsFalse(result);

        }

    }
}
