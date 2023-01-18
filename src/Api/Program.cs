using Microsoft.EntityFrameworkCore;
using RiskCenterStoreApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configuration CORS

string myAllowedHostSpecificOrigins = "_MyAllowedHostSpecificOrigins";
string allowedHosts = builder.Configuration.GetValue<string>("AllowedHosts");

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowedHostSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins(allowedHosts);
                      });
});

// Configure connection to db
// Obtain the conection string
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Set context with conection to SQLServer
builder.Services.AddDbContext<StoreContext>(options => options.UseSqlServer(ConnectionString));

var app = builder.Build();

// Enable CORS
app.UseCors(myAllowedHostSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
