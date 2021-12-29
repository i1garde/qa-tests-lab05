using HtmlAgilityPack;
using NUnit.Framework;
using System.Text;

namespace Komarenko.QA.Tests
{
    public class Tests
    {
        private HtmlDocument _document;
        [SetUp]
        public void Setup()
        {
            _document = new HtmlWeb() { OverrideEncoding = Encoding.UTF8 }
                .Load("https://getakka.net/articles/intro/what-is-akka.html", "GET");
        }
        [Test]
        public void Test1()
        {
            var expected_article = "What Is Akka.NET?";
            var article =
                _document.DocumentNode.SelectSingleNode("//article[@id='_content']//h1");
            Assert.AreEqual(expected_article, article.InnerText.Trim());
        }
        [Test]
        public void Test2()
        {
            var expected_article = "What Is the Actor Model?";
            var article =
            _document.DocumentNode.SelectSingleNode("//article[@id='_content']//h2");
            Assert.AreEqual(expected_article, article.InnerText.Trim());
        }
        [Test]
        public void Test3()
        {
            var expected_nav = "In This Article";
            var nav =
                _document.DocumentNode.SelectSingleNode("//nav[@id='affix']//h5");
            Assert.AreEqual(expected_nav, nav.InnerText.Trim());
        }
    }
}