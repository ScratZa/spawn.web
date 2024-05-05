using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;
using Microsoft.Identity.Web.Resource;
using Spawn.Management.Application.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Spawn.Management.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class JobsController : ControllerBase
    {
        // GET: api/<JobsController>
        [HttpGet]
        public IEnumerable<object> Get()
        {
            return Enumerable.Range(1,5)
                    .Select( _ => new
                    {
                        Id = Guid.NewGuid().ToString(),
                        createdAt = DateTime.UtcNow.AddDays(-1),
                        summary = "value1"
                    }
                    ).ToList();
            
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
