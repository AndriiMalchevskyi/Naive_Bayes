using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Naive_Bayes
{
    public static class Helpers
    {
        public static List<String> ExtractFeatures(this String text)
        {
            return Regex.Replace(text, "\\p{P}+", "").Split(' ').ToList();
        }
    }
}
