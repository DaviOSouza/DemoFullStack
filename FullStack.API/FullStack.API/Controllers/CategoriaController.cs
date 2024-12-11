using FullStack.API.Model;
using FullStack.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _repository;
        public CategoriaController(ICategoriaRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<CategoriaController>
        [HttpGet]
        public IEnumerable<Categoria> Get()
        {
          return  _repository.ObterTodos();
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public Categoria Get(int id)
        {
            return _repository.ObterPorId(id);
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public IActionResult Post(Categoria categoria)
        {
            _repository.Adicionar(categoria);
            return Ok("Categoria criada com sucesso.");
        }

        // PUT api/<CategoriaController>/5
        [HttpPut()]
        public IActionResult Put(Categoria categoria)
        {
            _repository.Atualizar(categoria);
            return Ok("Categoria alterada com sucesso.");
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Deletar(id);
            return Ok("Categoria deletada com sucesso.");
        }
    }
}
