using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeatherApplication.Dtos
{
    public class WeatherDetailDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int LocationId { get; set; }
        [Required]
        public string LocationName { get; set; }
        [Required]
        public string RealDateTime { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:0.000}")]

        public float Temperature { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:0.000}")]

        public float Pressure { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:0.000}")]
        public float Salinity { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:0.000}")]

        public float Turbidity { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:0.000}")]
        public float Oxygen { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:0.000}")]
        public float Fluorescence { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:0.000}")]
        public float BatteryVoltage { get; set; }

        public DateTime CreateDateTime { get; set; }
    }
}