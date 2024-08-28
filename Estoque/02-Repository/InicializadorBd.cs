﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD._02___Repositorios.Data
{
    public static class InicializadorBd
    {
        private const string ConnectionString = "Data Source=ESTOQUE.db"; // ConnectionString (Parâmetros necessários para criar um banco de dados)
        // Caso não exista o banco de dados, a var connection cria um database automaticamente

        public static void Inicializar()
        {
            using (var connection = new SQLiteConnection(ConnectionString)) // Criando a conexão
            {
                connection.Open();

                string commandCREATE = @"
                CREATE TABLE IF NOT EXISTS Produtos(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Preco REAL NOT NULL,
                    Descricao TEXT NOT NULL,
                    QuantidadeEmEstoque INTEGER NOT NULL,
                    FornecedorId INTEGER NOT NULL

                );
                CREATE TABLE IF NOT EXISTS Fornecedores(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Contato TEXT NOT NULL,
                    Endereco TEXT NOT NULL,
                    CNPJ TEXT NOT NULL,

                );";

                // Criando a tabela no banco se não existir

                using (var command = new SQLiteCommand(commandCREATE, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
