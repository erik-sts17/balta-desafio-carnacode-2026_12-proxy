using Proxy.Application.Services;
using Proxy.Domain.Document;
using Proxy.Domain.User;

namespace Proxy.Infra.Proxies.Document
{
    public class DocumentAuditService(IDocumentService documentService) : IDocumentService
    {
        private readonly List<string> _auditLog = [];
        private readonly IDocumentService _documentService = documentService;

        public void Update(string documentId, string newContent, User user)
        {
            var logEntry = $"[{DateTime.Now:HH:mm:ss}] {user.Username} tentou editar {documentId}";
            _auditLog.Add(logEntry);
            Console.WriteLine($"[Audit] {logEntry}");
            _documentService.Update(documentId, newContent, user);
        }

        public ConfidentialDocument? ViewDocument(string documentId, User user)
        {
            var logEntry = $"[{DateTime.Now:HH:mm:ss}] {user.Username} tentou acessar {documentId}";
            _auditLog.Add(logEntry);
            Console.WriteLine($"[Audit] {logEntry}");

            return _documentService.ViewDocument(documentId, user);
        }
    }
}