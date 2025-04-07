using System;
using System.Collections.Generic;

namespace TranslatorApp
{
    class Program
    {
        // Переменные для текущего и целевого языка
        private static string currentLang = "ru"; // Язык по умолчанию
        private static string targetLang = "en";  // Целевой язык по умолчанию


        static void outputWelcome()
        {
            Console.WriteLine("Добро пожаловать в переводчик!");

            Console.WriteLine($"Текущий язык: '{currentLang}'\nЦелевой язык: '{targetLang}");
        }

        static void Main(string[] args)
        {
            var translator = new Translator.Translator();

            // Добро пожаловать
            outputWelcome();
            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Перевести слово");
                Console.WriteLine("2. Добавить новый перевод");
                Console.WriteLine("3. Удалить перевод");
                Console.WriteLine("4. Показать переводы между текущим и целевым языком");
                Console.WriteLine("5. Изменить текущий или целевой язык");
                Console.WriteLine("6. Выйти");
                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        // Перевод
                        Console.Clear();
                        outputWelcome();
                        Console.WriteLine("\nВведите слово для перевода:");
                        var wordToTranslate = Console.ReadLine();

                        var translation = translator.Translate(wordToTranslate, targetLang);
                        if (translation != null)
                        {
                            Console.WriteLine($"Перевод слова '{wordToTranslate}' с {currentLang} на {targetLang}: {translation}");
                        }
                        else
                        {
                            Console.WriteLine("Перевод не найден.");
                        }
                        break;

                    case ConsoleKey.D2:
                        // Добавление нового перевода
                        Console.Clear();
                        outputWelcome();
                        Console.WriteLine("\nВведите первое слово для перевода:");
                        var firstWord = Console.ReadLine();

                        Console.WriteLine("Введите второе слово (перевод):");
                        var secondWord = Console.ReadLine();

                        // Добавляем новый перевод, используя текущий и целевой язык
                        translator.AddTranslation(firstWord, currentLang, secondWord, targetLang);
                        Console.WriteLine($"Перевод {firstWord} на {targetLang} добавлен.");
                        break;

                    case ConsoleKey.D3:
                        // Удаление перевода
                        Console.Clear();
                        outputWelcome();
                        Console.WriteLine("\nВведите слово для удаления:");
                        var wordToRemove = Console.ReadLine();

                        // Удаляем перевод, используя текущий и целевой язык
                        translator.RemoveTranslation(wordToRemove, currentLang, targetLang);
                        Console.WriteLine("Перевод удален.");
                        break;


                    case ConsoleKey.D4:
                        // Показать переводы между текущим и целевым языком
                        Console.Clear();
                        outputWelcome();
                        var translations = translator.GetTranslationsForTwoLanguages(currentLang, targetLang);

                        if (translations.Count > 0)
                        {
                            Console.WriteLine($"\nПереводы с {currentLang} на {targetLang}:");
                            foreach (var pair in translations)
                            {
                                Console.WriteLine($"{pair.Key} -> {pair.Value}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Переводов не найдено.");
                        }
                        break;

                    case ConsoleKey.D5:
                        // Смена языков
                        Console.Clear();
                        outputWelcome();

                        Console.WriteLine("Введите новый текущий язык:");
                        currentLang = Console.ReadLine();

                        Console.WriteLine("Введите новый целевой язык:");
                        targetLang = Console.ReadLine();

                        Console.Clear();
                        outputWelcome();

                        break;

                    case ConsoleKey.D6:
                        // Выход
                        Console.WriteLine("Спасибо за использование переводчика!");
                        return;

                    default:
                        Console.WriteLine("Неверный выбор, попробуйте снова.");
                        break;
                }
            }
        }
    }
}