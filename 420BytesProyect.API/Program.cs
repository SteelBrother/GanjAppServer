using _420BytesProyect.DM.DataBase;
using _420BytesProyect.DM;
using _420BytesProyect.BM.General.Interfaces;
using _420BytesProyect.BM.General;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

using Microsoft.Extensions.Configuration;
using _420BytesProyect.BM.Identity.Interfaces;
using _420BytesProyect.BM.Identity;
using Microsoft.Extensions.DependencyInjection;
using _420BytesProyect.DT.Identity;
using _420BytesProyect.BM.HubMsj;
using _420BytesProyect.BM.Scheduler.Interfaces;
using _420BytesProyect.BM.Scheduler;

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

builder.Services.AddCors( options => {
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddSignalR();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IConexionBD, ConexionInsightDB>();
builder.Services.AddTransient<IBMUsuarios, BMUsuarios>();
builder.Services.AddTransient<IBMPlantas, BMPlanta>();
builder.Services.AddTransient<IBMDispositivos, BMDispositivo>();
builder.Services.AddTransient<IBMEstados, BMEstados>();
builder.Services.AddTransient<IBMIdentity, BMIdentity>();
builder.Services.AddTransient<IBMAppointment, BMAppointment>(); 
builder.Services.AddTransient<GeneradorPassword>();
//builder.Services.AddTransient<UserUpdatesHub>();

//var azureSignalRConnectionString = config.GetSection("SignalrAzureConnectionString:key");
//builder.Services.AddSignalR()
//    .AddAzureSignalR(azureSignalRConnectionString.Value);

builder.Services.AddControllers();

//var azureSignalRConnectionString = "Endpoint=https://signalr420bytes.service.signalr.net;AccessKey=z6w648X2uU9Nu/BEixgo/hiSR4u8Tj2Bb9G/xF2K/7A=;Version=1.0;";
var azureSignalRConnectionString = "Endpoint=https://hub420bytesproyect.service.signalr.net;AccessKey=BVpQjnFatykkMc8ISSqU701+ZLqRxSyyQcA96GX/Y9k=;Version=1.0;";

builder.Services.AddSignalR().AddAzureSignalR(option =>
{
    option.ConnectionString = azureSignalRConnectionString;
});

builder.Services.Configure<JwtConfig>(config.GetSection("jwt:key"));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    var key = Encoding.ASCII.GetBytes(config["jwt:key"]);
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

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseHttpsRedirection();
app.MapControllers();
app.UseRouting();
app.UseCors();
app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//    app.UseEndpoints(endpoints =>
//    {
//        endpoints.MapHub<UserUpdatesHub>("/UserUpdatesHub").RequireCors("AllowAll");
//    });
//});


app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<UserUpdatesHub>("/UserUpdatesHub");
});



app.Run();
