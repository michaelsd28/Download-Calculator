using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Download_Calculator.Services
{
    public class CalculatorService
    {


      private   static string SecondsToDatetime(long  Timestamp, string ConvertFormat)
        {
            DateTime ConvertedUnixTime = DateTimeOffset.FromUnixTimeSeconds(Timestamp).DateTime;
            return ConvertedUnixTime.ToString(ConvertFormat);
        }


        public static string GetTimeLeft(double size , double speed, string sizeType,string speedType) 
        {
            var sizeKB = CalculatorHelper.SizeToKilobite(size, sizeType);
            var speedKb = CalculatorHelper.SpeedToKilobite(speed, speedType);

            var secondsLeft = sizeKB / speedKb;



          var formatedTime =  SecondsToDatetime( (long) secondsLeft, "HH:mm:ss");


            return formatedTime;
        }

    }

     internal static  class CalculatorHelper 
    {
        public static double SizeToKilobite(double size, string sizeType) 
        {

            sizeType = sizeType.Replace("System.Windows.Controls.ComboBoxItem: ", "");
            double result;

            Debug.WriteLine($"called SizeToKilobite --- size::{size} * sizeType:: {sizeType}");

            switch (sizeType)
            {
         
                case "MB":
                    Debug.WriteLine($"called MB");
                    result = size * 1000;
                    break;

                case "GB":
                    Debug.WriteLine($"called GB");
                    result = size * 1000000;
                    break;

                case "TB":
                    Debug.WriteLine($"called TB");
                    result = size * 1000000000;
                    break;

                default:
                    Debug.WriteLine($"called default");
                    return size * 8;
     
            }


            return result * 8;
        
        }

        public static double SpeedToKilobite(double speed, string speedType)
        {


            speedType = speedType.Replace("System.Windows.Controls.ComboBoxItem: ", "");
            double result = 0;


            switch (speedType)
            {

                case "Mbps":
                    result = speed * 1000;
                    break;

                case "Gbps":
                    result = speed * 1000000;
                    break;

                case "Tbps":
                    result = speed * 1000000000;
                    break;

                default:
                    return speed;
          

            }


            return result;

        }



    }
}
