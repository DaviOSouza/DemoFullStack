using Dapper.Contrib.Extensions;

namespace FullStack.API.Model
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string? Descricao { get; set; }

        public decimal Preco { get; set; }

        public int Quantidade { get; set; }

        public int CodigoCategoria { get; set; }

        [Write(false)]
        public string? NomeCategoria { get; set; }




    }
}
