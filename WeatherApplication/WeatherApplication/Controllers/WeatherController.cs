using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WeatherApplication.DAL;
using WeatherApplication.Models;

namespace WeatherApplication.Controllers
{
    public class WeatherController : Controller
    {

        private WeatherContext db = new WeatherContext();
        public string Location;
        public int LocationNumber;
        public string TimeStamp;
        string[] ValueOfWeatherData;
        List<string> WeatherData = new List<string>();


        // GET: Weather
        //return type view
        //take no input
        //show weather chart

        public ActionResult Index()
        {


            return View();
        }
        //retun json data
        //take no input
        
        public JsonResult LoadData()
        {
            var data = db.WeatherDetails.ToList();

            data = db.WeatherDetails.OrderBy(a => a.LocationName).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        //return type view
        //take no input
        //show weather data in list view
        public ActionResult ShowData()
        {
            return View(db.WeatherDetails.ToList());
        }
       //return type view
       //take no input
       //function for uplaoding file
        public ActionResult Create()
        {
            return View();
        }
        // method to read text file and save data
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase postedFile)
        {
            string filePath = string.Empty;
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);
                string[] Lines = { };
                Lines = System.IO.File.ReadAllLines(filePath);
                int count = 0;

                int NumberOfWords = 0;
                TimeStamp = null;



                foreach (string Line in Lines)
                {
                    count++;
                    if (count > 1 && count < 9) continue;
                    string CurrentLine = Line;
                    CurrentLine = Regex.Replace(CurrentLine, " {2,}", " ");
                    ValueOfWeatherData = CurrentLine.Split(' ');
                    NumberOfWords = ValueOfWeatherData.Count() - 1;
                    NumberOfWords--;
                    if (count == 1)
                        Location = ValueOfWeatherData[NumberOfWords].ToString();
                    else if (count >= 9)
                    {

                        WeatherDetail CurrentData = new WeatherDetail();
                        foreach (string word in ValueOfWeatherData)
                        {

                            if (!string.IsNullOrWhiteSpace(word))
                            {
                                WeatherData.Add(word);
                                

                            }

                        }
                        
                        for (int i = 0; i < WeatherData.Count(); i++)
                        {
                            CurrentData.LocationId = int.Parse(Location);
                            CurrentData.RealDateTime = (WeatherData[0]);
                            CurrentData.Pressure = float.Parse(WeatherData[1]);
                            CurrentData.Salinity = float.Parse(WeatherData[3]);
                            CurrentData.Turbidity = float.Parse(WeatherData[4]);
                            CurrentData.Oxygen = float.Parse(WeatherData[5]);
                            CurrentData.Fluorescence = float.Parse(WeatherData[6]);
                            CurrentData.Fluorescence = (float)System.Math.Round(CurrentData.Fluorescence, 3);
                            CurrentData.BatteryVoltage = float.Parse(WeatherData[7]);
                            CurrentData.Temperature = float.Parse(WeatherData[2]);
                            CurrentData.LocationName = "Rajshahi";
                            DateTime now = DateTime.Now;
                            CurrentData.CreateDateTime = now;

                        }
                       // New(CurrentData);
                        db.WeatherDetails.Add(CurrentData);
                        db.SaveChanges();
                        WeatherData.Clear();

                    }

                }
            }

            


            return View();
        }

        
       
    }
}