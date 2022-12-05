using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace MiddlewareDemo.Tests;

public class UnitTest1
{
    [Fact]
    public async Task MiddlewareTest_ReturnsNotFoundForRequest()
    {
        using var host = await new HostBuilder()
            .ConfigureWebHost(webBuilder =>
            {
                webBuilder
                    .UseTestServer()
                    .ConfigureServices(services =>
                    {
                        //services.AddMyServices();
                    })
                    .Configure(app =>
                    {
                        app.UseFirstMiddleware();
                    });
            })
            .StartAsync();

        var server = host.GetTestServer();
        server.BaseAddress = new Uri("https://example.com/A/Path/");

        var context = await server.SendAsync(c =>
        {
            c.Request.Method = HttpMethods.Post;
            c.Request.Path = "/and/file.txt";
            c.Request.QueryString = new QueryString("?and=query");
        });
        
        Assert.Equal(404, context.Response.StatusCode);
        Assert.Equal("From first", context.Items[0]);
    }
}