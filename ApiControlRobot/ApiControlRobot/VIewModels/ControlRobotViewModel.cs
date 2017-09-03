using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ApiControlRobot.Annotations;
using ApiControlRobot.Dto;
using ApiControlRobot.Logic;
using Microsoft.Practices.Prism.Commands;

namespace ApiControlRobot.VIewModel
{
    public class ControlRobotViewModel:BaseVIewModel
    {
        public DelegateCommand GetDataCommand { get; set; }

        public delegate void test(string ss);
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

        public ControlRobotViewModel(ChoiceDirection choiceDirection):base()
        {
        
            GetDataCommand=new DelegateCommand(GetData);
            choiceDirection.ChoiceDirectionEventHandler += new EventHandler<DrivingDirectionEventArgs>(Direction_ChoiceDirectionEventHandler);
            myWebService = new WebService();
            Temperature = "25";
            Humidity = "25";
    
        }

        private void Direction_ChoiceDirectionEventHandler(object sender, EventArgs e)
        {
            var directionEventArg = e as DrivingDirectionEventArgs;
            if (directionEventArg != null)
                Direction = myWebService.SendDrivingDirection(directionEventArg.Direction);
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

        private void SetDireciton(object obj, EventArgs e)
        { 
            Direction = myWebService.SendDrivingDirection(obj.ToString());
        }

        private void GetData()
        {
            var result = myWebService.GetTemperatureFromSensor();

            Temperature = result.Temperature;
            Humidity = result.Humidity;
        }

    }
}
