using CarParkRateCalculator.Services;
using NUnit.Framework;
using System;

namespace CarParkRateCalculator.Tests
{
    [TestFixture]
    public class EarlyBirdServiceTests
    {
        private EarlyBirdService _earlyBirdService;

        [SetUp]
        public void Setup()
        {
            _earlyBirdService = new EarlyBirdService();
        }

        [Test]
        public void IsRateType_WhenEntryAndExitTimesAreInSpeciFiedTimes_ReturnTrue()
        {

            bool result = _earlyBirdService.IsRateType(new DateTime(2020,07,17,08,30,25), new DateTime(2020, 07, 17, 16, 30, 25));

            Assert.That(result, Is.True);

        }

        [Test]
        public void CalculateRate_WhenEntryAndExitTimesAreInSpeciFiedTimes_ReturnSpecifiedAmount()
        {

            var result = _earlyBirdService.CalculateRate(new DateTime(2020, 07, 17, 08, 30, 25), new DateTime(2020, 07, 17, 16, 30, 25));

            Assert.AreEqual(13, result.FinalRate);

        }

        [Test]
        public void IsRateType_WhenEntryTimeInSpeciFiedTimesButNotExitTime_ReturnFalse()
        {

            bool result = _earlyBirdService.IsRateType(new DateTime(2020, 07, 17, 08, 30, 25), new DateTime(2020, 07, 17, 12, 30, 25));

            Assert.That(result==false);

        }


        [Test]
        public void IsRateType_WhenExitTimeInSpeciFiedTimesButNotExitTime_ReturnFalse()
        {

            bool result = _earlyBirdService.IsRateType(new DateTime(2020, 07, 17, 10, 30, 25), new DateTime(2020, 07, 17, 16, 30, 25));

            Assert.IsFalse(result);

        }

        [Test]
        public void IsRateType_WhenEntryAndExitTimeIsWeekend_ReturnFalse()
        {

            bool result = _earlyBirdService.IsRateType(new DateTime(2020, 07, 18, 10, 30, 25), new DateTime(2020, 07, 19, 16, 30, 25));

            Assert.IsFalse(result);

        }

        [Test]
        public void IsRateType_WhenEntryTimeIsWeekendAndExitTimeIsWeekday_ReturnFalse()
        {

            bool result = _earlyBirdService.IsRateType(new DateTime(2020, 07, 18, 10, 30, 25), new DateTime(2020, 07, 20, 16, 30, 25));

            Assert.IsFalse(result);

        }

        [Test]
        public void IsRateType_WhenEntryTimeIsWeekdayAndExitTimeIsWeekEnd_ReturnFalse()
        {

            bool result = _earlyBirdService.IsRateType(new DateTime(2020, 07, 17, 10, 30, 25), new DateTime(2020, 07, 18, 16, 30, 25));

            Assert.IsFalse(result);

        }
    }
}
