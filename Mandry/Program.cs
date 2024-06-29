using Mandry.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.SetupSqlServerDbContext();

builder.Services.AddCredentialValidator();

builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddHelpers();

builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var config = builder.Configuration.GetSection("Jwt");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = config["Issuer"] ?? throw new Exception("Issuer in not specified"),
            ValidateAudience = true,
            ValidAudience = config["Audience"] ?? throw new Exception("Issuer in not specified"),
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWTKey"] ?? throw new Exception("JWTKey is not specified"))),
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.SetupSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Services.DbMigration();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
