using System.Net.Mime;
using InventoryAPI.Services;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Removed for gRPC-Web
// app.MapGrpcService<ProductCatalogService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

var provider = new FileExtensionContentTypeProvider();
provider.Mappings.Clear();
provider.Mappings[".proto"] = MediaTypeNames.Text.Plain;
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "Protos")),
    RequestPath = "/proto",
    ContentTypeProvider = provider
});

app.UseRouting();

app.UseGrpcWeb();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<ProductCatalogService>();
});

app.Run();
