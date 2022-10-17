using Application.Services.PaginationServices;
using Application.Services.UriServices;
using Domain.Repositories;
using Persistence.Repositories;
using Presentation.Services.PaginationServices;
using Presentation.Services.UriServices;

namespace Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUnitOfWork(this IServiceCollection collection)
    {
        return collection.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static IServiceCollection AddUriService(this IServiceCollection collection)
    {
        collection.AddHttpContextAccessor();
        return collection.AddSingleton<IUriService>(provider =>
        {
            var accessor = provider.GetRequiredService<IHttpContextAccessor>();
            var request = accessor.HttpContext!.Request;
            var uri = $"{request.Scheme}://{request.Host.ToUriComponent()}";
            return new UriService(uri);
        });
    }

    public static IServiceCollection AddPaginationService(this IServiceCollection collection)
    {
        return collection.AddSingleton<IPaginationService, PaginationService>();
    }
}