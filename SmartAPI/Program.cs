using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SmartAPI.Application.Ioc;
using SmartAPI.Infrastructure.Data;
using SmartAPI.Infrastructure.Data.Entity;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Contextos padrão para acesso ao banco de dados
var StringConnection = builder.Configuration.GetConnectionString("DefaultConnection");

//Contexto Padrão
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(StringConnection));

// Contexto para uso do Identity separadamente
builder.Services.AddDbContext<ApplicationIdentityDbContext>(options =>
    options.UseNpgsql(StringConnection));

//Configurar identity para utilizar a classe user
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
    .AddDefaultTokenProviders();

//Policy de autorização
builder.Services.AddAuthorization(options => {
    options.AddPolicy("User", policy => policy.RequireRole("User"));
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("Master", policy => policy.RequireRole("Master"));
});

//Adicionar schema de autenticacao da API
var jwtSettings = builder.Configuration.GetSection("JwtSettings");

builder.Services.AddAuthentication(options => 
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters 
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]))
    };
});

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Documentation SmartAPI", Version = "v1" });

    // Arquivo XML de documentacao
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);


    var securityScheme = new OpenApiSecurityScheme {
        Name = "Authorization",
        Description = "Enter 'Bearer {token}'",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Reference = new OpenApiReference {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    c.AddSecurityDefinition("Bearer", securityScheme);
    var securityRequirement = new OpenApiSecurityRequirement
        {
            { securityScheme, new[] { "Bearer" } }
        };
    c.AddSecurityRequirement(securityRequirement);
});

//Injecao de dependencias personalizadas
DependencyInjectionExtensions.ConfigureServiceDependencies(builder.Services);

var app = builder.Build();

//Middleware de Excessoes genericas para tratamento de erros mais internos
app.UseMiddleware<ErrorHandlerMiddleware>();

app.Use(async (context, next) => {
    await next.Invoke(); 
});

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
