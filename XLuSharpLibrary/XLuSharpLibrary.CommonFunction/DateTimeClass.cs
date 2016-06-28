namespace XLuSharpLibrary.CommonFunction
{
    using System;

    public class DateTimeClass
    {
        public static bool DateCompare(DateTime dtstart, DateTime dtover)
        {
            if (dtstart > dtover)
            {
                return false;
            }
            return true;
        }

        public static DateTime GetMonthFirstDay(DateTime today)
        {
            return today.AddDays((double) (-today.Day + 1));
        }

        public static int GetMonthMaxDay(int year, int month)
        {
            return DateTime.DaysInMonth(year, month);
        }

        public static string GetWeekText(DateTime date)
        {
            string[] strArray = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            return strArray[Convert.ToInt16(date.DayOfWeek)];
        }
    }
}

