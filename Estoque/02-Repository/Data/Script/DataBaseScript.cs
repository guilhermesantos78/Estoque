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
        public static string CreateTables()
        {
            string commandCREATE = @"
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
                ); 
                
                CREATE TABLE IF NOT EXISTS Pedidos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    DataPedido DATE NOT NULL,
                    DataEntrega DATE NOT NULL,
                    QuantidadeSolicitada INTEGER NOT NULL,
                    TipoAlteracao TEXT NOT NULL,
                    NomeProduto TEXT NOT NULL,
                    ProdutoId INTEGER,
                    FOREIGN KEY (ProdutoId) REFERENCES Produtos(Id)
                );

                 CREATE TABLE IF NOT EXISTS HistoricoPedidos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    DataPedido DATE NOT NULL,
                    DataEntrega DATE NOT NULL,
                    QuantidadeSolicitada INTEGER NOT NULL,
                    TipoAlteracao TEXT NOT NULL,
                    NomeProduto TEXT NOT NULL,
                    ProdutoId INTEGER,
                    FOREIGN KEY (ProdutoId) REFERENCES Produtos(Id)
                );"; // Comando para criar as tabelas no banco

            return commandCREATE;
        }
    }
}
