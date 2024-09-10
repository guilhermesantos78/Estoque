using Dapper;
using Dapper.Contrib.Extensions;
using Estoque.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace Estoque.Repository
{
    public class FuncionarioLogRepository
    {
        private readonly string _connectionString;

        public FuncionarioLogRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Adicionar(FuncionarioLog funcionario)
        {
            using var connection = new SQLiteConnection(_connectionString);

            string commandInsert = @"INSERT INTO FuncionariosLogin (Nome, Email, Senha)
                                    VALUES (@Nome, @Email, @Senha)";

            connection.Execute(commandInsert, funcionario);
        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexao
            FuncionarioLog novofuncionario = BuscarFuncionarioLogPorId(id);

            connection.Delete<FuncionarioLog>(novofuncionario);
        }

        public void Editar(FuncionarioLog editFuncionarioLog)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexao

            connection.Update<FuncionarioLog>(editFuncionarioLog);
        }

        public List<FuncionarioLog> Listar()
        {
            using var connection = new SQLiteConnection(_connectionString);

            return connection.GetAll<FuncionarioLog>().ToList();
        }

        public FuncionarioLog BuscarFuncionarioLogPorId(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);

            return connection.Get<FuncionarioLog>(id);
        }
    }
}
