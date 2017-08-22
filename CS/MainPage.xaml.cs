// Copyright (c) Microsoft. All rights reserved.

using System;
using System.Threading.Tasks;
using Windows.Devices;
using Windows.Devices.Gpio;
using Windows.Devices.Pwm;
using Windows.System.Threading;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;
using blink.Logic;
using Microsoft.IoT.Lightning.Providers;

namespace Blinky
{
    public sealed partial class MainPage : Page
    {

        private const int LED_PIN = 5;
        private GpioPin pin;
        private GpioPinValue pinValue;
        private DispatcherTimer timer;
        private SolidColorBrush redBrush = new SolidColorBrush(Windows.UI.Colors.Red);
        private SolidColorBrush grayBrush = new SolidColorBrush(Windows.UI.Colors.LightGray);

        public MainPage()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
           // timer.Interval = TimeSpan.FromMilliseconds(500);
          //  timer.Tick += Timer_Tick;
          //  InitGPIO();
            //StartServer();
            //StartServerif (pin != null)
            //{
            //    timer.Start();
            //}        
        }
        private async Task StartServer()
        {
            var server = new MyWebService();

            await ThreadPool.RunAsync(operation =>
            {
                //  MyWebserver.Start();
                //rasp.message = server.query;
                //textBox.Text = server.query;
                 server.Listenear();
                // SetTextBox();
            });
        }
        private void InitGPIO()
        {
            var gpio = GpioController.GetDefault();

            // Show an error if there is no GPIO controller
            if (gpio == null)
            {
                pin = null;
                GpioStatus.Text = "There is no GPIO controller on this device.";
                return;
            }
           
            pin = gpio.OpenPin(LED_PIN);
            pinValue = GpioPinValue.High;
            pin.Write(pinValue);
            pin.SetDriveMode(GpioPinDriveMode.Output);

            GpioStatus.Text = "GPIO pin initialized correctly.";

        }

   




        private async void Timer_Tick(object sender, object e)
        {

            if (pinValue == GpioPinValue.High)
            {
                pinValue = GpioPinValue.Low;
                pin.Write(GpioPinValue.Low);
                LED.Fill = redBrush;
            }
            else
            {
                pinValue = GpioPinValue.High;
                await Task.Delay(500);
                pin.Write(GpioPinValue.High);
                LED.Fill = grayBrush;
            
             }
        }

        private async void button2_Click(object sender, RoutedEventArgs e)
        {

            //pinValue = GpioPinValue.Low;
            //pin.Write(GpioPinValue.Low);
            //LED.Fill = redBrush;



            LowLevelDevicesController.DefaultProvider = LightningProvider.GetAggregateProvider();

                var pwmControllers = await PwmController.GetControllersAsync(LightningPwmProvider.GetPwmProvider());
                var pwmController = pwmControllers[0]; // use the on-device controller
                pwmController.SetDesiredFrequency(50); // try to match 50Hz

               var _pin = pwmController.OpenPin(LED_PIN);
                _pin.SetActiveDutyCyclePercentage(.75);
                _pin.Start();
            
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            pinValue = GpioPinValue.High;       
            pin.Write(GpioPinValue.High);
            LED.Fill = grayBrush;
        }
    }
}
