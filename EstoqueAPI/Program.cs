using CRUD.Repositorios.Data;
using Estoque.Repository;
using Estoque.Services;
using EstoqueAPI;
using Microsoft.OpenApi.Models;
using TrabalhoFinal.Repository;
using TrabalhoFinal.Services;

var builder = WebApplication.CreateBuilder(args);

// Configurações de Controllers
builder.Services.AddControllers();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Informa ao Swagger para incluir o arquivo XML gerado
    var xmlFile = "API.xml"; // Nome do arquivo XML gerado
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API do Estoque",
        Version = "v1",
        Description = "Estoque de produtos da empresa [Nome_da_Empresa]"
    });
});

// Inicialização do banco de dados
InicializadorBd.Inicializar(); // Certifique-se de que o método 'Inicializar' esteja implementado corretamente

// Adicionando o AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Registro dos Repositórios e Serviços
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IHistoricoPedidoRepository, HistoricoPedidoRepository>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IFornecedorService, FornecedorService>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IHistoricoPedidoService, HistoricoPedidoService>();

// Construção da aplicação
var app = builder.Build();

// Verificação do ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API Estoque v1");
    });
}

// Permite requisições de qualquer origem (CORS)
app.UseCors("PermitirTudo");

// Configuração do HTTPS
app.UseHttpsRedirection();

// Ativa o middleware de autorização
app.UseAuthorization();

// Mapeia os controladores para as rotas
app.MapControllers();

// Executa a aplicação
app.Run();