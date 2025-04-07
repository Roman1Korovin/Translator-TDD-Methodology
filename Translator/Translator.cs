﻿using System;
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
                { ("hello", "en"), new Dictionary<string, string> { { "ru", "привет" } } },
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
            var key = (firstWord.ToLower(), firstLang.ToLower());
            var reverseKey = (secondWord.ToLower(), secondLang.ToLower());

            // Добавляем прямой перевод
            if (!_dictionary.ContainsKey(key))
            {
                _dictionary[key] = new Dictionary<string, string>();
            }
            _dictionary[key][secondLang.ToLower()] = secondWord;

            // Добавляем обратный перевод
            if (!_dictionary.ContainsKey(reverseKey))
            {
                _dictionary[reverseKey] = new Dictionary<string, string>();
            }
            _dictionary[reverseKey][firstLang.ToLower()] = firstWord;

        }

        public void RemoveTranslation(string word, string wordLang, string targetLang)
        {
            var key = (word, wordLang);

            // Проверяем, есть ли такая запись в словаре
            if (_dictionary.TryGetValue(key, out var translations))
            {
                // Удаляем перевод на нужный язык
                translations.Remove(targetLang);

                // Если не осталось переводов удаляем всю запись
                if (translations.Count == 0)
                {
                    _dictionary.Remove(key);
                }
            }
        }

            /* Метод перевода слова
            * 1 параметр - слово, которое нужно переветси
            * 2 параметр - язык, на который нужно перевести
            * результат - переведенное слово */
            public string Translate(string word, string targetLang)
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
            return null;
        }
    }
}
