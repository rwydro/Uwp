using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ApiControlRobot.Annotations;
using ApiControlRobot.Dto;
using ApiControlRobot.Logic;
using ApiControlRobot.View.ViewModel;
using Microsoft.Practices.Prism.Commands;

namespace ApiControlRobot.VIewModel
{
    public class ControlRobotViewModel:BaseVIewModel
    {
        public DelegateCommand GetDataCommand { get; set; }
        public RelayCommand DrivingDirectionCommand { get; set; }
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
            DrivingDirectionCommand = new RelayCommand(SetDireciton);
            myWebService = new WebService();
            Temperature = "25";
            Humidity = "25";
        }

        private string direction;
        public string  Direction
            {
            get { return direction; }
            set
            {
                if (direction == value) return;
                direction = value;
                OnPropertyChanged("Direction");
            }
        }

        private void SetDireciton(object obj)
        {
            Direction = obj.ToString();
        }
        private void GetData()
        {    
            var result= myWebService.SendRequestToParemeter();
      
            Temperature = result.Temperature;
            Humidity = result.Humidity;
        }


        
    }
}
