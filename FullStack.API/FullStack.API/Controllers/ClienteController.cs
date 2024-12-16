using FullStack.API.Model;
using FullStack.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace FullStack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly iClienteRepository _repository;
 
        public ClienteController(iClienteRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return _repository.ObterTodos();
        }

        [HttpGet("{id}")]
        public Cliente Get(int id)
        {
            return _repository.ObterPorId(id);
        }

        [HttpPost]
        public IActionResult Post(Cliente cliente)
        {
            _repository.Adicionar(cliente);
            return Ok("Cliente criado com sucesso.");
        }

        [HttpPut()]
        public IActionResult Put(Cliente cliente)
        {
            _repository.Atualizar(cliente);
            return Ok("Cliente alterado com sucesso.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Deletar(id);
            return Ok("Cliente deletado com sucesso.");
        }
    }
}
