using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MorsekodeREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MorseStringsController : ControllerBase
    {
        private static Dictionary<string, string> MorseStrings = new Dictionary<string, string>()
        {
            {"A", ".-"},
            {"B", "-..."},
            {"C", "-.-."},
            {"D", "-.."},
            {"E", "."},
            {"F", "..-."},
            {"G", "--."},
            {"H", "...."},
            {"I", ".."},
            {"J", ".---"},
            {"K", "-.-"},
            {"L", ".-.."},
            {"M", "--"},
            {"N", "-."},
            {"O", "---"},
            {"P", ".--."},
            {"Q", "--.-"},
            {"R", ".-."},
            {"S", "..."},
            {"T", "-"},
            {"U", "..-"},
            {"V", "...-"},
            {"W", ".--"},
            {"X", "-..-"},
            {"Y", "-.--"},
            {"Z", "--.."},
            {"1", ".----"},
            {"2", "..---"},
            {"3", "...--"},
            {"4", "....-"},
            {"5", "....."},
            {"6", "-...."},
            {"7", "--..."},
            {"8", "---.."},
            {"9", "----."},
            {"0", "-----"},
        };
        private TranslateWorker worker = new TranslateWorker();
       
        

            // GET: api/MorseStrings
        [HttpGet]
        public string GetLatestTranslationCharacter()
        {
            if (MorseStrings.Count < 1)
            {
                return "no input saved";
            }
            return MorseStrings.Last().Key;
        }

        //GET: api/MorseStrings/id
        [HttpGet("{text}", Name = "Get")]
        public string GetMorseFromText(string text)
        {
            if (MorseStrings.Count < 1)
            {
                return "no input saved";
            }

            if (text.Contains(".") || text.Contains("-"))
            {
                if (MorseStrings.Values.Contains(text))
                {
                    return MorseStrings.FirstOrDefault(x => x.Value == text).Key;
                }

                return "ugyldigt input";
            }

            return MorseStrings[text.ToUpper()];


        }

        // POST: api/MorseStrings
        [HttpPost]
        public void Post([FromBody] string value)
        {
            MorseStrings.Add(value, worker.GetTranslation(value).ToString());
        }

        

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            MorseStrings.Remove(id);
        }

        [HttpDelete]
        public void DeleteAll()
        {
            while (MorseStrings.Count > 36)
            {
                MorseStrings.Remove(MorseStrings.Last().Key);
            }

        }
    }   
}
