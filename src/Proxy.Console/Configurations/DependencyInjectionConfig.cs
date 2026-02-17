using Microsoft.Extensions.DependencyInjection;
using Proxy.Application.Services;
using Proxy.Domain.Document;
using Proxy.Infra.Proxies.Document;
using Proxy.Infra.Repositories;

namespace Proxy.Console.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IDocumentRepository, DocumentRepository>();

            services.AddTransient<DocumentService>();

            services.AddTransient<IDocumentService>(provider =>
            {
                var service = provider.GetRequiredService<DocumentService>();

                var cache = new DocumentCacheProxy(service);
                var access = new DocumentAccessProxy(cache);
                var audit = new DocumentAuditService(access);               

                return audit;
            });

            return services;
        }
    }
}