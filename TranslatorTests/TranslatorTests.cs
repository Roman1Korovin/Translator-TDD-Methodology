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
        public void RemoveTranslation_ReturnsNull_AfterRemovingHelloAndPrivet()
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

    }
}
