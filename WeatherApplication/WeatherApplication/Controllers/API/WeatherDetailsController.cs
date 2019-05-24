using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeatherApplication.Models;
using WeatherApplication.DAL;
using WeatherApplication.Dtos;
using AutoMapper;
namespace WeatherApplication.Controllers.API
{
    public class WeatherDetailsController : ApiController
    {
        private WeatherContext _context;
        //constructor
        public WeatherDetailsController()
        {
            _context = new WeatherContext();
        }

        //return type list
        //no input parameter
        //return list of weather data from database
        public IEnumerable<WeatherDetailDto> GetWeatherDetails()
        {

            return _context.WeatherDetails.ToList().Select(Mapper.Map<WeatherDetail, WeatherDetailDto>);

        }
        //return type WeatherDetailDto
        //take id as input parameter
        //retrive specific data from database
        public IHttpActionResult GetWeatherDetail(int id)
        {
            var weatherDetail = _context.WeatherDetails.SingleOrDefault(w => w.Id == id);
            if (weatherDetail == null)
                return NotFound();
            return Ok(Mapper.Map<WeatherDetail, WeatherDetailDto>(weatherDetail));
        }
        [HttpPost]
        //return type WeatherDetail
        //take a WeatherDetail data as input
        //save input data to server/database
        public WeatherDetail CreateWeatherDetail(WeatherDetail weatherDetail)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.WeatherDetails.Add(weatherDetail);
            _context.SaveChanges();
            return weatherDetail;
        }
        //return type void
        //take id and WeatherDetail as input
        //Edit WeatherDetail data as per id passed
        [HttpPut]
        public void UpdateWeatherDetail(int id, WeatherDetailDto weatherDetailDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var weatherDetailInDb = _context.WeatherDetails.SingleOrDefault(w => w.Id == id);
            if (weatherDetailInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(weatherDetailDto, weatherDetailInDb);
            _context.SaveChanges();
        }
        //return type void
        //take id of a WeatherDetail as input
        //Delete the specific WeatherDetail da as per id
        [HttpDelete]
        public void DeleteWeatherDetail(int id)
        {
            var customerInDb = _context.WeatherDetails.SingleOrDefault(w => w.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.WeatherDetails.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}