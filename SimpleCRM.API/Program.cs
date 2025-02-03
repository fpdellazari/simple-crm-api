using SimpleCRM.Application.Services;
using SimpleCRM.Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Data;
using Microsoft.Data.SqlClient;
using SimpleCRM.Domain.Repositories;
using SimpleCRM.Infrastructure.Repositories;
using SimpleCRM.Application.Mapper;
using SimpleCRM.Infrastructure.Repositories.Reports;
using SimpleCRM.Domain.Repositories.Reports;
using SimpleCRM.Domain.Services.Reports;
using SimpleCRM.Application.Services.Reports;
using Newtonsoft.Json;
using SimpleCRM.Domain.Services.Authentication;
using SimpleCRM.Application.Services.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Autenticação com Toeken JWT
var privateKey = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:PrivateKey"]);
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options => {
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(privateKey),
        ClockSkew = TimeSpan.Zero
    };
    options.Events = new JwtBearerEvents {
        OnChallenge = context => {
            context.HandleResponse();
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";
            var response = new { message = "Token de autenticação necessário. Forneça um token válido." };
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    };
});

// CORS
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAllOrigins", policy => {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
IConfiguration configuration = builder.Configuration;

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Conexão com banco de dados
builder.Services.AddScoped<IDbConnection>(db => new SqlConnection(
    builder.Configuration.GetConnectionString("DefaultConnection")));

// Services
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IContactHistoryService, ContactHistoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<IDashboardsService, DashboardsService>();

// Repositories
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IContactHistoryRepository, ContactHistoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<IDashboardsRepository, DashboardsRepository>();

// Swagger
builder.Services.AddSwaggerGen(swagger => {
    swagger.SwaggerDoc("v1", new OpenApiInfo {
        Version = "v1",
        Title = "SimpleCRM API",
        Description = "Esta API fornece funcionalidades básicas para um CRM, permitindo o gerenciamento de clientes, histórico de contatos e vendas, além de um relatório de desempenho."
    });
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira seu token JWT.",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllowAllOrigins");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
