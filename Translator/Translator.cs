using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator
{
    public class Translator
    {
        /* Метод перевода слова
         * 1 параметр - слово, которое нужно переветси
         * 2 параметр - язык, на который нужно перевести
         * результат - переведенное слово */
        public string Translate(string word, string targetLanguage)
        {
            if (word == "привет" && targetLanguage == "en") 
            {
                return "hello";
            }
            if (word =="merci" && targetLanguage == "ru") 
            {
                return "спасибо";
            }
            return string.Empty;
        }
    }
}
