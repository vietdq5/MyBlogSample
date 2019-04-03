using System;

namespace SieuNhanGao.Utilities.Helpers
{
    public class DateFormat
    {
        public static string GetPrettyDateAgo(DateTime date)
        {
            // Get time span elapsed since the date.
            var s = DateTime.Now.Subtract(date);
            // Get total number of days elapsed.
            var dayDiff = (int)s.TotalDays;
            // Get total number of seconds elapsed.
            var secDiff = (int)s.TotalSeconds;

            if (dayDiff < 0)
            {
                return string.Empty;
            }

            if (dayDiff == 0)
            {
                // dưới 1p
                if (secDiff < 60)
                {
                    return "just now";
                }
                // dưới 2p
                if (secDiff < 120)
                {
                    return "1m ago";
                }
                // dưới 1h
                if (secDiff < 3600)
                {
                    return string.Format("{0}m ago",
                        Math.Floor((double)secDiff / 60));
                }
                // dưới hơn 2h
                if (secDiff < 7200)
                {
                    return "1h ago";
                }
                // dưới 1 ngày
                if (secDiff < 86400)
                {
                    return string.Format("{0}h ago",
                        Math.Floor((double)secDiff / 3600));
                }
            }
            // Hiển thị theo ngày tháng năm ago
            if (dayDiff == 1)
            {
                return "Yesterday";
            }
            if (dayDiff < 7)
            {
                return string.Format("{0} Days ago", dayDiff);
            }
            // duoi 3 tháng thì hiển thị theo week
            if (dayDiff < 56)
            {
                return string.Format("{0} Weeks ago",
                    Math.Ceiling((double)dayDiff / 7));
            }

            if (dayDiff < 365)
            {
                return string.Format("{0} Months ago",
                    Math.Ceiling((double)dayDiff / 30));
            }
            // neu qua 1 nam thì return la gia tri gốc
            return date.ToShortDateString();
        }
    }
}