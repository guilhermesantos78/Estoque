using System;
using System.Data.SQLite;

namespace CRUD._02___Repositorios.Data
{
    public static class InicializadorBd
    {
        private const string ConnectionString = "Data Source=ESTOQUE.db";

        public static void Inicializar()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                // Comando SQL para criar as tabelas
                string commandCREATE = @"
                CREATE TABLE IF NOT EXISTS Fornecedores (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Contato TEXT NOT NULL,
                    Endereco TEXT NOT NULL,
                    CNPJ TEXT NOT NULL
                );";

                commandCREATE += @"
                CREATE TABLE IF NOT EXISTS Produtos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Preco REAL NOT NULL,
                    Descricao TEXT NOT NULL,
                    QuantidadeEmEstoque INTEGER NOT NULL,
                    FornecedorId INTEGER,
                    FOREIGN KEY (FornecedorId) REFERENCES Fornecedores(Id)
                );";

                // Executa o comando para criar as tabelas
                using (var command = new SQLiteCommand(commandCREATE, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
