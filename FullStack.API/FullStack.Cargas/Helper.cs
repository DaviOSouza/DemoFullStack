using FullStack.Cargas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStack.Cargas
{
    public class Helper
    {
        public static void SalvarProduto(Produto p)
        {
            using (var db = new FullStackContext())
            {
                db.Produto.Add(p);
                db.SaveChanges();
            }
        }

        public static void SalvarCliente(Cliente c)
        {
            using (var db = new FullStackContext())
            {
                db.Cliente.Add(c);
                db.SaveChanges();
            }
        }
    }
}
