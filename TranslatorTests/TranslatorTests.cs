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

            string result = translator.Translate("merci", "fr");

            Assert.Equal("спасибо", result);
        }
    }
}
