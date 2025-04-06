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
    [Fact]
    public void AddTranslation_HlebAndBread_TranslateFromRussianToEnglish()
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
}
