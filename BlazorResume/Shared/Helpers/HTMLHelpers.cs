using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlazorResume.Shared.Helpers
{
    public class HTMLHelpers
    {
        public static string ConvertNewLinesToBR(string textToConvert)
        {
            // Convert new lines into line breaks, so it will render properly in the component
            return Regex.Replace(textToConvert, "\n", "<br>");
        }
    }
}
