using Core.Entidades;
using Estoque.Entidades;
using System.Data.SQLite;

namespace Estoque.Repository.Data.Script
{
    public static class DataBaseScript
    {
        private const string DataSource = "Data Source=estoque.db;";

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
                    EmpresaId INTEGER
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
                    ProdutoId INTEGER,
                    EmpresaId INTEGER
                );

                CREATE TABLE IF NOT EXISTS HistoricoPedidos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    DataPedido DATE NOT NULL,
                    DataEntrega DATE NOT NULL,
                    QuantidadeSolicitada INTEGER NOT NULL,
                    TipoAlteracao TEXT NOT NULL,
                    NomeProduto TEXT NOT NULL,
                    ProdutoId INTEGER,
                    EmpresaId INTEGER
                );";

            return commandCREATE;
        }

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

        public static void InsertAdmin(Usuario usuario)
        {
            using (var connection = new SQLiteConnection(DataSource))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    // Insere Usuario
                    string insertUsuario = "INSERT INTO Usuarios (Nome, Username, TipoUsuario, Senha, Email, EmpresaId) VALUES (@Nome, @Username, @TipoUsuario, @Senha, @Email, @EmpresaId);";
                    using (var command = new SQLiteCommand(insertUsuario, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", usuario.Nome);
                        command.Parameters.AddWithValue("@Username", usuario.Username);
                        command.Parameters.AddWithValue("@TipoUsuario", usuario.TipoUsuario);
                        command.Parameters.AddWithValue("@Senha", usuario.Senha);
                        command.Parameters.AddWithValue("@Email", usuario.Email);
                        command.Parameters.AddWithValue("@EmpresaId", usuario.EmpresaId);
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
        }
        public static void InsertEntities(Empresa empresa, Fornecedor fornecedor, Produto produto, Pedido pedido, Usuario usuario)
        {
            using (var connection = new SQLiteConnection(DataSource))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insere Empresa
                        string insertEmpresa = "INSERT INTO Empresas (Nome, Contato, Endereco, CNPJ) VALUES (@Nome, @Contato, @Endereco, @CNPJ); SELECT last_insert_rowid();";
                        long empresaId;
                        using (var command = new SQLiteCommand(insertEmpresa, connection))
                        {
                            command.Parameters.AddWithValue("@Nome", empresa.Nome);
                            command.Parameters.AddWithValue("@Contato", empresa.Contato);
                            command.Parameters.AddWithValue("@Endereco", empresa.Endereco);
                            command.Parameters.AddWithValue("@CNPJ", empresa.CNPJ);
                            empresaId = (long)command.ExecuteScalar();
                        }

                        // Insere Fornecedor
                        string insertFornecedor = "INSERT INTO Fornecedores (Nome, Contato, Endereco, CNPJ, EmpresaId) VALUES (@Nome, @Contato, @Endereco, @CNPJ, @EmpresaId); SELECT last_insert_rowid();";
                        long fornecedorId;
                        using (var command = new SQLiteCommand(insertFornecedor, connection))
                        {
                            command.Parameters.AddWithValue("@Nome", fornecedor.Nome);
                            command.Parameters.AddWithValue("@Contato", fornecedor.Contato);
                            command.Parameters.AddWithValue("@Endereco", fornecedor.Endereco);
                            command.Parameters.AddWithValue("@CNPJ", fornecedor.CNPJ);
                            command.Parameters.AddWithValue("@EmpresaId", empresaId);
                            fornecedorId = (long)command.ExecuteScalar();
                        }

                        // Insere Produto
                        string insertProduto = "INSERT INTO Produtos (Nome, Preco, Descricao, QuantidadeEmEstoque, FornecedorId, EmpresaId) VALUES (@Nome, @Preco, @Descricao, @QuantidadeEmEstoque, @FornecedorId, @EmpresaId); SELECT last_insert_rowid();";
                        using (var command = new SQLiteCommand(insertProduto, connection))
                        {
                            command.Parameters.AddWithValue("@Nome", produto.Nome);
                            command.Parameters.AddWithValue("@Preco", produto.Preco);
                            command.Parameters.AddWithValue("@Descricao", produto.Descricao);
                            command.Parameters.AddWithValue("@QuantidadeEmEstoque", produto.QuantidadeEmEstoque);
                            command.Parameters.AddWithValue("@FornecedorId", fornecedorId);
                            command.Parameters.AddWithValue("@EmpresaId", empresaId);
                            command.ExecuteNonQuery();
                        }

                        // Insere Pedido
                        string insertPedido = "INSERT INTO Pedidos (DataPedido, DataEntrega, QuantidadeSolicitada, TipoAlteracao, NomeProduto, ProdutoId, EmpresaId) VALUES (@DataPedido, @DataEntrega, @QuantidadeSolicitada, @TipoAlteracao, @NomeProduto, @ProdutoId, @EmpresaId);";
                        using (var command = new SQLiteCommand(insertPedido, connection))
                        {
                            command.Parameters.AddWithValue("@DataPedido", pedido.DataPedido);
                            command.Parameters.AddWithValue("@DataEntrega", pedido.DataEntrega);
                            command.Parameters.AddWithValue("@QuantidadeSolicitada", pedido.QuantidadeSolicitada);
                            command.Parameters.AddWithValue("@TipoAlteracao", pedido.TipoAlteracao);
                            command.Parameters.AddWithValue("@NomeProduto", pedido.NomeProduto);
                            command.Parameters.AddWithValue("@ProdutoId", produto.Id);
                            command.Parameters.AddWithValue("@EmpresaId", empresaId);
                            command.ExecuteNonQuery();
                        }

                        // Insere Usuario
                        string insertUsuario = "INSERT INTO Usuarios (Nome, Username, TipoUsuario, Senha, Email, EmpresaId) VALUES (@Nome, @Username, @TipoUsuario, @Senha, @Email, @EmpresaId);";
                        using (var command = new SQLiteCommand(insertUsuario, connection))
                        {
                            command.Parameters.AddWithValue("@Nome", usuario.Nome);
                            command.Parameters.AddWithValue("@Username", usuario.Username);
                            command.Parameters.AddWithValue("@TipoUsuario", usuario.TipoUsuario);
                            command.Parameters.AddWithValue("@Senha", usuario.Senha);
                            command.Parameters.AddWithValue("@Email", usuario.Email);
                            command.Parameters.AddWithValue("@EmpresaId", empresaId);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao inserir entidades", ex);
                    }
                }
            }
        }
        public static void InsertData()
        {
            Empresa empresa1 = new Empresa
            {
                Id = 1,
                Nome = "Apple",
                Contato = "(31) 91234-5678",
                Endereco = "Av. Inovação, 1000, Belo Horizonte, MG",
                CNPJ = "12.345.678/0001-90"
            };

            Empresa empresa2 = new Empresa
            {
                Id = 2,
                Nome = "Samsung",
                Contato = "(31) 91234-5678",
                Endereco = "Av. Inovação, 1000, Belo Horizonte, MG",
                CNPJ = "12.345.678/0001-90"
            };

            Fornecedor fornecedor1 = new Fornecedor
            {
                Id = 1,
                Nome = "Fornecedor Global 1",
                Contato = "(31) 99876-5432",
                Endereco = "Rua Comércio, 500, Contagem, MG",
                CNPJ = "45.678.912/0001-21",
                EmpresaId = 1
            };

            Fornecedor fornecedor2 = new Fornecedor
            {
                Id = 2,
                Nome = "Fornecedor Global 2",
                Contato = "(31) 99876-5432",
                Endereco = "Rua Comércio, 500, Contagem, MG",
                CNPJ = "45.678.912/0001-21",
                EmpresaId = 2
            };

            Produto produto1 = new Produto
            {
                Id = 1,
                Nome = "Apple Iphone 13",
                Preco = 4500.0,
                Descricao = "Iphone 13 com 64gb de memoria",
                QuantidadeEmEstoque = 20,
                FornecedorId = 1,
                EmpresaId = 1
            };

            Produto produto2 = new Produto
            {
                Id = 2,
                Nome = "Samsung galaxy s21 FE",
                Preco = 4500.0,
                Descricao = "Samsung galaxy s21 FE com 64gb de memoria",
                QuantidadeEmEstoque = 20,
                FornecedorId = 2,
                EmpresaId = 2
            };

            Pedido pedido1 = new Pedido
            {
                Id = 1,
                DataPedido = DateTime.Now,
                DataEntrega = DateTime.Now.AddDays(10),
                QuantidadeSolicitada = 5,
                TipoAlteracao = "Compra",
                NomeProduto = produto1.Nome,
                ProdutoId = 1,
                EmpresaId = 1
            };

            Pedido pedido2 = new Pedido
            {
                Id = 2,
                DataPedido = DateTime.Now,
                DataEntrega = DateTime.Now.AddDays(10),
                QuantidadeSolicitada = 5,
                TipoAlteracao = "Compra",
                NomeProduto = produto2.Nome,
                ProdutoId = 2,
                EmpresaId = 2
            };

            Usuario usuario1 = new Usuario
            {
                Id = 1,
                Nome = "Apple",
                Username = "Apple.Brasil",
                TipoUsuario = "Admin",
                Senha = "Apple",
                Email = "Apple.Brasil@gmail.com",
                EmpresaId = 1
            };

            Usuario usuario2 = new Usuario
            {
                Id = 2,
                Nome = "Samsung",
                Username = "Samsung.Brasil",
                TipoUsuario = "Admin",
                Senha = "Samsung",
                Email = "Samsung.Brasil@gmail.com",
                EmpresaId = 2
            };

            Usuario Admin = new Usuario
            {
                Id = 2,
                Nome = "Admin",
                Username = "Admin",
                TipoUsuario = "Admin",
                Senha = "Admin",
                Email = "Admin@gmail.com",
                EmpresaId = 0
            };
            InsertAdmin(Admin);
            InsertEntities(empresa1, fornecedor1, produto1, pedido1, usuario1);
            InsertEntities(empresa2, fornecedor2, produto2, pedido2, usuario2);
        }

        public static void CheckAndInsertData()
        {
            using (var connection = new SQLiteConnection(DataSource))
            {
                connection.Open();

                try
                {
                    // Verifica se há dados em cada tabela
                    bool isEmpty = IsTableEmpty(connection, "Empresas") &&
                                   IsTableEmpty(connection, "Fornecedores") &&
                                   IsTableEmpty(connection, "Produtos") &&
                                   IsTableEmpty(connection, "Pedidos") &&
                                   IsTableEmpty(connection, "Usuarios");

                    // Insere dados fictícios se estiver vazio
                    if (isEmpty)
                    {
                        InsertData();
                        Console.WriteLine("Dados fictícios inseridos com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("As tabelas já possuem dados. Nenhuma inserção foi realizada.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao verificar ou inserir dados: {ex.Message}");
                }
            }
        }

        private static bool IsTableEmpty(SQLiteConnection connection, string tableName)
        {
            string query = $"SELECT COUNT(*) FROM {tableName}";
            using (var command = new SQLiteCommand(query, connection))
            {
                long count = (long)command.ExecuteScalar();
                return count == 0;
            }
        }

    }
}