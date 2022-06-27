using System;
using System.Collections.Generic;
using System.Text;

namespace GeneratorMPs
{
    class Template
    {
        protected const string zeroTag = "Zero";

        protected List<string> unfilledTemplateLines=new List<string>();
        
        public Template()
        {
           
        }

        protected string ReplaceTagInLine(string line, string tag, string replaceValue)
        {
           return line.Replace(tag, replaceValue);
        }

    }
}
