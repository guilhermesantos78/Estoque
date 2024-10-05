﻿using Dapper;
using Dapper.Contrib.Extensions;
using Estoque.Entidades;
using System.Data.SQLite;

namespace Estoque.Repository
{
    public class FornecedorRepository
    {
        public readonly string _connectionString; //Variável de connection string a ser preenchida


        public FornecedorRepository( string ConnectionString) //Responsavel por preencher a connection string
        {
            _connectionString = ConnectionString;
        }

        public void Adicionar(Fornecedor fornecedor)
        {
            using var connection = new SQLiteConnection(_connectionString);

            connection.Execute(FornecedorScript.InsertFornecedor(), fornecedor);
        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexao
            Fornecedor novoFornecedor = BuscarFornecedorPorId(id);

            connection.Delete<Fornecedor>(novoFornecedor);
        }

        public void Editar(Fornecedor editFornecedor)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexao

            connection.Update<Fornecedor>(editFornecedor);
        }

        public List<Fornecedor> Listar()
        {
            using var connection = new SQLiteConnection(_connectionString);// conexao

            return connection.GetAll<Fornecedor>().ToList();
        }

        public Fornecedor BuscarFornecedorPorId(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);

            return connection.Get<Fornecedor>(id);
        }

        public ReadFornecedorDTO BuscarFornecedorNamePorId(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            var query = "SELECT Id, Nome FROM Fornecedores WHERE Id = @Id";

            var fornecedor = connection.QuerySingleOrDefault<ReadFornecedorDTO>(query, new { Id = id });

            return fornecedor;
        }

        //public ReadFornecedorDTO BuscarFornecedorNamePorId(int id)
        //{
        //    using var connection = new SQLiteConnection(_connectionString);
        //    Fornecedor f = connection.Get<Fornecedor>(id);

        //    ReadFornecedorDTO fornecedor = mapper.Map<ReadFornecedorDTO>(f);

        //    return fornecedor;
        //}

    }
}
