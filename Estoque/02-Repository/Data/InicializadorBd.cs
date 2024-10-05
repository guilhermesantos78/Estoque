using Dapper;
using Estoque.Repository.Data.Script;
using System;
using System.Data.SQLite;

namespace CRUD.Repositorios.Data
{
    public static class InicializadorBd
    {
        public static void Inicializar()
        {
            using var connection = new SQLiteConnection("Data Source=ESTOQUE.db"); // Criando a conexão

            connection.Execute(DataBaseScript.CreateTables()); //Método que Executa qualquer comando SQL (Dapper)
        }
    }
}
