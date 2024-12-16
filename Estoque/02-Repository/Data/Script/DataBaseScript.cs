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
                    CNPJ TEXT NOT NULL,
                    EmpresaId INTEGER
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

                        // Insere Pedido
                        string insertHistoricoPedido = "INSERT INTO HistoricoPedidos (DataPedido, DataEntrega, QuantidadeSolicitada, TipoAlteracao, NomeProduto, ProdutoId, EmpresaId) VALUES (@DataPedido, @DataEntrega, @QuantidadeSolicitada, @TipoAlteracao, @NomeProduto, @ProdutoId, @EmpresaId);";
                        using (var command = new SQLiteCommand(insertHistoricoPedido, connection))
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
            // Empresas
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

            Empresa empresaAdmin = new Empresa
            {
                Id = 3,
                Nome = "Admin",
                Contato = "(31) 91234-5678",
                Endereco = "Admin Endereco",
                CNPJ = "12.345.678/0001-90"
            };


            Empresa empresa3 = new Empresa
            {
                Id = 4,
                Nome = "Sony",
                Contato = "(31) 98765-4321",
                Endereco = "Rua Tecnologia, 200, São Paulo, SP",
                CNPJ = "98.765.432/0001-23"
            };

            Empresa empresa4 = new Empresa
            {
                Id = 5,
                Nome = "Microsoft",
                Contato = "(11) 98765-4321",
                Endereco = "Av. Cloud, 400, Rio de Janeiro, RJ",
                CNPJ = "45.678.912/0001-54"
            };

            Empresa empresa5 = new Empresa
            {
                Id = 6,
                Nome = "Amazon",
                Contato = "(21) 99887-6543",
                Endereco = "Rua E-commerce, 500, Curitiba, PR",
                CNPJ = "12.987.654/0001-77"
            };

            // Fornecedores
            Fornecedor fornecedor1 = new Fornecedor
            {
                Id = 1,
                Nome = "Fornecedor Apple",
                Contato = "(31) 99876-5432",
                Endereco = "Rua Comércio, 500, Contagem, MG",
                CNPJ = "45.678.912/0001-21",
                EmpresaId = 1
            };

            Fornecedor fornecedor2 = new Fornecedor
            {
                Id = 2,
                Nome = "Fornecedor Samsung",
                Contato = "(31) 99876-5432",
                Endereco = "Rua Comércio, 500, Contagem, MG",
                CNPJ = "45.678.912/0001-21",
                EmpresaId = 2
            };

            Fornecedor fornecedor3 = new Fornecedor
            {
                Id = 3,
                Nome = "Fornecedor Sony",
                Contato = "(31) 99876-5433",
                Endereco = "Rua Eletrônica, 300, São Paulo, SP",
                CNPJ = "56.789.123/0001-45",
                EmpresaId = 4
            };

            Fornecedor fornecedor4 = new Fornecedor
            {
                Id = 4,
                Nome = "Fornecedor Microsoft",
                Contato = "(31) 99876-5434",
                Endereco = "Av. Software, 400, Rio de Janeiro, RJ",
                CNPJ = "34.567.891/0001-66",
                EmpresaId = 5
            };

            Fornecedor fornecedor5 = new Fornecedor
            {
                Id = 5,
                Nome = "Fornecedor Amazon",
                Contato = "(31) 99876-5435",
                Endereco = "Rua Logística, 600, Curitiba, PR",
                CNPJ = "23.456.789/0001-88",
                EmpresaId = 6
            };

            Fornecedor fornecedorAdmin = new Fornecedor
            {
                Id = 6,
                Nome = "Admin fornecedor",
                Contato = "(31) 99876-5432",
                Endereco = "Admin Endereco",
                CNPJ = "45.678.912/0001-21",
                EmpresaId = 3
            };

            // Produtos
            Produto produto1 = new Produto
            {
                Id = 1,
                Nome = "Apple iPhone 13",
                Preco = 4500.0,
                Descricao = "iPhone 13 com 64GB de memória",
                QuantidadeEmEstoque = 20,
                FornecedorId = 1,
                EmpresaId = 1
            };

            Produto produto2 = new Produto
            {
                Id = 2,
                Nome = "Samsung Galaxy S21 FE",
                Preco = 4500.0,
                Descricao = "Samsung Galaxy S21 FE com 64GB de memória",
                QuantidadeEmEstoque = 20,
                FornecedorId = 2,
                EmpresaId = 2
            };

            Produto produto3 = new Produto
            {
                Id = 3,
                Nome = "Sony PlayStation 5",
                Preco = 5000.0,
                Descricao = "Console de última geração",
                QuantidadeEmEstoque = 15,
                FornecedorId = 3,
                EmpresaId = 4
            };

            Produto produto4 = new Produto
            {
                Id = 4,
                Nome = "Microsoft Surface Laptop",
                Preco = 7000.0,
                Descricao = "Laptop potente para produtividade",
                QuantidadeEmEstoque = 10,
                FornecedorId = 4,
                EmpresaId = 5
            };

            Produto produto5 = new Produto
            {
                Id = 5,
                Nome = "Amazon Echo Dot",
                Preco = 300.0,
                Descricao = "Assistente virtual Alexa",
                QuantidadeEmEstoque = 50,
                FornecedorId = 5,
                EmpresaId = 6
            };

            Produto produtoAdmin = new Produto
            {
                Id = 6,
                Nome = "Admin Product",
                Preco = 4500.0,
                Descricao = "Admin product description",
                QuantidadeEmEstoque = 20,
                FornecedorId = 6,
                EmpresaId = 3
            };

            // Pedidos
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

            Pedido pedido3 = new Pedido
            {
                Id = 3,
                DataPedido = DateTime.Now,
                DataEntrega = DateTime.Now.AddDays(10),
                QuantidadeSolicitada = 3,
                TipoAlteracao = "Compra",
                NomeProduto = produto3.Nome,
                ProdutoId = 3,
                EmpresaId = 4
            };

            Pedido pedido4 = new Pedido
            {
                Id = 4,
                DataPedido = DateTime.Now,
                DataEntrega = DateTime.Now.AddDays(10),
                QuantidadeSolicitada = 2,
                TipoAlteracao = "Compra",
                NomeProduto = produto4.Nome,
                ProdutoId = 4,
                EmpresaId = 5
            };

            Pedido pedido5 = new Pedido
            {
                Id = 5,
                DataPedido = DateTime.Now,
                DataEntrega = DateTime.Now.AddDays(10),
                QuantidadeSolicitada = 10,
                TipoAlteracao = "Compra",
                NomeProduto = produto5.Nome,
                ProdutoId = 5,
                EmpresaId = 6
            }; Pedido pedidoAdmin = new Pedido
            {
                Id = 6,
                DataPedido = DateTime.Now,
                DataEntrega = DateTime.Now.AddDays(10),
                QuantidadeSolicitada = 5,
                TipoAlteracao = "Compra",
                NomeProduto = produtoAdmin.Nome,
                ProdutoId = 6,
                EmpresaId = 3
            };

            // Usuários
            Usuario usuario1 = new Usuario
            {
                Id = 1,
                Nome = "Apple User",
                Username = "Apple.Brasil",
                TipoUsuario = "Admin",
                Senha = "Apple123",
                Email = "apple.brasil@gmail.com",
                EmpresaId = 1
            };

            Usuario usuario2 = new Usuario
            {
                Id = 2,
                Nome = "Samsung User",
                Username = "Samsung.Brasil",
                TipoUsuario = "Admin",
                Senha = "Samsung123",
                Email = "samsung.brasil@gmail.com",
                EmpresaId = 2
            };

            Usuario usuario3 = new Usuario
            {
                Id = 3,
                Nome = "Sony User",
                Username = "Sony.Brasil",
                TipoUsuario = "Admin",
                Senha = "Sony123",
                Email = "sony.brasil@gmail.com",
                EmpresaId = 4
            };

            Usuario usuario4 = new Usuario
            {
                Id = 4,
                Nome = "Microsoft User",
                Username = "Microsoft.Brasil",
                TipoUsuario = "Admin",
                Senha = "Microsoft123",
                Email = "microsoft.brasil@gmail.com",
                EmpresaId = 5
            };

            Usuario usuario5 = new Usuario
            {
                Id = 5,
                Nome = "Amazon User",
                Username = "Amazon.Brasil",
                TipoUsuario = "Admin",
                Senha = "Amazon123",
                Email = "amazon.brasil@gmail.com",
                EmpresaId = 6
            };

            Usuario usuarioAdmin = new Usuario
            {
                Id = 6,
                Nome = "Admin User",
                Username = "Admin",
                TipoUsuario = "Admin",
                Senha = "Admin123",
                Email = "admin@gmail.com",
                EmpresaId = 3
            };

            // Inserção de dados
            InsertEntities(empresa1, fornecedor1, produto1, pedido1, usuario1);
            InsertEntities(empresa2, fornecedor2, produto2, pedido2, usuario2);
            InsertEntities(empresa3, fornecedor3, produto3, pedido3, usuario3);
            InsertEntities(empresa4, fornecedor4, produto4, pedido4, usuario4);
            InsertEntities(empresa5, fornecedor5, produto5, pedido5, usuario5);
            InsertEntities(empresaAdmin, fornecedorAdmin, produtoAdmin, pedidoAdmin, usuarioAdmin);
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