﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CarParkRateCalculator.Services
{
    public class StandardRateService : IRateCalculatorService
    {
        /// <summary>
        /// Ge the difference between entry and exit times and calculate the hourle rate
        /// </summary>
        /// <param name="entryDateTime"></param>
        /// <param name="exitdateTime"></param>
        /// <returns></returns>
        public double CalculateRate(DateTime entryDateTime, DateTime exitdateTime)
        {
            if ((entryDateTime.DayOfWeek == DayOfWeek.Saturday || entryDateTime.DayOfWeek == DayOfWeek.Sunday) 
                && (exitdateTime.DayOfWeek == DayOfWeek.Saturday || exitdateTime.DayOfWeek == DayOfWeek.Sunday))
            {
                return 10;
            }

            //Get the difference between entry time and exit time
            TimeSpan interval = exitdateTime.Subtract(entryDateTime);

            //Convert the Timespan difference into minutes
            var intervalmins = interval.Hours * 60 + interval.Minutes; // interval.TotalMinutes; //interval.Days * 24 * 60 + interval.Hours * 60 + interval.Minutes;
            var intervalHours = interval.TotalHours;

            if (intervalHours <= 24)
            {
                return CalculateHourlyRate(intervalmins);
            }

            return CalculateHourlyRate(intervalmins) + (interval.Days * 20);

        }

        /// <summary>
        /// Calculate the amount based on the hours spent at the car park (business requirements)
        /// </summary>
        /// <param name="intervalmins"></param>
        /// <returns></returns>
        private double CalculateHourlyRate(double intervalmins)
        {
            if (intervalmins > 0 && intervalmins <= 60)   // 0-1 Hours
            {
                return 5;
            }
            else if (intervalmins > 60 && intervalmins <= 120)   // 1-2 Hours
            {
                return 10;
            }
            else if (intervalmins > 120 && intervalmins <= 180)   // 2-3 Hours
            {
                return 15;
            }
            else if (intervalmins > 180 && intervalmins <= (60 * 24))  // 3+ Hours and less than  a Day
            {
                return 20;
            }

            return 0;
        }

        public bool IsRateType(DateTime entryDateTime, DateTime exitdateTime)
        {
            if ((entryDateTime.DayOfWeek == DayOfWeek.Saturday || entryDateTime.DayOfWeek == DayOfWeek.Sunday)
                && (exitdateTime.DayOfWeek == DayOfWeek.Saturday || exitdateTime.DayOfWeek == DayOfWeek.Sunday))
            {
                return false;
            }
            return true;
        }
    }
}
