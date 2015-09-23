using System;
using System.Globalization;
using System.Linq;

namespace Infrastructure.CrossCutting.Common
{
    public static class DateTimeUtils
    {
        /// <summary>
        /// Convierte una fecha en una cadena con formato: dd/mm/yyyy hh:mm:ss(includeSeconds = true), dd/mm/yyyy
        /// (soloFecha = false).
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="includeSeconds"></param>
        /// <returns>dd/mm/yyyy hh:mm:ss => (includeSeconds = true), dd/mm/yyyy => (soloFecha = false)</returns>
        public static string GetDateTime(this DateTime dateTime, bool includeSeconds = true)
        {
            return includeSeconds
                ? string.Format("{0:dd/MM/yyyy HH:mm:ss}", dateTime)
                : string.Format("{0:dd/MM/yyyy}", dateTime);
        }

        /// <summary>
        /// Extrae la hora de una fecha en formato: hh:mm.
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns>hh:mm</returns>
        public static string ConvertToHour(this DateTime fecha)
        {
            return string.Format("{0:HH:mm}", fecha);
        }

        /// <summary>
        /// Extrae la hora de una fecha en formato: hh:mm AM o hh:mm PM
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns>hh:mm {AM or PM}</returns>
        public static string ConvertToHourAMPM(this DateTime fecha)
        {
            var horas = fecha.Hour;
            var minutos = fecha.Minute;

            if (horas > 11)
            {
                if (horas != 12)
                    horas = (horas % 12);

                if (minutos < 10)
                    return string.Format("{0}:0{1} PM", horas, minutos);
                else
                    return string.Format("{0}:{1} PM", horas, minutos);
            }
            else
            {
                if (minutos < 10)
                    return string.Format("{0}:0{1} AM", horas, minutos);
                else
                    return string.Format("{0}:{1} AM", horas, minutos);
            }
        }

        /// <summary>
        /// Extrae la hora de una fecha en formato: hh:mm AM o hh:mm PM
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns>hh:mm {AM or PM}</returns>
        public static string ConvertToHourAMPM(this TimeSpan fecha)
        {
            var horas = fecha.Hours;
            var minutos = fecha.Minutes;

            if (horas > 11)
            {
                if (horas != 12)
                    horas = (horas % 12);

                if (minutos < 10)
                    return string.Format("{0}:0{1} PM", horas, minutos);
                else
                    return string.Format("{0}:{1} PM", horas, minutos);
            }
            else
            {
                if (minutos < 10)
                    return string.Format("{0}:0{1} AM", horas, minutos);
                else
                    return string.Format("{0}:{1} AM", horas, minutos);
            }
        }

        /// <summary>
        /// Convierte una cadena en formato: hh:mm AM o hh:mm PM a TimeSpan
        /// </summary>
        /// <param name="hora"></param>
        /// <returns>TimeSpan</returns>
        public static TimeSpan ConvertToTimeSpan(this string hora)
        {
            var timeSpanArray = hora.Split(':');
            var timeSpanSubArray = timeSpanArray[1].Split(' ');
            var horas = Convert.ToInt32(timeSpanArray[0]);
            var minutos = Convert.ToInt32(timeSpanSubArray[0]);
            var meridiano = timeSpanSubArray[1];

            if (meridiano == "PM" && horas != 12)
            {
                horas += 12;
            }

            if (meridiano == "AM" && horas == 12)
            {
                horas = 0;
            }

            if (horas > 9)
            {
                if (minutos > 9)
                    return TimeSpan.Parse(horas + ":" + minutos + ":00");
                else
                    return TimeSpan.Parse(horas + ":0" + minutos + ":00");
            }
            else
            {
                if (minutos > 9)
                    return TimeSpan.Parse("0" + horas + ":" + minutos + ":00");
                else
                    return TimeSpan.Parse("0" + horas + ":0" + minutos + ":00");
            }
        }

        /// <summary>
        /// Convierte una cadena en formato: hh:mm AM o hh:mm PM a String hh:mm:00
        /// </summary>
        /// <param name="hora"></param>
        /// <returns>hh:mm:00</returns>
        public static string ConvertToTimeSpanString(this string hora)
        {
            var timeSpanArray = hora.Split(':');
            var timeSpanSubArray = timeSpanArray[1].Split(' ');
            var horas = Convert.ToInt32(timeSpanArray[0]);
            var minutos = Convert.ToInt32(timeSpanSubArray[0]);
            var meridiano = timeSpanSubArray[1];

            if (meridiano == "PM" && horas != 12)
            {
                horas += 12;
            }

            if (meridiano == "AM" && horas == 12)
            {
                horas = 0;
            }

            if (horas > 9)
            {
                if (minutos > 9)
                    return horas + ":" + minutos + ":00";
                else
                    return horas + ":0" + minutos + ":00";
            }
            else
            {
                if (minutos > 9)
                    return "0" + horas + ":" + minutos + ":00";
                else
                    return "0" + horas + ":0" + minutos + ":00";
            }
        }

        public static string GetMonthName(int monthNumber)
        {
            var months = DateTimeFormatInfo.CurrentInfo.MonthNames.Select((p, index) => new { Nombre = p.ToUpper(), Id = index + 1 }).ToList();

            var month = months.FirstOrDefault(p => p.Id == monthNumber);

            if (month != null)
            {
                return month.Nombre;
            }
            return string.Empty;
        }

        public static DateTime? ConvertDateNullable(string dateValue, string format)
        {
            if (!string.IsNullOrEmpty(dateValue))
            {
                DateTime parsedDate;
                if (DateTime.TryParseExact(dateValue, format, null, DateTimeStyles.None, out parsedDate))
                    return parsedDate;
                return null;
            }
            return null;
        }

        public static DateTime ConvertDate(string dateValue, string format)
        {
            if (!string.IsNullOrEmpty(dateValue))
            {
                DateTime parsedDate;
                if (DateTime.TryParseExact(dateValue, format, null, DateTimeStyles.None, out parsedDate))
                    return parsedDate;
                else
                    return DateTime.UtcNow;
            }
            else
            {
                return DateTime.UtcNow;
            }
        }

        public static bool CheckingConvertDate(string dateValue, string format)
        {
            if (!string.IsNullOrEmpty(dateValue))
            {
                DateTime parsedDate;
                if (DateTime.TryParseExact(dateValue, format, null, DateTimeStyles.None, out parsedDate))
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
    }
}
