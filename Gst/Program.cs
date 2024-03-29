using Gst.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("GstConnection");

builder.Services.AddDbContext<GstDbContext>(opts => opts
    .UseLazyLoadingProxies()
    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

//builder.Services.AddDbContext<UsuarioDbContext>(opts => opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

//builder.Services
//    .AddIdentity<UsuarioDbContext, IdentityRole>()
//    .AddEntityFrameworkStores<UsuarioDbContext>()
//    .AddDefaultTokenProviders();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GstAPI", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("PolicyCors",
         builder =>
         {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
         });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("PolicyCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
