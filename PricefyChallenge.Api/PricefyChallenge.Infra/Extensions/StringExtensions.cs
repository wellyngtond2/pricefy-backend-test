using System;

namespace PricefyChallenge.Infra.Extensions
{
    public static class StringExtensions
    {
        public static int? ConvertToInt(this string source)
        {
            if (string.IsNullOrWhiteSpace(source) || source.ToUpper().Equals("\\N")) return null;

            return Convert.ToInt32(source);
        }
    }
}
