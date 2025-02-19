﻿using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using FullStack.API.Model;
using System.Data.Common;
using System.Data;

namespace FullStack.API.Repository
{

    public class ClienteRepository : iClienteRepository
    {
        private readonly string _connectionString;
        public ClienteRepository(IConfiguration config)
        {
            _connectionString = config["dbConection"];
        }
        public IEnumerable<Cliente> ObterTodos()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Cliente>("SELECT c.Id, c.Nome, c.Email, c.Telefone FROM Cliente c");
            }
        }

        public IEnumerable<Cliente> ObterPaginados(int pageSize, int pageNumber, string nome = null)
        {
            // Parameters for the stored procedure
            var parameters = new { Nome = nome, PageNumber = pageNumber , PageSize = pageSize };


            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Cliente>("ListarClientesPaginado", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public Cliente ObterPorId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Cliente>("SELECT * FROM Cliente WHERE Id = @Id", new { Id = id });
            }
        }
        public void Adicionar(Cliente cliente)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("INSERT INTO Cliente (Nome, Email, Telefone) " +
                    "VALUES (@Nome, @Email, @Telefone)", cliente);
            }
        }
        public void Atualizar(Cliente cliente)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("UPDATE Cliente SET Nome = @Nome, Email = @Email, Telefone = @Telefone " +
                    "WHERE Id = @Id", cliente);
            }
        }
        public void Deletar(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("DELETE FROM Cliente WHERE Id = @Id", new { Id = id });
            }
        }


    }
}
