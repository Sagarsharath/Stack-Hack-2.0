using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HRM.Rest.Services.Util
{
    public static class RegExUtil
    {
        public static readonly string EMAIL_ID_FORMAT = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";


        /// <summary>
        /// Determines the input string match with the pattern
        /// </summary>
        /// <param name="keyword">input string</param>
        /// <param name="pattern">regex pattern</param>
        /// <returns>true if matched else false</returns>
        public static bool IsMatch(string keyword, string pattern)
        {

            if (String.IsNullOrEmpty(keyword))
                throw new ArgumentNullException("keyword");

            if (String.IsNullOrEmpty(pattern))
                throw new ArgumentNullException("pattern");

            return Regex.IsMatch(keyword, pattern);

        }


    }
}
