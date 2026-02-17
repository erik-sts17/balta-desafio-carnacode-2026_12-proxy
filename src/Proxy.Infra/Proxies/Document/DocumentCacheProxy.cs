using Proxy.Application.Services;
using Proxy.Domain.Document;
using Proxy.Domain.User;

namespace Proxy.Infra.Proxies.Document
{
    public class DocumentCacheProxy(IDocumentService documentService) : IDocumentService
    {
        private readonly IDocumentService _documentService = documentService;
        private readonly Dictionary<string, ConfidentialDocument> _cache = [];

        public void Update(string documentId, string newContent, User user)
        {
            if (_cache.ContainsKey(documentId))
                _cache.Remove(documentId);

            _documentService.Update(documentId, newContent, user);
        }

        public ConfidentialDocument? ViewDocument(string documentId, User user)
        {
            if (_cache.TryGetValue(documentId, out var cached))
            {
                Console.WriteLine($"[Cache] Documento {documentId} encontrado no cache");
                return cached;
            }

            var doc = _documentService.ViewDocument(documentId, user);

            if (doc != null)
                _cache[documentId] = doc;

            return doc;
        }
    }
}
