var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.UseMiddleware<FirstMiddleware>();
// Convention is to use an extension method instead of calling UseMiddleWare directly
app.UseFirstMiddleware();

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