using ApplicationNet;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadMessageController : ControllerBase
    {
        // GET: api/<ReadMessageController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            ClassParse classParse = new ClassParse();
            classParse.ParseData();
            return new string[] { "value1", "value2" };
        }

        // GET api/<ReadMessageController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReadMessageController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReadMessageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReadMessageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
