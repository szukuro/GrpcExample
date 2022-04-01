// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using Grpc.Net.Client;
using Product;

var channel = GrpcChannel.ForAddress("https://localhost:7200");
var client = new ProductCatalog.ProductCatalogClient(channel);

var request = new ProductDetailsRequest
{
    Id = 1
};

var response = await client.GetProductDetailsAsync(request);

Console.WriteLine(JsonSerializer.Serialize(response, new JsonSerializerOptions
{
    WriteIndented = true
}));
Console.ReadKey();
