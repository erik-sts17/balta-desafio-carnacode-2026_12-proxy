using Proxy.Domain.Document;
using Proxy.Domain.User;

namespace Proxy.Application.Services
{
    public interface IDocumentService
    {
        ConfidentialDocument? ViewDocument(string documentId, User user);
        void Update(string documentId, string newContent, User user);
    }
}