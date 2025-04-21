using Microsoft.EntityFrameworkCore;
using DecideAi.Data.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:80");


// 1. Configura��o de Servi�os
ConfigureServices(builder);

var app = builder.Build();



ConfigureMiddleware(app);

app.Run();

// M�todo para Configurar Servi�os
void ConfigureServices(WebApplicationBuilder builder)
{
    // Configurar o banco de dados (Oracle)
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseOracle(builder.Configuration.GetConnectionString("DatabaseConnection")));

    // Adicionar suporte a controladores e views (MVC)
    builder.Services.AddControllersWithViews();

     // Adicionar autentica��o e autoriza��o 
    builder.Services.AddAuthentication("CookieAuth")
        .AddCookie("CookieAuth", options =>
        {
            options.LoginPath = "/Usuario/Login"; // Redireciona para a tela de login
            options.AccessDeniedPath = "/Usuario/AccessNegado"; // P�gina de acesso negado
        });

    // Adicionar outras configura��es necess�rias...
}


#region Autentica��o
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("f+ujXAKHk00L5jlMXo2XhAWawsOoihNP1OiAM25lLSO57+X7uBMQgwPju6yzyePi")),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
#endregion


void ConfigureMiddleware(WebApplication app)
{
    // Middleware de tratamento de erros
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts(); // Configura��o para seguran�a (HSTS)
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    // Configura��o de rotas
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=index}/{id?}");
}
