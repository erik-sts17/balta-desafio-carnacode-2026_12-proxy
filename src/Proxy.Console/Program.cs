using Microsoft.Extensions.DependencyInjection;
using Proxy.Application.Services;
using Proxy.Console.Configurations;
using Proxy.Domain.User;
using System;

namespace Proxy.Console
{
    public class Program
    {
        static void Main()
        {
            var services = new ServiceCollection();

            services.AddServices();

            var provider = services.BuildServiceProvider();

            var documentService = provider.GetRequiredService<IDocumentService>();

            var user = new User("Erik", 3);

            var document = documentService.ViewDocument("DOC-001", user)
                ?? throw new Exception("Documento não encontrado");

            documentService.Update(document.Id, "New content", user);
        }
    }
}
