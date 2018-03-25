using System;
using System.Text;
using System.Text.RegularExpressions;

namespace KnockKnockServer
{
    public static class StringUtilities
    {
        static StringUtilities()
        {
            // Need to make sure we have ISO-8859-8 encoding available for RemoveDiacriticals
            System.Text.EncodingProvider provider = System.Text.CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(provider);
        }

        /// <summary>
        /// Compare two strings to see if the alphanumeric characters in them are the same.
        ///  - Case insensitive
        ///  - Ignores punctuation
        ///  - Treats letters with diacritical marks (e.g. accents) as the unmarked character
        /// </summary>
        public static bool AreEqualAlphaNumeric(string string1, string string2)
        {
            var removePunctuationRegex = new Regex(@"[\p{P}]");
            string1 = removePunctuationRegex.Replace(string1, "");
            string2 = removePunctuationRegex.Replace(string2, "");
            string1 = RemoveDiacriticals(string1);
            string2 = RemoveDiacriticals(string2);
            return string1.Equals(string2, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Remove diacritical marks (e.g. accents) and replace the marked character with the
        /// unmarked character.
        /// </summary>
        public static string RemoveDiacriticals(string s)
        {
            byte[] tempBytes;
            tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(s);
            return System.Text.Encoding.UTF8.GetString(tempBytes);
        }
    }

}