using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Tyalo.Database;
using Tyalo.Services;

var builder = WebApplication.CreateBuilder(args);

var tokenKey = builder.Configuration["TokenKey"];
byte[] key;

if (tokenKey is null)
{
    throw new ArgumentNullException(nameof(tokenKey), "TokenKey is required");
}

key = File.Exists(tokenKey)
    ? File.ReadAllBytes(tokenKey)
    : Convert.FromHexString(tokenKey);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        Console.WriteLine("Adding JwtBearer");
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "http://tyalo.lembata.pro",
            ValidAudience = "http://tyalo.lembata.pro",
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
        options.IncludeErrorDetails = true;
    });
builder.Services.AddAuthorization();
builder.Services.AddDbContext<TyaloDbContext>(o =>
{
    o.UseSqlite("Data Source=tyalo.db");
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSingleton<ITokenGenerator>(_ => new TokenGenerator(key));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();