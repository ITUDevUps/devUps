namespace minitwit_backend.Controllers;

public static partial class MiddlewareController
{
    public static WebApplication RegisterMapMiddleware(this WebApplication app)
    {
        app.Use(async(context, next) =>
        {
            context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
            await next();
        });

        app.UseCors(builder =>
        {
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
            builder.AllowAnyOrigin();
        });
        //app.UseHttpsRedirection(); 
        //app.UseSwagger();
        //app.UseSwaggerUI();
        app.MapControllers();

        return app;
    }
}