using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
//using Datos.Contexto;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(option =>
{

    //option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    //{
    //    In = ParameterLocation.Header,
    //    Description = "Ingresa un token válido",
    //    Name = "Authorization",
    //    Type = SecuritySchemeType.Http,
    //    BearerFormat = "JWT",
    //    Scheme = "Bearer"
    //});
    //option.AddSecurityRequirement(new OpenApiSecurityRequirement
    //{
    //    {
    //        new OpenApiSecurityScheme
    //        {
    //            Reference = new OpenApiReference
    //            {
    //                Type = ReferenceType.SecurityScheme,
    //                Id = "Bearer"
    //            }
    //        },
    //        new string[]{}
    //    }
    //});

    //CONFIIGURACION PARA AUTORIZATION CON OAUTH2 DESDE SWAGGER
    option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Swagger Azure Ad", Version = "v1" });
    option.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Oauth 2.0 uses Authorization flow ",
        Name="oauth2.0",
        Type = SecuritySchemeType.OAuth2,
        Flows= new OpenApiOAuthFlows
        {
            AuthorizationCode = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri(builder.Configuration["SwaggerAzureAD:AuthorizationUrl"]),
                TokenUrl = new Uri(builder.Configuration["SwaggerAzureAD:TokenUrl"]),
                Scopes = new Dictionary<string, string> {
                    { builder.Configuration["SwaggerAzureAD:Scope"], "Accesi API as user" }
                }
            }
        }
        
    });
    //CONFIIGURACION PARA AUTORIZATION CON OAUTH2 DESDE SWAGGER
    option.AddSecurityRequirement( new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference{Type = ReferenceType.SecurityScheme, Id="oauth2"}
            },
                
            new [] { builder.Configuration["SwaggerAzureAD:Scope"] }
        }
    }

        );
});

//builder.Services.AddDbContext<ApplicationDbContext>(opciones =>opciones.UseSqlServer())


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseCors(opt => opt.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());
    app.UseSwagger();
    app.UseSwaggerUI( c =>
    {
        //CONFIIGURACION PARA AUTORIZATION CON OAUTH2 DESDE SWAGGER
        c.OAuthClientId(builder.Configuration["SwaggerAzureAD:ClientId"]);
        c.OAuthUsePkce();
        c.OAuthScopeSeparator(" ");
    });

}
else
{
    app.UseCors(opt => opt.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        //CONFIIGURACION PARA AUTORIZATION CON OAUTH2 DESDE SWAGGER
        c.OAuthClientId(builder.Configuration["SwaggerAzureAD:ClientId"]);
        c.OAuthUsePkce();
        c.OAuthScopeSeparator(" ");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
