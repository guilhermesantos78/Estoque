using Estoque.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Repository.Data.Script
{
    public static class DataBaseScript
    {
<<<<<<< Updated upstream
=======
        private const string DataSource = "Data Source=estoque.db;";

        public static void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(DataSource))
            {
                connection.Open();

                string commandCREATE = CreateTables();

                // Cria as tabelas
                using (var command = new SQLiteCommand(commandCREATE, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

>>>>>>> Stashed changes
        public static string CreateTables()
        {
            string commandCREATE = @"
                CREATE TABLE IF NOT EXISTS Produtos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Preco REAL NOT NULL,
                    Descricao TEXT NOT NULL,
                    QuantidadeEmEstoque INTEGER NOT NULL,
<<<<<<< Updated upstream
                    FornecedorId INTEGER,
                    EmpresaId INTEGER
=======
                    UsuarioId INTEGER NOT NULL
>>>>>>> Stashed changes
                );

                CREATE TABLE IF NOT EXISTS Fornecedores (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Contato TEXT NOT NULL,
                    Endereco TEXT NOT NULL,
                    CNPJ TEXT NOT NULL,
                    ProdutoId INTEGER,
                    EmpresaId INTEGER
                );

               CREATE TABLE IF NOT EXISTS Usuarios(
                 Id INTEGER PRIMARY KEY AUTOINCREMENT,
                 Nome TEXT NOT NULL,
                 Username TEXT NOT NULL,
                 TipoUsuario TEXT NOT NULL,
                 Senha TEXT NOT NULL,
                 Email TEXT NOT NULL,
                 EmpresaId INTEGER
                );

               CREATE TABLE IF NOT EXISTS Empresas(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Contato TEXT NOT NULL,
                    Endereco TEXT NOT NULL,
                    CNPJ TEXT NOT NULL
                );
                
                CREATE TABLE IF NOT EXISTS Pedidos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    DataPedido DATE NOT NULL,
                    DataEntrega DATE NOT NULL,
                    QuantidadeSolicitada INTEGER NOT NULL,
                    TipoAlteracao TEXT NOT NULL,
                    NomeProduto TEXT NOT NULL,
<<<<<<< Updated upstream
                    ProdutoId INTEGER,
                    EmpresaId INTEGER
=======
                    ProdutoId INTEGER NOT NULL,
                    UsuarioId INTEGER NOT NULL
>>>>>>> Stashed changes
                );

                CREATE TABLE IF NOT EXISTS HistoricoPedidos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    DataPedido DATE NOT NULL,
                    DataEntrega DATE NOT NULL,
                    QuantidadeSolicitada INTEGER NOT NULL,
                    TipoAlteracao TEXT NOT NULL,
                    NomeProduto TEXT NOT NULL,
                    ProdutoId INTEGER,
<<<<<<< Updated upstream
                    EmpresaId INTEGER
                );";

            return commandCREATE;
=======
                    UsuarioId INTEGER NOT NULL
                );";
>>>>>>> Stashed changes
        }
    }
}
