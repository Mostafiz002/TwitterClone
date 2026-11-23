using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Utilities.Extensions
{
    public static class StringExtensions
    {
        public static bool IsLong(this string value)
        {
            return value.Length > 10;
        }
    }
}
