using BlockchainExplorer.Clients;
using BlockchainExplorer.Interfaces.Domain;
using BlockchainExplorer.Interfaces.External;
using BlockchainExplorer.Services.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddHttpClient();
builder.Services.AddScoped<ITransactionsService, TransactionsService>();
builder.Services.AddSingleton<IAlchemyClient, AlchemyClient>();


var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();