using System;
using System.Collections.Generic;
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
            
        }

       public Dth11SensorDto SendRequestToParemeter()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("asd");
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json; charset=utf-8";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {

                string loginjson = JsonConvert.SerializeObject(new ActionDto()
                {

                });

                streamWriter.Write(loginjson);
                streamWriter.Flush();
                streamWriter.Close();

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
