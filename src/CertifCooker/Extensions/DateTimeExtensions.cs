namespace CertifCooker.Extensions
{
    using System;

    internal static class DateTimeExtensions
    {
        public static bool IsWeekEnd(this DateTime self) => self.DayOfWeek == DayOfWeek.Saturday || self.DayOfWeek == DayOfWeek.Sunday;
    }
}