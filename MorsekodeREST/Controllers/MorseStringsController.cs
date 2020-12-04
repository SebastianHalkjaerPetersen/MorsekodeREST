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
        private static readonly List<string> MorseStrings = new List<string>()
        {
            "start string"
        };
        

            // GET: api/MorseStrings
        [HttpGet]
        public string GetLatestMorseCharacter()
        {
            return MorseStrings.Last();
        }

        // POST: api/MorseStrings
        [HttpPost]
        public void Post([FromBody] string value)
        {
            MorseStrings.Add(value);
        }

        

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            MorseStrings.RemoveAt(id);
        }

        [HttpDelete]
        public void DeleteAll()
        {
            foreach (string morseString in MorseStrings)
            {
                MorseStrings.Remove(morseString);
            }
        }
    }   
}
