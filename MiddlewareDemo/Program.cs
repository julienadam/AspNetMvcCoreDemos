var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    context.Items[0] = "From first";
    Console.WriteLine("First middleware starting");
    await next.Invoke();
    Console.WriteLine("First middleware done");
});

app.Use(async (context, next) =>
{
    context.Items[1] = "From second";
    Console.WriteLine("Second middleware starting");
    await next.Invoke();
    Console.WriteLine("Second middleware done");

});

app.MapGet("/", async context =>
{
    await context.Response.WriteAsync($"GET !\n{context.Items[0]}\n{context.Items[1]}");
});

app.Run();
