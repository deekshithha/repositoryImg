using BuildPipeEditDockerProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BuildPipeEditDockerProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IRepository<Movie> _repository;
        public MovieController(IRepository<Movie> repository)
        {
            _repository = repository;
        }
        // GET: api/<MovieController>
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            var movie = _repository.GetItems();
            if (movie.Count() == 0)
                return BadRequest("No movie added till now");
            else
                return Ok(movie);
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            var movie = _repository.GetItemId(id);
            if (movie == null)
            {
                return BadRequest("No movie in given id");
            }
            else
                return Ok(movie);
            
        }

        // POST api/<MovieController>
        [HttpPost]
        public ActionResult<Movie> Post([FromBody] Movie movie)
        {
            try
            {
                _repository.AddItem(movie);
                return Ok(movie);
            }
            catch
            {
                return BadRequest("Cannot add the item");
            }
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
