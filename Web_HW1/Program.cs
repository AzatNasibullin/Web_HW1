using ASPLess3.Abstraction;
using ASPLess3.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Web_HW1.Abstraction;
using Web_HW1.Data;
using Web_HW1.Graph.Mutation;
using Web_HW1.Graph.Query;
using Web_HW1.Repository;
using WebAppGeek.Mapper;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StorageContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductGroupRepository, ProductGroupRepository>();
builder.Services.AddScoped<IStorageRepository, StorageRepository>();
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>();
builder.Services.AddMemoryCache();
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//	app.UseSwagger();
//	app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();
app.MapGraphQL();
app.Run();