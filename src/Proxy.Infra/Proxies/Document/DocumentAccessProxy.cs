using Proxy.Application.Services;
using Proxy.Domain.Document;
using Proxy.Domain.User;

namespace Proxy.Infra.Proxies.Document
{
    public class DocumentAccessProxy(IDocumentService service) : IDocumentService
    {
        private readonly IDocumentService _service = service;

        public void Update(string documentId, string newContent, User user)
        {
            var doc = _service.ViewDocument(documentId, user);
            if (doc == null || !HasAccess(user, doc.SecurityLevel))
            {
                Console.WriteLine($"Operação não autorizada");
                return;
            }
            _service.Update(documentId, newContent, user);
        }

        public ConfidentialDocument? ViewDocument(string documentId, User user)
        {
            var doc = _service.ViewDocument(documentId, user);

            if (doc == null)
                return doc;

            if (!HasAccess(user, doc.SecurityLevel))
                return null;

            Console.WriteLine($"Acesso permitido ao documento: {doc.Title}");
            return doc;
        }

        private static bool HasAccess(User user, int secutiryLevel) 
        {
            if (user.ClearanceLevel < secutiryLevel)
            {
                Console.WriteLine($"Acesso negado! Nível {user.ClearanceLevel} < Requerido {secutiryLevel}");
                return false;
            }
            return true;
        }
    }
}
