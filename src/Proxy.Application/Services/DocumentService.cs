using Proxy.Domain.Document;
using Proxy.Domain.User;

namespace Proxy.Application.Services
{
    public class DocumentService(IDocumentRepository repository) : IDocumentService
    {
        private readonly IDocumentRepository _repository = repository;

        public ConfidentialDocument? ViewDocument(string documentId, User user)
        {
           return _repository.Get(documentId);
        }

        public void Update(string documentId, string newContent, User user)
        {
            _repository.Update(documentId, newContent);
        }
    }
}