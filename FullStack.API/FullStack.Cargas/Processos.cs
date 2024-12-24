using FullStack.Cargas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStack.Cargas
{
    public class Processos
    {
        public static void CargaProdutos ()
        {
            var Lista = File.ReadAllLines(@"d:\temp\produtos2.csv");
            int contador = 0;
            foreach (var line in Lista)
            {
                //if (contador == 0) continue;
                var colunas = line.Split(";");
                var produto = new Produto()
                {
                    Id = 0,
                    Nome = colunas[1],
                    CodigoCategoria = 1, //Convert.ToInt32(colunas[2]),
                    Preco = Convert.ToDecimal(colunas[3]),
                    Quantidade = 1 //Convert.ToInt32(colunas[4]),
                    //Descricao = colunas[5]
                };
                Helper.SalvarProduto(produto);
                Console.WriteLine("Executando linha " + contador.ToString());
                contador++;
            }
        }

        internal static void CargaCategoria()
        {
            //throw new NotImplementedException();
        }

        public static void CargaCliente()
        {
            var Lista = File.ReadAllLines(@"d:\temp\clientes.csv");
            int contador = 0;
            foreach (var line in Lista)
            {
                //if (contador == 0) continue;
                var colunas = line.Split(";");
                var cliente = new Cliente()
                {
                    Id = 0,
                    Nome = colunas[1],
                    Email = colunas[2],
                    Telefone = colunas[3],
                };
                Helper.SalvarCliente(cliente);
                Console.WriteLine("Executando linha " + contador.ToString());
                contador++;
            }
        }
    }
}
