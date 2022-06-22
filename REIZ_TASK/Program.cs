using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//TESTS for the program
// 0 0 input provides 0 
// 9 0 input provides 90
// 6 0 input provides 180
// 10 15 input provides 143

namespace REIZ_TASK1_Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours,
                minutes;

            // input output stream
            ConsoleInOutData(out hours, out minutes);

            // values validation and angle calculation
            if (hours > -1 && minutes > -1)
            {
                Console.WriteLine($"The lesser angle is: {CalculateAngle(hours, minutes)} degrees");
            }
        }

        /// <summary>
        /// Input Output stream of console data and Validation of values
        /// </summary>
        /// <param name="hours">input of hours value</param>
        /// <param name="minutes">input of minutes value</param>
        private static void ConsoleInOutData(out int hours, out int minutes)
        {
            Console.WriteLine("Please inpute Analog clock hours and minutes seperated by space and press Enter: ");
            string temp = Console.ReadLine();
            string[] values = Regex.Split(temp, " ");
            
            //validates if input is correct
            if (ValidationForInput(values, out hours, out minutes))
            {
                //validates if values are in range
                ValidationForValues(hours, minutes);
            }    
        }

        /// <summary>
        /// Validates values in ranges
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        private static void ValidationForValues(int hours, int minutes)
        {
            //checks if hours doesn't exceed boundaries
            if (hours < 0 || hours > 24)
            {
                Console.WriteLine($"Analogue clock hours value has to be in range from 0 to 24 your value {hours} is out of range");
                Environment.Exit(0);
            }
            
            //checks if minutes doesn't exceed boundaries
            if (minutes < 0 || minutes > 60)
            {
                Console.WriteLine($"Analogue clock minutes value has to be in range from 0 to 60 your value {minutes} is out of range");
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Validation of input format
        /// </summary>
        /// <param name="values">string array with values</param>
        /// <param name="hours"> hours value</param>
        /// <param name="minutes">minutes value</param>
        /// <returns>True if values are parsable to int otherwise false</returns>
        private static bool ValidationForInput(string[] values, out int hours, out int minutes)
        {
            //checks if there is 2 values and if they are parsable to int type
            if (values.Length == 2 && int.TryParse(values[0], out hours) && int.TryParse(values[1], out minutes))
                return true;

            Console.WriteLine("Wrong input format, please restart the program and try again");
            hours = minutes = -1;
            return false;
        }

        /// <summary>
        /// Calculates the lesser angle of arrows in analogue clock
        /// </summary>
        /// <param name="hours">hours value</param>
        /// <param name="minutes">minutes value</param>
        /// <returns>degrees of lesser angle between hour and minute analogue clock arrows</returns>
        public static double CalculateAngle(int hours, int minutes)
        {
            double hoursD;
            double minutesD;
            double angle;
            
            //if clock hours spins around full circle it comes back to 0
            if (hours == 12 || hours == 24)
                hours = 0;
            //if we have 24 format we need to convert it to 12 hours format
            else if (hours > 12)
                hours -= 12;

            // if minutes spin full circle it comes back to 0
            if (minutes == 60)
                minutes = 0;

            //angle of hours arrow
            hoursD = (hours * 360 / 12) + (minutes * 360 / 720);
            
            //angle of minutes arrow
            minutesD = minutes * 360 / 60;

            //susbtracts the angles to get the angle between arrows
            angle = Math.Abs(hoursD - minutesD);

            //if angle can be lesser when substracted from 360 we can convert it to different value
            angle = Math.Min(360 - angle, angle);
            return angle;
        }
    }
}
