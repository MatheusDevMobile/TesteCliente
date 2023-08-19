using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TesteCliente.Configuracoes;
using TesteCliente.Core.Interfaces.Repositorios;
using TesteCliente.Core.Interfaces.Servicos;
using TesteCliente.Core.Servicos;
using TesteCliente.Modelos;
using TesteCliente.Persistencia.Repositorios.EFCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(typeof(PerfilMapeamentoApi));

//DBContext
builder.Services.AddScoped<DbContext>(s =>
{
    var contexto = new FabricaBancoTempoExecucaoEF().CreateDbContext(null!);
    contexto.Database.Migrate();
    return contexto;
});

//Servicos
builder.Services.AddScoped<IPessoaServico, PessoaServico>();

//Repositorios
builder.Services.AddScoped<IRepositorioLeitura<Pessoa>, PessoaRepositorio>();
builder.Services.AddScoped<IRepositorioEscrita<Pessoa>, PessoaRepositorio>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
    new OpenApiInfo
    {
        Title = "TesteClienteAPI",
        Description = "",
        Version = "v1",
    });
    c.EnableAnnotations();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandler("/erro");

app.MapControllers();

app.Run();
