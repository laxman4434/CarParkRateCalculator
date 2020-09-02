using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkRateCalculator.Api.Models
{
    /// <summary>
    /// Object with request params
    /// </summary>
    public class RateRequest
    {
        /// <summary>
        /// Entry time into the Car Park
        /// </summary>
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EntryDateTime { get; set; }

        /// <summary>
        /// Exit time out of the Car Park
        /// </summary>
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ExitDateTime { get; set; }
    }
}
