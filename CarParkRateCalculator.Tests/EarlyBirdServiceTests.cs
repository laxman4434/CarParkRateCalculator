using CarParkRateCalculator.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CarParkRateCalculator.Tests
{
    [TestClass]
    public class EarlyBirdServiceTests
    {
        private EarlyBirdService earlyBirdService;

        [TestInitialize]
        public void Setup()
        {
            earlyBirdService = new EarlyBirdService();
        }

        [TestMethod]
        public void IsRateType_WhenEntryAndExitTimesAreInSpeciFiedTimes_ReturnTrue()
        {

            bool result = earlyBirdService.IsRateType(new DateTime(2020,07,17,08,30,25), new DateTime(2020, 07, 17, 16, 30, 25));

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void CalculateRate_WhenEntryAndExitTimesAreInSpeciFiedTimes_ReturnSpecifiedAmount()
        {

            var result = earlyBirdService.CalculateRate(new DateTime(2020, 07, 17, 08, 30, 25), new DateTime(2020, 07, 17, 16, 30, 25));

            Assert.AreEqual(13, result.FinalRate);

        }

        [TestMethod]
        public void IsRateType_WhenEntryTimeInSpeciFiedTimesButNotExitTime_ReturnFalse()
        {

            bool result = earlyBirdService.IsRateType(new DateTime(2020, 07, 17, 08, 30, 25), new DateTime(2020, 07, 17, 12, 30, 25));

            Assert.IsFalse(result);

        }


        [TestMethod]
        public void IsRateType_WhenExitTimeInSpeciFiedTimesButNotExitTime_ReturnFalse()
        {

            bool result = earlyBirdService.IsRateType(new DateTime(2020, 07, 17, 10, 30, 25), new DateTime(2020, 07, 17, 16, 30, 25));

            Assert.IsFalse(result);

        }

        [TestMethod]
        public void IsRateType_WhenEntryAndExitTimeIsWeekend_ReturnFalse()
        {

            bool result = earlyBirdService.IsRateType(new DateTime(2020, 07, 18, 10, 30, 25), new DateTime(2020, 07, 19, 16, 30, 25));

            Assert.IsFalse(result);

        }

        [TestMethod]
        public void IsRateType_WhenEntryTimeIsWeekendAndExitTimeIsWeekday_ReturnFalse()
        {

            bool result = earlyBirdService.IsRateType(new DateTime(2020, 07, 18, 10, 30, 25), new DateTime(2020, 07, 20, 16, 30, 25));

            Assert.IsFalse(result);

        }

        [TestMethod]
        public void IsRateType_WhenEntryTimeIsWeekdayAndExitTimeIsWeekEnd_ReturnFalse()
        {

            bool result = earlyBirdService.IsRateType(new DateTime(2020, 07, 17, 10, 30, 25), new DateTime(2020, 07, 18, 16, 30, 25));

            Assert.IsFalse(result);

        }
    }
}
