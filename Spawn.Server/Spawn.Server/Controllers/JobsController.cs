using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Spawn.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]

    public class JobsController : ControllerBase
    {
        // GET: api/<JobsController>
        [HttpGet]
        public IEnumerable<object> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new 
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateOnly.FromDateTime(DateTime.Now.AddDays(-index)),
                Summary = "Job Description for this job"
            }).ToArray();
        }

        // GET api/<JobsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<JobsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<JobsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JobsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
