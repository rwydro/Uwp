using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiControlRobot.Logic
{
    public class WebService
    {
        private HttpWebRequest httpWebRequest;

        public WebService()
        {
            
        }

        private void SetRequestParameters()
        {
            httpWebRequest = (HttpWebRequest)WebRequest.Create("http://url");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
        }

    }
}
