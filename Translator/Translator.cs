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
#if DEBUG // Код для тестов будет компилироваться только в режиме отладки
        _dictionary = new Dictionary<(string word, string lang), Dictionary<string, string>>
        {
            { ("привет", "ru"), new Dictionary<string, string> { { "en", "hello" } } },
            { ("мир", "ru"), new Dictionary<string, string> { { "en", "world" } } },
            { ("друзья", "ru"), new Dictionary<string, string> { { "en", "friends" } } },
            { ("hello", "en"), new Dictionary<string, string> { { "ru", "привет" } } },
            { ("merci", "fr"), new Dictionary<string, string> { { "ru", "спасибо" } } },
        };
#else
            // Инициализация для Release 
            _dictionary = new Dictionary<(string word, string lang), Dictionary<string, string>>();
#endif
        }


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



        public List<KeyValuePair<string, string>> GetListTranslationsForTwoLanguages(string sourceLang, string targetLang)
        {
            var translations = new List<KeyValuePair<string, string>>();


            foreach (var entry in _dictionary)
            {
                // Проверяем, что текущее слово на sourceLang имеет перевод на targetLang
                if (entry.Key.lang == sourceLang.ToLower() && entry.Value.ContainsKey(targetLang.ToLower()))
                {
                    // Добавляем пару слов в результат
                    translations.Add(new KeyValuePair<string, string>(entry.Key.word, entry.Value[targetLang.ToLower()]));
                }
            }

            return translations;
        }

        public void RemoveTranslation(string word, string wordLang, string targetLang)
        {
            var key = (word.ToLower(), wordLang.ToLower());  // Ключ для прямого перевода
            var reverseKey = (Translate(word, targetLang.ToLower()), targetLang.ToLower());  // Ключ для обратного перевода

            // Проверяем, есть ли такая запись в словаре
            if (_dictionary.TryGetValue(key, out var translations))
            {
                // Удаляем перевод на нужный язык
                translations.Remove(targetLang.ToLower());

                // Если не осталось переводов, удаляем всю запись
                if (translations.Count == 0)
                {
                    _dictionary.Remove(key);
                }
            }

            // Обратное удаление
            if (_dictionary.TryGetValue(reverseKey, out var reverseTranslations))
            {
                reverseTranslations.Remove(wordLang.ToLower());

                if (reverseTranslations.Count == 0)
                {
                    _dictionary.Remove(reverseKey);
                }
            }
        }


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
