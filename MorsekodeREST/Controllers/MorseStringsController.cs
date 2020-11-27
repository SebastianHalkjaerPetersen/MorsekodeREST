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
        private static readonly List<string> MorseStrings = new List<string>();

            // GET: api/MorseStrings
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return MorseStrings.
        }

        // GET: api/MorseStrings/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MorseStrings
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/MorseStrings/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
