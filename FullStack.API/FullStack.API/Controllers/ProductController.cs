using FullStack.API.Model;
using FullStack.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProdutoRepository _repository;
        public ProductController(IProdutoRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Produto> Get()
        {
          return  _repository.ObterTodos();
        }

        [Route("GetByPage")]
        [HttpGet()]
        public IEnumerable<Produto> GetByPage(int pageSize, int pageNumber, string nome = null)
        {
            return _repository.ObterPaginados(pageSize, pageNumber, nome);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Produto Get(int id)
        {
            return _repository.ObterPorId(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post( Produto produto)
        {
            if(produto.Quantidade == 0)
            {
                    return BadRequest("Quantidade deve ser maior que zero.");
            }
            _repository.Adicionar(produto);
            return Ok("Produto criado com sucesso.");
        }

        // PUT api/<ProductController>/5
        [HttpPut()]
        public IActionResult Put( Produto produto)
        {
            _repository.Atualizar(produto);
            return Ok("Produto alterado com sucesso.");
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Deletar(id);
            return Ok("Produto deletado com sucesso.");
        }
    }
}
