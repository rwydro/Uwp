using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace Blinky.Logic
{
    public class Raspberry
    {

        private static int gpioPin = 5;
        private static GpioPin pin;
        private static GpioPinValue pinValue;
        //   public  string message { get; set; }

        //public Raspberry()
        //{
        //    //  this.message = message;
        //     GpioInit();
        //}

        public Raspberry()
        {
            Gpio_Init();
        }

        private void Gpio_Init()
        {
            var gpio = GpioController.GetDefault();

            // Show an error if there is no GPIO controller
            if (gpio == null)
            {
                pin = null;
                return;
            }
            pin = gpio.OpenPin(gpioPin);
            pinValue = GpioPinValue.High;
            pin.Write(pinValue);
            pin.SetDriveMode(GpioPinDriveMode.Output);
        }

        public void Switch(string message)
        {
            if (message.Contains("wlacz")) TurnOnLight();
            if (message.Contains("wylacz")) TurnOffLight();

        }
        public void TurnOnLight()
        {
            pinValue = GpioPinValue.Low;
            pin.Write(pinValue);

        }

        public void TurnOffLight()
        {
            pinValue = GpioPinValue.High;
            pin.Write(pinValue);
        }

    }
}
