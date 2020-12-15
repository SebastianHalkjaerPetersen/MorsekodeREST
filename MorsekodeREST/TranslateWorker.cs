using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MorsekodeREST
{
    public class TranslateWorker
    {
        private const string baseURI = "tba";//"http://morsecodeapi.azurewebsites.net/swagger/index.html";
        

        public async Task<string> GetTranslation(string morse)
        {
            string output = await TranslateMorse(morse);
            return output;
        }

         private async Task<string> TranslateMorse(string morse)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(baseURI + $"/{morse}");
                string translation = JsonConvert.DeserializeObject<string>(content);
                return translation;

            }

        }
    }
}
