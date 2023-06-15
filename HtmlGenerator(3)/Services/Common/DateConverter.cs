using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Services.Common
{
    public class DateConverter
    {
        private static DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        public static string ConvertToDateTime(int seconds){

            var result = unixStart + new TimeSpan(0,0, seconds);
            return result.ToString();
        }

        public static string ConvertToDateTime(string number) {

            if (int.TryParse(number, out int result))
                return ConvertToDateTime(result);

            return string.Empty;
        }
    }
}
