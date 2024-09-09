using Dapper;
using System;
using System.Data.SQLite;

namespace CRUD._02___Repositorios.Data
{
    public static class InicializadorBd
    {
        public static void Inicializar()
        {
            using var connection = new SQLiteConnection("Data Source=ESTOQUE.db"); // Criando a conexão

            string criarTabela = @"
                CREATE TABLE IF NOT EXISTS Produtos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Preco REAL NOT NULL,
                    Descricao TEXT NOT NULL,
                    QuantidadeEmEstoque INTEGER NOT NULL,
                    FornecedorId INTEGER,
                    FOREIGN KEY (FornecedorId) REFERENCES Fornecedores(Id)
                );
                CREATE TABLE IF NOT EXISTS Fornecedores (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Contato TEXT NOT NULL,
                    Endereco TEXT NOT NULL,
                    CNPJ TEXT NOT NULL
                );
                CREATE TABLE IF NOT EXISTS FuncionariosLogin(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Email TEXT NOT NULL,
                    Senha TEXT NOT NULL
                ); ";

            connection.Execute(criarTabela); //Método que Executa qualquer comando SQL (Dapper)
        }
    }
}
