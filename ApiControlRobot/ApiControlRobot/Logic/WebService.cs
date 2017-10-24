 using System.Configuration;
using System.IO;
using System.Net;
using ApiControlRobot.Dto;
using Newtonsoft.Json;

namespace ApiControlRobot.Logic
{
    public class WebService
    {
        private HttpWebRequest httpWebRequest;


        public DirectionDto SendDrivingDirection(string direction)
        {
            var url = string.Format("http://{0}:5000/{1}", ConfigurationManager.AppSettings["ip"], direction);
            httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "Get";


            var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = JsonConvert.DeserializeObject<DirectionDto>(streamReader.ReadToEnd());
                return result;
            }
        }



        public Dth11SensorDto GetTemperatureFromSensor()
        {

            var url = string.Format("http://{0}:5000/getTemperature", ConfigurationManager.AppSettings["ip"]);
            httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "Get";


            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = JsonConvert.DeserializeObject<Dth11SensorDto>(streamReader.ReadToEnd());
                return result;
            }
        }
    }
}