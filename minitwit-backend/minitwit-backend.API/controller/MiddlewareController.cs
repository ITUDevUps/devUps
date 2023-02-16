namespace minitwit_backend.controller;

public static partial class MiddlewareController
{
    public static WebApplication RegisterMapMiddleware(this WebApplication app)
    {
        app.UseCors(builder =>
        {
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
            builder.AllowCredentials();
            builder.AllowAnyOrigin();
        });

        app.UseHttpsRedirection(); 
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }    
}