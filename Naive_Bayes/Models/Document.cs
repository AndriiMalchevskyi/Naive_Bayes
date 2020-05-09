using System;
using System.Collections.Generic;
using System.Text;

namespace Naive_Bayes
{
    public class Document
    {
        public Document(string @class, string text)
        {
            Class = @class;
            Text = text;
        }
        public string Class { get; set; }
        public string Text { get; set; }
    }
}
