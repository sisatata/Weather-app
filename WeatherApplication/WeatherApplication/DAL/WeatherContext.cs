using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WeatherApplication.Models;
namespace WeatherApplication.DAL
{
    public class WeatherContext : DbContext
    {
        public WeatherContext() : base("WeatherContext") { }

        public DbSet<WeatherDetail> WeatherDetails { get; set; }
      



    }

}