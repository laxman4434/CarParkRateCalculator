using CarParkRateCalculator.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarParkRateCalculator.Tests
{
    [TestClass]
    public class StandardRateServiceTests
    {
        private StandardRateService standardRateService;

        [TestInitialize]
        public void Setup()
        {
            standardRateService = new StandardRateService();
        }

        [TestMethod]
        public void IsRateType_WhenEntryAndExitTimesAreInSpeciFiedTimes_ReturnTrue()
        {

            bool result = standardRateService.IsRateType(new DateTime(2020, 07, 16, 10, 45, 25), new DateTime(2020, 07, 19, 22, 30, 25));

            Assert.IsTrue(result);

        }

        [DataTestMethod]
        [DataRow(2020,07,16,10,30,30,25,5,DisplayName ="LessThanHour")]
        [DataRow(2020, 07, 16, 10, 30, 30, 75, 10, DisplayName = "1-2Hours")]
        [DataRow(2020, 07, 16, 10, 30, 30, 135, 15, DisplayName = "2-3Hours")]
        [DataRow(2020, 07, 16, 10, 30, 30, 185, 20, DisplayName = "3+Hours")]
        public void CalculateRate_WhenEntryAndExitTimesAreInSpeciFiedTimes_ReturnCorrectAmount(int year, int month, int day,int hour, int mins, int secs, int addmins, double expectedresult)
        {
            var EntryDateTime = new DateTime(year, month, day, hour, mins, secs);
            var ExitDateTime = EntryDateTime.AddMinutes(addmins);
            var result = standardRateService.CalculateRate(EntryDateTime, ExitDateTime );

            Assert.AreEqual(expectedresult, result.FinalRate);

        }

        [TestMethod]
        public void IsRateType_WhenEntryAndExitTimeIsWeekend_ReturnFalse()
        {

            bool result = standardRateService.IsRateType(new DateTime(2020, 07, 18, 10, 30, 25), new DateTime(2020, 07, 19, 16, 30, 25));

            Assert.IsFalse(result);

        }

    }
}
