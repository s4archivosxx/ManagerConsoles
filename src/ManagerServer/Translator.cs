using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ManagerServer
{
    public class Translator : IDisposable
    {
        private readonly WebClient _webClient;
        private readonly int _subIndex;
        private readonly string _subString;
        private readonly StringComparison _comparasion;
        private string _fromLanguage;
        private string _toLanguage;

        public static Translator This { get; private set; }

        public Translator()
        {
            _subIndex = 4;
            _subString = "\"";
            _comparasion = StringComparison.Ordinal;
            _webClient = new WebClient { Encoding = Encoding.UTF8 };
            This = this;
        }

        public Translator DefaultLanguage()
        {
            _fromLanguage = "es";
            _toLanguage = "en";
            return this;
        }

        public Translator AssignateLanguage(string fromLanguage, string toLanguage)
        {
            _fromLanguage = fromLanguage;
            _toLanguage = toLanguage;
            return this;
        }

        public string GetText(string toLanguage, string text)
        {
            _toLanguage = toLanguage;
            var result = _webClient.DownloadString(this.GetUrl(text));
            return this.ConvertResult(result);
        }

        public string GetText(string fromLanguage, string toLanguage, string text)
        {
            _fromLanguage = fromLanguage;
            _toLanguage = toLanguage;
            var result = _webClient.DownloadString(this.GetUrl(text));
            return this.ConvertResult(result);
        }

        public string GetKoreanText(string text)
        {
            _toLanguage = "ko";
            var result = _webClient.DownloadString(this.GetUrl(text));
            return this.ConvertResult(result);
        }

        public string GetDefaultText(string text)
        {
            var result = _webClient.DownloadString(this.GetUrl(text));
            return this.ConvertResult(result);
        }

        private string ConvertResult(string result)
        {
            return result.Substring(_subIndex, result.IndexOf(_subString, _subIndex, _comparasion) - _subIndex);
        }

        private string GetUrl(string text)
        {
            return $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={_fromLanguage}&tl={_toLanguage}&dt=t&q={text}";
        }

        public void Dispose()
        {
            _webClient.Dispose();
        }
    }
}
