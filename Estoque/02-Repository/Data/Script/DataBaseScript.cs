using System;
using System.Data.SQLite;

namespace Estoque.Repository
{
    public static class DataBaseScript
    {
        private const string DataSource = "Data Source=estoque.db;Version=3;";

        public static void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(DataSource))
            {
                try
                {
                    connection.Open();

                    string commandCREATE = CreateTables();

                    // Cria as tabelas
                    using (var command = new SQLiteCommand(commandCREATE, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Verifica e insere fornecedores e produtos
                    InsertFornecedoresIfNotExists(connection);
                    InsertProdutosIfNotExists(connection);

                    Console.WriteLine("Tabelas criadas e dados inseridos (se não existiam) com sucesso.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao inicializar o banco de dados: {ex.Message}");
                }
            }
        }

        public static string CreateTables()
        {
            return @"
                CREATE TABLE IF NOT EXISTS Produtos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Preco REAL NOT NULL,
                    Descricao TEXT NOT NULL,
                    QuantidadeEmEstoque INTEGER NOT NULL,
                    FornecedorId INTEGER,
                    UsuarioId INTEGER NOT NULL,
                    FOREIGN KEY (FornecedorId) REFERENCES Fornecedores(Id)
                );

                CREATE TABLE IF NOT EXISTS Fornecedores (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Contato TEXT NOT NULL,
                    Endereco TEXT NOT NULL,
                    CNPJ TEXT NOT NULL,
                    UsuarioId INTEGER NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Usuarios(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Username TEXT NOT NULL,
                    Senha TEXT NOT NULL,
                    Email TEXT NOT NULL
                );
                
                CREATE TABLE IF NOT EXISTS Pedidos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    DataPedido DATE NOT NULL,
                    DataEntrega DATE NOT NULL,
                    QuantidadeSolicitada INTEGER NOT NULL,
                    TipoAlteracao TEXT NOT NULL,
                    NomeProduto TEXT NOT NULL,
                    ProdutoId INTEGER NOT NULL,
                    UsuarioId INTEGER NOT NULL,
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
                    UsuarioId INTEGER NOT NULL,
                    FOREIGN KEY (ProdutoId) REFERENCES Produtos(Id)
                );";
        }

        public static void InsertFornecedoresIfNotExists(SQLiteConnection connection)
        {
            string[] fornecedores = {
                "('João Silva', 'joao@silva.com', 'Rua das Flores, 123', '11.111.111/0001-11', 1)",
                "('Maria Oliveira', 'maria@oliveira.com', 'Avenida Central, 456', '22.222.222/0001-22', 1)",
                "('Carlos Almeida', 'carlos@almeida.com', 'Praça da Liberdade, 789', '33.333.333/0001-33', 1)"
            };

            foreach (var fornecedor in fornecedores)
            {
                string checkQuery = "SELECT COUNT(1) FROM Fornecedores WHERE CNPJ = @CNPJ";
                string insertQuery = $"INSERT INTO Fornecedores (Nome, Contato, Endereco, CNPJ, UsuarioId) VALUES {fornecedor}";

                string cnpj = fornecedor.Split(',')[3].Trim('\'', ' '); // Extrai o CNPJ

                using (var command = new SQLiteCommand(checkQuery, connection))
                {
                    command.Parameters.AddWithValue("@CNPJ", cnpj);
                    var count = Convert.ToInt32(command.ExecuteScalar());

                    if (count == 0)
                    {
                        // Se o fornecedor não existir, insere
                        using (var insertCommand = new SQLiteCommand(insertQuery, connection))
                        {
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public static void InsertProdutosIfNotExists(SQLiteConnection connection)
        {
            string[] produtos = {
                "('iPhone 13', 6999.90, 'Smartphone da Apple com 128GB de armazenamento', 15, 1, 1)",
                "('Notebook Dell Inspiron', 3499.90, 'Notebook Dell com processador Intel i5 e 8GB de RAM', 30, 2, 1)",
                "('Smart TV Samsung 50', 2799.90, 'Smart TV LED Samsung com 50 polegadas e resolução 4K', 20, 3, 1)",
                "('Fone de Ouvido JBL', 199.90, 'Fone de ouvido Bluetooth JBL', 100, 1, 1)",
                "('Monitor LG 24', 899.90, 'Monitor LG de 24 polegadas Full HD', 25, 2, 1)",
                "('Geladeira Brastemp Frost Free', 3599.90, 'Geladeira Brastemp Frost Free com 400 litros', 10, 3, 1)"
            };

            foreach (var produto in produtos)
            {
                string checkQuery = "SELECT COUNT(1) FROM Produtos WHERE Nome = @Nome";
                string insertQuery = $"INSERT INTO Produtos (Nome, Preco, Descricao, QuantidadeEmEstoque, FornecedorId, UsuarioId) VALUES {produto}";

                string nomeProduto = produto.Split(',')[0].Trim('\'', ' '); // Extrai o nome do produto

                using (var command = new SQLiteCommand(checkQuery, connection))
                {
                    command.Parameters.AddWithValue("@Nome", nomeProduto);
                    var count = Convert.ToInt32(command.ExecuteScalar());

                    if (count == 0)
                    {
                        // Se o produto não existir, insere
                        using (var insertCommand = new SQLiteCommand(insertQuery, connection))
                        {
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}
