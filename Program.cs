using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using SOPlabNEW.Data;
using SOPlabNEW.Graphql.Schemas;
using SOPlabNEW.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ILibraryContext, LibraryService>();
builder.Services.AddSignalR();

var connStr = builder.Configuration.GetConnectionString("LibraryContext");
builder.Services.AddDbContext<LibraryContext>(options =>
               options.UseMySql(connStr, ServerVersion.AutoDetect(connStr)));

builder.Services.AddScoped<ISchema, LibrarySchema>();
builder.Services.AddGraphQL(options =>
{ options.EnableMetrics = true;}).AddSystemTextJson();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseGraphQLAltair();
    
}

app.MapHub<LibHub>("/hub");
app.UseGraphQL<ISchema>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
