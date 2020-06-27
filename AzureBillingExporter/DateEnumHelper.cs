using System;
using System.Globalization;

internal static class DateEnumHelper
{
    public static string ReplaceDateValueToEnums(string dataColumnByKeyLabel)
    {
        var now = DateTime.Now;

        var currentMonthStart = new DateTime(now.Year, now.Month, 1);
        if (dataColumnByKeyLabel == currentMonthStart.ToString("yyyy-MM-01T00:00:00", CultureInfo.InvariantCulture))
        {
            return "current_month";
        }
            
        var previousMonthStart = new DateTime(now.Year, now.Month, 1);
        previousMonthStart = previousMonthStart.AddMonths(-1);
        if (dataColumnByKeyLabel == previousMonthStart.ToString("yyyy-MM-01T00:00:00", CultureInfo.InvariantCulture))
        {
            return "previous_month";
        }
        
        var beforePreviousMonthStart = new DateTime(now.Year, now.Month, 1);
        beforePreviousMonthStart = beforePreviousMonthStart.AddMonths(-2);
        if (dataColumnByKeyLabel == beforePreviousMonthStart.ToString("yyyy-MM-01T00:00:00", CultureInfo.InvariantCulture))
        {
            return "before_previous_month";
        }

        // "20200624" -> "today"
        var today = new DateTime(now.Year, now.Month, now.Day);
        if (dataColumnByKeyLabel == today.ToString("yyyyMMdd", CultureInfo.InvariantCulture))
        {
            return "today";
        }
            
        var yesterday = new DateTime(now.Year, now.Month, now.Day);
        yesterday = yesterday.AddDays(-1);
        if (dataColumnByKeyLabel == yesterday.ToString("yyyyMMdd", CultureInfo.InvariantCulture))
        {
            return "yesterday";
        }
            
        var beforeYesterday = new DateTime(now.Year, now.Month, now.Day);
        beforeYesterday = beforeYesterday.AddDays(-2);
        if (dataColumnByKeyLabel == beforeYesterday.ToString("yyyyMMdd", CultureInfo.InvariantCulture))
        {
            return "before_yesterday";
        }
            
        return dataColumnByKeyLabel;
    }
}