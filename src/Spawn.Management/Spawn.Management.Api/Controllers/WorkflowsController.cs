using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spawn.Management.Application.Commands;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Spawn.Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkflowsController : ControllerBase
    {
        private ISender Sender;
        public WorkflowsController(ISender sender)
        {
            Sender = sender;
        }
        // GET: api/<WorkflowsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<WorkflowsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WorkflowsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateWorkflowCommand value)
        {
            var response = await Sender.Send(value);
            return Created("localhost", response);
        }

        // PUT api/<WorkflowsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WorkflowsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
