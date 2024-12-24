using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using FullStack.API.Model;
using System.Data;

namespace FullStack.API.Repository
{

    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly string _connectionString;
        public CategoriaRepository(IConfiguration config)
        { 
            _connectionString = config["dbConection"];
        }
        public IEnumerable<Categoria> ObterTodos()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Categoria>("SELECT * FROM Categoria");
            }
        }

        public IEnumerable<Categoria> ObterPaginados(int pageSize, int pageNumber, string nome = null)
        {
            // Parameters for the stored procedure
            var parameters = new { Nome = nome, PageNumber = pageNumber, PageSize = pageSize };

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Categoria>("ListarCategoriaPaginado", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public Categoria ObterPorId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Categoria>("SELECT * FROM Categoria WHERE Id = @Id", new { Id = id });
            }
        }
        public void Adicionar(Categoria categoria)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("INSERT INTO Categoria (Nome) " +
                    "VALUES (@Nome)", categoria);
            }
        }
        public void Atualizar(Categoria categoria)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("UPDATE Categoria SET Nome = @Nome " +
                    "WHERE Id = @Id", categoria);
            }
        }
        public void Deletar(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("DELETE FROM Categoria WHERE Id = @Id", new { Id = id });
            }
        }

     
    }
}
