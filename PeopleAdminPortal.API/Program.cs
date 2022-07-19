using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PeopleAdminPortal.API.Models;
using PeopleAdminPortal.API.Profiles;
using PeopleAdminPortal.API.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors((options) =>
{
    options.AddPolicy("ngClient", (builder) =>
    {
        builder.WithOrigins("http://localhost:50882")
        .AllowAnyHeader()
        .WithMethods("GET", "POST", "PUT", "DELETE")
        .WithExposedHeaders("*");
    });

});

builder.Services.AddDbContext<PersonAdminContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PersonAdminPortalDb")));

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddTransient<IGenderRepository, GenderRepository>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PersonAdminPortal.API", Version = "v1" });
});
var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperProfile());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("ngClient");

app.UseAuthorization();

app.MapControllers();

app.Run();
