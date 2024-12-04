using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using FullStack.API.Model;

namespace FullStack.API.Repository
{

    public class ProdutoRepository : IProdutoRepository {
        private readonly string _connectionString;
        public ProdutoRepository(IConfiguration config)
        {
         
            _connectionString = config["dbConection"];
        }
        public IEnumerable<Produto> ObterTodos() {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Produto>("SELECT * FROM Produto");
            }
        }
        public Produto ObterPorId(int id) {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Produto>("SELECT * FROM Produto WHERE Id = @Id", new { Id = id });
            }
        }
        public void Adicionar(Produto produto) {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("INSERT INTO Produto (Nome, Descricao, Preco, Quantidade) " +
                    "VALUES (@Nome, @Descricao, @Preco, @Quantidade)", produto);
            }
        }
        public void Atualizar(Produto produto) {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("UPDATE Produto SET Nome = @Nome, Descricao = @Descricao, Preco = @Preco, Quantidade = @Quantidade " +
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
