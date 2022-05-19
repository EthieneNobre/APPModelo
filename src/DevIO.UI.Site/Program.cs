// Tudo inicia a partir do builder
using DevIO.UI.Site.Data;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    options.AreaViewLocationFormats.Clear();
    options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/{1}/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/Shared/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
});

builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();

builder.Services.AddDbContext<MeuDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conexao")));

// Adicionando o MVC ao container
builder.Services.AddControllersWithViews();

// Realizando o buid das configurações que resultará na App
var app = builder.Build();


// Ativando a pagina de erros caso seja ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

//app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute("AreaProdutos", "Produtos", "Produtos/{controller=Cadastro}/{action=Index}/{id?}");
app.MapAreaControllerRoute("AreaVendas", "Vendas", "Vendas/{controller=Pedidos}/{action=Index}/{id?}");

// Adicionando Rota padrão
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");


// Colocando a App para rodar
app.Run();
