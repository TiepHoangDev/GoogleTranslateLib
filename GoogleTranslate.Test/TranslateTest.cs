using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoogleTranslateLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleTranslate.Test
{
    [TestClass]
    public class TranslateTest
    {
        async Task _testInOut(lang lang_input, string input, lang lang_output, string output)
        {
            Assert.AreEqual(output, (await Translate.TranslateText(input, lang_input, lang_output)).Result.sentences[0].trans);
        }

        [TestMethod]
        public async Task Testko()
        {
            await _testInOut(lang.ko, "안녕하세요.", lang.vi, "xin chào");
        }

        [TestMethod]
        public async Task Testja()
        {
            await _testInOut(lang.ja, "こんにちは", lang.vi, "xin chào");

        }

        [TestMethod]
        public async Task Testen()
        {
            await _testInOut(lang.en, "hello", lang.vi, "xin chào");

        }

        [TestMethod]
        public async Task Testit()
        {
            await _testInOut(lang.it, "ciao", lang.vi, "xin chào");

        }

        [TestMethod]
        public async Task Testlo()
        {
            await _testInOut(lang.lo, "ສະບາຍດີ", lang.vi, "xin chào");

        }
    }
}
