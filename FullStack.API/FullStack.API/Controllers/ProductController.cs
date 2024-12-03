using FullStack.API.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return new ProductModel[] {
                new ProductModel () { Id=1, Description = "", Name = "Produto1",
                Price = 2, Quantit = 10  },

                new ProductModel () { Id=2, Description = "", Name = "Produto2",
                Price = 2, Quantit = 10  }
            
            };
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post( ProductModel produto)
        {
            Console.WriteLine($"produto é igual a {produto.Name}");

        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, ProductModel produto)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
