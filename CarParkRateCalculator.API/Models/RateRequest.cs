using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkRateCalculator.Api.Models
{
    public class RateRequest
    {
        // Entry time into the Car Park
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EntryDateTime { get; set; }

        //Exit time out of the Car Park
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ExitDateTime { get; set; }
    }
}
