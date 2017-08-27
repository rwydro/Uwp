using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ApiControlRobot.Annotations;
using ApiControlRobot.Logic;
using Microsoft.Practices.Prism.Commands;

namespace ApiControlRobot.VIewModel
{
    public class ControlRobotViewModel:BaseVIewModel
    {
        public DelegateCommand GetDataCommand;
        private WebService myWebService;

        private int humiditly;
        public int Humiditly
        {
            get { return humiditly; }
            set
            {
                if(humiditly==value)return;
                humiditly = value;
                OnPropertyChanged("Humiditly");
            }
        }

        private int temperature;
        public int Temperature
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
            myWebService= new WebService();
            Humiditly = 20;
            Temperature = 25;
        }

        private static void GetData()
        {
           
        }


        
    }
}
