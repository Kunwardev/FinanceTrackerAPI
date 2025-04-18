using System;
using Serilog;

namespace FinanceTrackerAPI.Extensions
{
    public static class StringExtensions
    {
        public static string EscapeSingleQuote(this string unformatted)
        {
            try
            {
                if (String.IsNullOrEmpty(unformatted))
                {
                    return unformatted;
                }
                return unformatted.Trim().Replace('\u2018', '\'').Replace('\u2019', '\'').Replace('\u201c', '"').Replace('\u201d', '"');
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Error in String Extension Method");
                return ex.Message;
            }
        }
    }
}