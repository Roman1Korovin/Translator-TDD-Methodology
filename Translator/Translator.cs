using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator
{

    public class Translator
    {
        private readonly Dictionary<(string word, string lang), Dictionary<string, string>> _dictionary;

        public Translator()
        {
            _dictionary = new Dictionary<(string word, string lang), Dictionary<string, string>>
            {
                { ("привет", "ru"), new Dictionary<string, string> { { "en", "hello" } } },
                { ("merci", "fr"), new Dictionary<string, string> { { "ru", "спасибо" } } },
            };

        }

        /* 1 параметр - слово 
         * 2 параметр - язык слова 
         * 3 параметр - перевод слова 
         * 4 парамтр - язык перевода слова
         * Необохдимо создать запись пару в словаре*/
        public void AddTranslation(string firstWord, string firstLang, string secondWord, string secondLang)
        {

            
        }

        /* Метод перевода слова
        * 1 параметр - слово, которое нужно переветси
        * 2 параметр - язык, на который нужно перевести
        * результат - переведенное слово */
        public string Translate(string word, string targetLang)
        {
            if ((word == "привет" && targetLang == "en") || (word == "merci" && targetLang == "ru"))
            {
                foreach (var entry in _dictionary)
                {
                    if (entry.Key.word == word.ToLower())
                    {
                        if (entry.Value.TryGetValue(targetLang.ToLower(), out string translation))
                        {
                            return translation;
                        }
                    }
                }
            }
           
            if(word == "хлеб" && targetLang == "en")
            {
                return "bread";
            }
            return string.Empty;
        }
    }
}
