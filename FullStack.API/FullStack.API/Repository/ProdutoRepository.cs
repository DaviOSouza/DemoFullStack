using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using FullStack.API.Model;

namespace FullStack.API.Repository
{

    public class ProdutoRepository : IProdutoRepository {
        private readonly string SqlConsultaProduto = "SELECT p.Id, p.Nome, p.Descricao, p.Preco, p.Quantidade, p.CodigoCategoria, c.Nome as NomeCategoria FROM Produto p JOIN Categoria c ON p.CodigoCategoria = c.Id";
        private readonly string _connectionString;
        public ProdutoRepository(IConfiguration config)
        {
         
            _connectionString = config["dbConection"];
        }
        public IEnumerable<Produto> ObterTodos() {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Produto>(SqlConsultaProduto);
            }
        }
        public Produto ObterPorId(int id) {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Produto>($"{SqlConsultaProduto} WHERE p.Id = @Id", new { Id = id });
            }
        }
        public void Adicionar(Produto produto) {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("INSERT INTO Produto (Nome, Descricao, Preco, Quantidade, CodigoCategoria) " +
                    "VALUES (@Nome, @Descricao, @Preco, @Quantidade, @CodigoCategoria)", produto);
            }
        }
        public void Atualizar(Produto produto) {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("UPDATE Produto SET Nome = @Nome, Descricao = @Descricao, Preco = @Preco, Quantidade = @Quantidade, CodigoCategoria = @CodigoCategoria " +
                    "WHERE Id = @Id", produto);
            }
        }
        public void Deletar(int id) {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("DELETE FROM Produto WHERE Id = @Id", new { Id = id });
            }
        }
    }
}
