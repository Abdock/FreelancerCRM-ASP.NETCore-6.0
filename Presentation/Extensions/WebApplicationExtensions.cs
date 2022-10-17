namespace Presentation.Extensions;

public static class WebApplicationExtensions
{
    public static void UseSwaggerOpenApi(this WebApplication application)
    {
        application.UseSwagger();
        application.UseSwaggerUI();
    }
}