using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET_Calculator.Model;
using RestWithASPNET_Calculator.Services;
using RestWithASPNET_Calculator.Services.Implementations;

namespace RestWithASPNET_Calculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
           return Ok(_personService.FindAll());
        }

        [HttpGet("{personId}")]
        public IActionResult Get(long personId)
        {
            var person = _personService.FindById(personId);
            if (person == null) return NotFound();
            return Ok(person);
        }        
        
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Create(person));
        }        
        
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Update(person));
        }

        [HttpDelete("{personId}")]
        public IActionResult Delete(long personId)
        {
            _personService.Delete(personId);
            return NoContent();
        }
    }
}
    