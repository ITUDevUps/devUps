//should call services here to connect to endpoints
//using Services;
using minitwit_backend.Data;

namespace minitwit_backend.controller; 

public static partial class EndpointMapper
{
    public static WebApplication RegisterMessageEndpoints(this WebApplication app)
    {
        app.MapControllers();
        return app; 
    }

    public static WebApplication MessageEndpoint(this WebApplication app)
    {
        app.MapGet("/GetMessages",async () =>
        {
            using var repo = new MessageRepository(new MinitwitContext());
            return await repo.GetMessagesAsync();
        });
            app.MapGet("/GetMessages/{userName}", async (string userName) =>
        {
            using var repo = new MessageRepository(new MinitwitContext());
            return await repo.GetMessagesAsyncByUserName(userName);
        }); 
        return app;
    }  
}