using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.IO;

namespace ProjetoCRUD.Data
{
    internal class Database
    {
        private const string BaseName = "database.db";
        private const string ProductTable = "CREATE TABLE Produtos (Id INTEGER PRIMARY KEY AUTOINCREMENT, Nome TEXT NOT NULL, Preco REAL NOT NULL);";

        public static SqliteConnection GetConnection()
        {
            return new SqliteConnection($"Data Source={BaseName}");
        }

        public static void BaseBoot()
        {
            using var conexao = GetConnection();
            conexao.Open();

            var comandoVerificacao = conexao.CreateCommand();
            comandoVerificacao.CommandText = "PRAGMA table_info(Produtos);";
            using var reader = comandoVerificacao.ExecuteReader();

            if (!reader.HasRows)
            {
                using var comando = conexao.CreateCommand();
                comando.CommandText = ProductTable;
                comando.ExecuteNonQuery();
            }
        }
    }
}
