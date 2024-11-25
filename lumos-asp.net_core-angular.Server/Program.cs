using lumos_asp.net_core_angular.Server.Data;
using lumos_asp.net_core_angular.Server.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text.Json;
using lumos_asp.net_core_angular.Server.Repositories.Auth;
using lumos_asp.net_core_angular.Server.Config;

var builder = WebApplication.CreateBuilder(args);
var jwtSettings = builder.Configuration.GetSection("Jwt");

// Configuration for connection
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string"
        + "'DefaultConnection' not found.");

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AngularAppAspNet", policy =>
//    {
//        policy.WithOrigins("http://localhost:4200") // Permite o frontend rodando em localhost:4200
//              .AllowAnyMethod()  // Permite qualquer método HTTP (GET, POST, etc.)
//              .AllowAnyHeader()  // Permite qualquer cabeçalho
//              .AllowCredentials();  // Permite credenciais (cookies, autenticação, etc.)
//    });
//});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularAppAspNet", policy =>
    {
        policy.WithOrigins("http://localhost:60867") // Permite o frontend rodando em localhost:60867
              .AllowAnyMethod()  // Permite qualquer método HTTP (GET, POST, etc.)
              .AllowAnyHeader()  // Permite qualquer cabeçalho
              .AllowCredentials();  // Permite credenciais (cookies, autenticação, etc.)
    });
});

// Configuration for jwt with rsa
builder.Services.AddSingleton<RsaKeyService>(serviceProvider =>
{
    var privateKeyPath = builder.Configuration["Jwt:PrivateKeyPath"];
    var publicKeyPath = builder.Configuration["Jwt:PublicKeyPath"];
    return new RsaKeyService(privateKeyPath, publicKeyPath);
});

// add JWT auth
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var rsaKeyService = builder.Services.BuildServiceProvider().GetRequiredService<RsaKeyService>();

        var publicKey = rsaKeyService.LoadPublicKey(); // Carregar chave pública

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,  // Configure conforme necessário
            ValidateAudience = true, // Configure conforme necessário
            ValidateLifetime = true,
            IssuerSigningKey = new RsaSecurityKey(publicKey)
        };
    });

// INJECT DEPENDENCY
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<SecurityConfig>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var securityConfig = services.GetRequiredService<SecurityConfig>();
    try
    {
        // Aguarde a execução do método de inicialização
        await securityConfig.InitializeAsync();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao inicializar SecurityConfig: {ex.Message}");
    }
}

//app.UseCors("AngularApp");
//app.UseRouting();
app.UseCors("AngularAppAspNet");

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();