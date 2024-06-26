using AngularApp1.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Xml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly HttpClient _client;

        public ValuesController(HttpClient client)
        {
            _client = client;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<List<User>?> Get()
        {
            List<User> result = new List<User>();
            HttpResponseMessage response = await _client.GetAsync("https://techtestpersonapi.azurewebsites.net/api/GETPersonsTechTestAPI?code=Z5Dm297Ijn9weSo75EVtsJHN9HoVE0fgJt8zIGXWV4ZOOCGNpaYBtw==");

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<List<User>>();    
            }

            return result;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{s}")]
        public string Get(string s)
        {
            return s;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
