using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Data.Sqlite;
using ProjetoCRUD.Models;
using ProjetoCRUD.Data;
using System.ComponentModel.DataAnnotations;

namespace ProjetoCRUD.Repository
{
    internal class ProdutoRepository
    {
        public void Create(Produto produto) 
        {
            using var conexao = Database.GetConnection();
            conexao.Open();

            var sql = "INSERT INTO Produtos (Nome, Preco) VALUES (@Nome, @Preco)";
            conexao.Execute(sql, produto);
        }

        public List<Produto> ShowAll() 
        {
            using var conexao = Database.GetConnection();
            conexao.Open();

            var sql = "SELECT * FROM Produtos";
            return conexao.Query<Produto>(sql).ToList();
        }

        public Produto SearchId(int id) 
        {
            using var conexao = Database.GetConnection();
            conexao.Open();

            var sql = "SELECT * FROM Produtos WHERE Id = @Id";
            return conexao.QueryFirstOrDefault<Produto>(sql, new { Id = id });
        }

        public void Update(Produto produto)
        {
            using var conexao = Database.GetConnection();
            conexao.Open();

            var sql = "UPDATE Produtos SET Name = @Name, Price = @Price WHERE Id = @Id";
            conexao.Execute(sql, produto);
        }

        public void Delete(int id)
        {
            using var conexao = Database.GetConnection();
            conexao.Open();

            var sql = "DELETE FROM Produtos WHERE Id = @Id";
            conexao.Execute(sql, new {Id = id});
        }
    }
}
