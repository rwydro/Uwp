using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using ApiControlRobot.Dto;

namespace ApiControlRobot.Logic
{
    public class WebService
    {
        private HttpWebRequest httpWebRequest;

        public WebService()
        {
          
            // httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
         
        }
       

        public string SendDrivingDirection(string direction)
        {
            string url = String.Format("http://{0}:5000/{1}", ConfigurationManager.AppSettings["ip"],direction);
            httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "Get";

           
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var resut = streamReader.ReadToEnd();
                return resut;
            }
        }

        public Dth11SensorDto GetTemperatureFromSensor()
        {
            string url = String.Format("http://{0}:5000", ConfigurationManager.AppSettings["ip"]);
            httpWebRequest = (HttpWebRequest)WebRequest.Create("http://192.168.0.220");
            httpWebRequest.Method = "Get";


            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {

                string loginjson = JsonConvert.SerializeObject(new DrivingDirectionEventArgs()
                {

                });

                streamWriter.Write(loginjson);
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = JsonConvert.DeserializeObject<Dth11SensorDto>(streamReader.ReadToEnd()) ;
                    return new Dth11SensorDto() {Humidity = result.Humidity, Temperature = result.Temperature};
                }
            }
        }

    }
}
