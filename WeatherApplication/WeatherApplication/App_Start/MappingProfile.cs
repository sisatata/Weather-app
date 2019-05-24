using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WeatherApplication.Models;
using WeatherApplication.Dtos;
namespace WeatherApplication.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<WeatherDetail, WeatherDetailDto>();
            Mapper.CreateMap<WeatherDetailDto, WeatherDetail>();

        }
    }
}