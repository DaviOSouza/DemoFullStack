﻿namespace FullStack.WebDemo.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string? Descricao { get; set; }

        public int Quantidade {  get; set; }

        public decimal Preco {  get; set; }

        public int CodigoCategoria { get; set; }

        public string? NomeCategoria  { get; set; }
    }
}
