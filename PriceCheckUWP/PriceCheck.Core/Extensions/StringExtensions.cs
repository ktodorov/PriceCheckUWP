using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCheck.Core.Extensions
{
    public static class StringExtensions
    {
        public static string SeparateCamelCase(this string text)
        {
            var array = text.ToCharArray().ToList();

            var resultArray = new List<char>();

            var i = 0;
            foreach (var symbol in array)
            {
                if (char.IsUpper(symbol) && i != 0)
                {
                    resultArray.Add(' ');
                    resultArray.Add(char.ToLower(symbol));
                }
                else
                {
                    resultArray.Add(symbol);
                }
                i++;
            }

            var result = string.Join("", resultArray.ToArray());

            return result;
        }
    }
}
