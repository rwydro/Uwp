using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ApiControlRobot.Annotations;
using ApiControlRobot.Dto;
using ApiControlRobot.Logic;
using Microsoft.Practices.Prism.Commands;
using Action = ApiControlRobot.Logic.Action;

namespace ApiControlRobot.VIewModel
{
    public class ControlRobotViewModel:BaseVIewModel
    {
        public DelegateCommand GetDataCommand { get; set; }
        private WebService myWebService;

        private string humidity;
        public string Humidity
        {
            get { return humidity; }
            set
            {
                if(humidity==value)return;
                humidity = value;
                OnPropertyChanged("Humidity");
            }
        }

        private string temperature;
        public string Temperature
        {
            get { return temperature; }
            set
            {
                if (temperature == value) return;
                temperature = value;
                OnPropertyChanged("Temperature");
            }
        }

        public ControlRobotViewModel():base()
        {
            GetDataCommand=new DelegateCommand(GetData);
            myWebService = new WebService();
            Temperature = "25";
            Humidity = "25";
        }

        private void GetData()
        {    
            var result= myWebService.SendRequestToServer(Action.GetData);

            Temperature = result.Temperature;
            Humidity = result.Humidity;
        }


        
    }
}
