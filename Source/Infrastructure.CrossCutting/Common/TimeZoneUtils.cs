using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.CrossCutting.Common
{
    public static class TimeZoneUtils
    {
        /// <summary>
        /// Returns TimeZone adjusted time for a given from a Utc or local time.
        /// Date is first converted to UTC then adjusted.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="timeZoneId"></param>
        /// <returns></returns>
        public static DateTime ToTimeZoneTime(this DateTime time, string timeZoneId)
        {
            var tzi = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            var date = TimeZoneInfo.ConvertTimeFromUtc(time, tzi);
            return date;
        }

        public static DateTime? ToTimeZoneTime(this DateTime? time, string timeZoneId)
        {
            var tzi = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            var date = time.HasValue ? TimeZoneInfo.ConvertTimeFromUtc(time.Value, tzi) : (DateTime?)null;
            return date;
        }

        public static T ChangeTimeZoneInObjectFields<T>(T obj, string timeZoneId) where T: class
        {
            var properties = obj.GetType()
                                .GetProperties()
                                .Where(p => p.PropertyType == typeof(DateTime) ||
                                            p.PropertyType == typeof(DateTime?));

            foreach (var property in properties)
            {
                var value = property.GetValue(obj, null);

                if (Nullable.GetUnderlyingType(property.PropertyType) == null)
                {
                    var valueChanged = ((DateTime)value).ToTimeZoneTime(timeZoneId);
                    property.SetValue(obj, valueChanged, null);
                }
                else
                {
                    var valueChanged = ((DateTime?)value).ToTimeZoneTime(timeZoneId);
                    property.SetValue(obj, valueChanged, null);
                }
            }
            return obj;
        }

        public static IEnumerable<T> ChangeTimeZoneInListObject<T>(IEnumerable<T> objs, string timeZoneId) where T : class
        {
            foreach (var obj in objs)
            {
                ChangeTimeZoneInObjectFields(obj, timeZoneId);
            }
            return objs; 
        }
    }
}
