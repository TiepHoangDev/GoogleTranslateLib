using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTranslateLib
{
    public class Translate
    {
        public static async Task<TranslateResponse> TranslateText(string input, lang lang_input = lang.en, lang lang_output = lang.vi)
        {
            var _res = new TranslateResponse();
            try
            {
                HttpClient client = new HttpClient();
                string sl = "auto";
                string tl = lang_output.ToString().Replace("_", "-");
                string hl = lang_input.ToString().Replace("_", "-");
                string url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={sl}&tl={tl}&hl={hl}&dt=t&dt=bd&dj=1&source=input&tk=501776.501776&q={input}";
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var text = await response.Content.ReadAsStringAsync();
                    var TranslateResult = JsonConvert.DeserializeObject<TranslateResult>(text);
                    _res.IsSuccess = true;
                    _res.Result = TranslateResult;
                    _res.Response = text;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GoogleTranslateLib.Translate [error] = " + ex);
                _res.IsSuccess = false;
                _res.Exception = ex;
                _res.MessageError = ex.Message;
            }
            return _res;
        }

        public static Dictionary<lang, string> GetLangusges()
        {
            Dictionary<lang, string> _res = new Dictionary<lang, string>();
            var type = typeof(lang);
            foreach (lang item in Enum.GetValues(type))
            {
                string description = type.GetField(item.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true).Cast<DescriptionAttribute>().First().Description;
                _res.Add(item, description);
            }
            return _res;
        }
    }


}
