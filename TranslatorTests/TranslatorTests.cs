namespace Translator.Tests
{
    public class TranslatorTests
    {
        [Fact]
        public void TranslatorClass_CanBeCreated()
        {
            var translator = new Translator();
            Assert.NotNull(translator);
        }
    }

    public class TranslateTests
    {
        [Fact]
        public void Translate_ReturnsHello_WhenInputIsPrivetAndLanguageIsEnglish()
        {
            var translator = new Translator();

            string result = translator.Translate("привет", "en");

            Assert.Equal("hello", result);
        }

        [Fact]
        public void Translate_ReturnsSpasibo_WhenInputIsMerciAndLanguageIsFrance()
        {
            var translator = new Translator();

            string result = translator.Translate("merci", "ru");

            Assert.Equal("спасибо", result);
        }
    }
    public class AddTranslatationTests
    {
        [Fact]
        public void AddTranslation_ReturnsEnglishWord_WhenRussianTranslationExists()
        {
            // Arrange
            var translator = new Translator();

            string ruWord = "хлеб";
            string ruLanguage = "ru";

            string enWord = "bread";
            string enLanguage = "en";


            // Act
            translator.AddTranslation(ruWord, ruLanguage, enWord, enLanguage);
            string translatedInEn = translator.Translate(ruWord, enLanguage);

            // Assert
            Assert.Equal(enWord, translatedInEn);
        }

        [Fact]
        public void AddTranslation_ReturnsRussianWord_WhenEnglishTranslationExists()
        {
            // Arrange
            var translator = new Translator();

            string ruWord = "хлеб";
            string ruLanguage = "ru";

            string enWord = "bread";
            string enLanguage = "en";


            // Act
            translator.AddTranslation(ruWord, ruLanguage, enWord, enLanguage);
            string translatedInRu = translator.Translate(enWord, ruLanguage);

            // Assert
            Assert.Equal(ruWord, translatedInRu);
        }
    }

    public class RemoveTranslatationTests
    {
        [Fact]
        public void RemoveTranslation_ReturnsNull_ForForwardTranslate_AfterRemovingHelloAndPrivet()
        {
            // Arrange
            var translator = new Translator();
            var word = "hello";
            var wordLang = "en";
            var translationLang = "ru";

            // Act
            translator.RemoveTranslation(word, wordLang, translationLang);
            var result = translator.Translate(word, translationLang);

            // Assert
            Assert.Null(result);
        }
        [Fact]
        public void RemoveTranslation_ReturnsNull_ForReverseTranslate_AfterRemovingHelloAndPrivet()
        {
            // Arrange
            var translator = new Translator();        
            var word = "hello";
            var wordLang = "en";
            var translationWord = "привет";
            var translationLang = "ru";

            // Act
            translator.RemoveTranslation(word, wordLang, translationLang);
            var result = translator.Translate(translationWord, wordLang);

            // Assert
            Assert.Null(result);
        }

    }
    public class ShowAllTranslationsTests
    {
        [Fact]
        public void GetTranslationListForTwoLanguages_ReturnsCorrectList()
        {
            // Arrange
            var translator = new Translator();

            // Act
            List<KeyValuePair<string, string>> translations = translator.GetTranslationsForTwoLanguages("ru", "en");

            // Assert
            Assert.Equal(3, translations.Count);  // Убедимся, что вернулся список из 3 слов
            Assert.Contains(translations, t => t.Key == "привет" && t.Value == "hello");
            Assert.Contains(translations, t => t.Key == "мир" && t.Value == "world");
            Assert.Contains(translations, t => t.Key == "друзья" && t.Value == "friends");
        }
    }
}
