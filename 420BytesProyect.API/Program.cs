using _420BytesProyect.DM.DataBase;
using _420BytesProyect.DM;
using _420BytesProyect.BM.General.Interfaces;
using _420BytesProyect.BM.General;
using Microsoft.AspNetCore.SignalR;
using _420BytesProyect.BM.Hub;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    var groupName = "v1";

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter JWT Bearer token **_only_**",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer", // must be lower case
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    c.SwaggerDoc(groupName, new OpenApiInfo
    {
        Title = $"420BytesProyect",
        Version = groupName,
        Description = "420Bytes API",
        Contact = new OpenApiContact
        {
            Name = "Nicolas Moreno",
            Email = string.Empty,
            Url = new Uri("https://github.com/SteelBrother"),
        }
    });
    c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
     {
        {
          securityScheme, Array.Empty<string>()
        }
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddTransient<IConexionBD, ConexionInsightDB>();
builder.Services.AddTransient<IBMUsuarios, BMUsuarios>();
builder.Services.AddTransient<IBMPlantas, BMPlanta>();
builder.Services.AddTransient<IBMDispositivos, BMDispositivo>();
builder.Services.AddTransient<IBMEstados, BMEstados>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config["jwt:key"]))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequiereToken", policy => policy.RequireAuthenticatedUser());
});
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API 420 Bytes Proyect"));
}


//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//    app.UseEndpoints(endpoints =>
//    {
//        endpoints.MapHub<UsuarioHub>("/usuarioHub").RequireCors("AllowAll");
//    });
//});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
