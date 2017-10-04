using System;
using ApiControlRobot.Logic;
using Microsoft.Practices.Prism.Commands;

namespace ApiControlRobot.VIewModel
{
    public class ControlRobotViewModel : BaseVIewModel
    {
        public delegate void test(string ss);


        private string direction;


        private string humidity;
        private readonly WebService myWebService;

        private string temperature;

        public ControlRobotViewModel(ChoiceDirectionEvent choiceDirectionEvent)
        {
            GetDataCommand = new DelegateCommand(GetData);
            choiceDirectionEvent.ChoiceDirectionEventHandler += Direction_ChoiceDirectionEventHandler;
            myWebService = new WebService();
            Temperature = "25";
            Humidity = "25";
        }

        public DelegateCommand GetDataCommand { get; set; }

        public string Humidity
        {
            get => humidity;
            set
            {
                if (humidity == value) return;
                humidity = value;
                OnPropertyChanged("Humidity");
            }
        }

        public string Temperature
        {
            get => temperature;
            set
            {
                if (temperature == value) return;
                temperature = value;
                OnPropertyChanged("Temperature");
            }
        }


        public string Direction
        {
            get => direction;
            set
            {
                if (direction == value) return;
                direction = value;
                OnPropertyChanged("Direction");
            }
        }

        private void Direction_ChoiceDirectionEventHandler(object sender, EventArgs e)
        {
            var directionEventArg = e as DrivingDirectionEventArgs;
            if (directionEventArg != null)
                Direction = myWebService.SendDrivingDirection(directionEventArg.Direction);
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