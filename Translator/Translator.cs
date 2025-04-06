using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator
{
    public class Translator
    {
        public string Translate(string word, string targetLanguage)
        {
            if (word == "привет" && targetLanguage == "en") 
            {
                return "hello";
            }
            return string.Empty;
        }
    }
}
