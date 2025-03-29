using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Tyalo.Database;
using Tyalo.Database.Entities;
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

builder.Services.AddAuthorization();
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
        // options.IncludeErrorDetails = true;
    });
builder.Services.AddDbContext<TyaloDbContext>(o =>
{
    o.UseSqlite("Data Source=tyalo.db");
});

//builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddScoped<Authentication>();
builder.Services.AddScoped<RefreshTokenGenerator>();
builder.Services.AddScoped<GoalService>();
builder.Services.AddScoped<SettingsService>();
builder.Services.AddSingleton<ITokenGenerator>(_ => new TokenGenerator(key));

string MyAllowSpecificOrigins = "MyAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod();
            policy.WithOrigins("https://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod();
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});
var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();

app.Run();