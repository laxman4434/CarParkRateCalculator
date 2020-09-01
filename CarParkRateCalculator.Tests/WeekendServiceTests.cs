using CarParkRateCalculator.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarParkRateCalculator.Tests
{
    [TestClass]
    public class WeekendServiceTests
    {
        private WeekendRateService _weekendRateService;

        [TestInitialize]
        public void Setup()
        {
            _weekendRateService = new WeekendRateService();
        }

        [TestMethod]
        public void IsRateType_WhenEntryAndExitTimesAreInSpeciFiedTimes_ReturnTrue()
        {

            bool result = _weekendRateService.IsRateType(new DateTime(2020, 07, 18, 18, 30, 25), new DateTime(2020, 07, 19, 22, 30, 25));

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void CalculateRate_WhenEntryAndExitTimesAreInSpeciFiedTimes_ReturnCorrectAmount()
        {

            var result = _weekendRateService.CalculateRate(new DateTime(2020, 07, 19, 19, 30, 25), new DateTime(2020, 07, 19, 21, 30, 25));

            Assert.AreEqual(10, result.FinalRate);

        }

        [TestMethod]
        public void IsRateType_WhenEntryAndExitTimeIsWeekend_ReturnTrue()
        {

            bool result = _weekendRateService.IsRateType(new DateTime(2020, 07, 18, 10, 30, 25), new DateTime(2020, 07, 19, 16, 30, 25));

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void IsRateType_WhenEntryTimeIsWeekendAndExitTimeIsWeekday_ReturnFalse()
        {

            bool result = _weekendRateService.IsRateType(new DateTime(2020, 07, 18, 10, 30, 25), new DateTime(2020, 07, 20, 16, 30, 25));

            Assert.IsFalse(result);

        }

        [TestMethod]
        public void IsRateType_WhenEntryTimeIsWeekdayAndExitTimeIsWeekEnd_ReturnFalse()
        {

            bool result = _weekendRateService.IsRateType(new DateTime(2020, 07, 17, 10, 30, 25), new DateTime(2020, 07, 18, 16, 30, 25));

            Assert.IsFalse(result);

        }
    }
}
