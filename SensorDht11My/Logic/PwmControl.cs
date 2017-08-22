using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blinky.Logic
{
   public static class PwmControl
    {
        private static readonly Dictionary<string, string> _listOfColors = new Dictionary<string, string>() // ustawienia wypelnienia pinow sa w kolejnosci RGB
            {
                { "Czerwony","1,0,0"},
                { "zielony","0,1,0"},
                { "niebieski","0,0,1"}
            };
     //   private static string color;

       

        public static double[] GetPwmSettings(string color)
        {
            string[] pwmSettings = new string[] { };

            if (_listOfColors.ContainsKey(color))
            {
                var col = _listOfColors.Single(x => x.Key == color).Value;
                pwmSettings = col.Split(',');
            }
            return IntArrayParse(pwmSettings);
        }

        private static double[] IntArrayParse(string[] parse)
        {
            double[] doubleArray = new double[] {};
            for (int i = 0; i < parse.Length; i++)
            {
                doubleArray[i] = double.Parse(parse[i]);
            }
            return  doubleArray;
        }
    }
}
