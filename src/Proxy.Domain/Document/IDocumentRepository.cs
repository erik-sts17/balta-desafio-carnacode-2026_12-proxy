namespace Proxy.Domain.Document
{
    public interface IDocumentRepository
    {
        ConfidentialDocument? Get(string documentId);
        void Update(string documentId, string newContent);
    }
}