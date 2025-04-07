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
                { ("hello", "en"), new Dictionary<string, string> { { "ru", "привет" } } },
                { ("merci", "fr"), new Dictionary<string, string> { { "ru", "спасибо" } } },           
            };

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


        //todo
        //1 аргумент - 1 язык для поиска
        //2 аргумент - 2 язык для поиска
        //результат - список всех пар из словаря, совпадающих по языкам
        public List<KeyValuePair<string, string>> GetTranslationsForTwoLanguages(string sourceLang, string targetLang)
        {
            var translations = new List<KeyValuePair<string, string>>
            {
            new KeyValuePair<string, string>("привет", "hello"),
            new KeyValuePair<string, string>("мир", "world"),
            new KeyValuePair<string, string>("друзья", "friends")
            };
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
