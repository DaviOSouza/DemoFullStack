
using FullStack.Function.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStack.Function.Repository
{
    public class ClienteRepository
    {
        IConfiguration _configuration;
        public ClienteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SalvarCliente(Cliente c)
        {
            using (var db = new FullStackContext(_configuration))
            {
                db.Cliente.Add(c);
                db.SaveChanges();
            }
        }


    }
}
