using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using Windows.Devices.Pwm;

namespace Blinky.Logic
{
   public class Color:IEnumerable
    {
     
        private readonly string _color;
        private  PwmPin _gpioPin;
        private readonly int _gpioPinNumber; 

        public Color(string color,int  gpioPinNumber)
        {
            this._color = color;         
            this._gpioPinNumber = gpioPinNumber;
    
        }

        public string ColorName => this._color;

      

        public PwmPin GpioPin
        {
            get { return _gpioPin;}
            set {
                _gpioPin = value;
            }
        }

        public int GpioPinNumber => this._gpioPinNumber;   

    

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
