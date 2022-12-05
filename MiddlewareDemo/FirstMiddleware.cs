using System.Globalization;

public class FirstMiddleware
{
    private readonly RequestDelegate next;

    public FirstMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Items[0] = "From first";
        Console.WriteLine("First middleware starting");
        await next.Invoke(context);
        Console.WriteLine("First middleware done");
    }
}

public static class FirstMiddlewareExtensions
{
    public static IApplicationBuilder UseFirstMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<FirstMiddleware>();
    }
}