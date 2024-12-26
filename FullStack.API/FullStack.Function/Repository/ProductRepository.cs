
using FullStack.Function.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStack.Function.Repository
{
    public class ProductRepository
    {
        IConfiguration _configuration;
        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public  void SalvarProduto(Produto p)
        {
            using (var db = new FullStackContext(_configuration))
            {
                db.Produto.Add(p);
                db.SaveChanges();
            }
        }

      
    }
}
