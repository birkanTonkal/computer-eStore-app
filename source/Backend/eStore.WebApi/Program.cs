

using Karkas.Core.DataUtil;
using Microsoft.Data.SqlClient;
using System.Data.Common;

string dbProviderName = "Microsoft.Data.SqlClient";
DbProviderFactories.RegisterFactory(dbProviderName, SqlClientFactory.Instance);
DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);

string connectionString = "Data Source=127.0.0.1,1453;Initial Catalog=SHOP;Persist Security Info=True;User ID=sa;Password=yourStrong2022Password;Encrypt=False";
ConnectionSingleton.Instance.AddConnection("Shop", dbProviderName, connectionString);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var devCorsPolicy = "devCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(devCorsPolicy, builder => {
        builder.WithOrigins("http://127.0.0.1:5500/").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        //builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        //builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
        //builder.SetIsOriginAllowed(origin => true);
    });
});




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
    app.UseCors(devCorsPolicy);
}


//app.UseAuthorization();

app.MapControllers();

app.Run();