using Proxy.Domain.Document;

namespace Proxy.Infra.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly Dictionary<string, ConfidentialDocument> _database;

        public DocumentRepository()
        {
            Console.WriteLine("[Repository] Inicializando conexão com banco de dados...");
            Thread.Sleep(1000); // Simulando conexão pesada
            
            _database = new Dictionary<string, ConfidentialDocument>
            {
                ["DOC-001"] = new ConfidentialDocument(
                    "DOC-001",
                    "Relatório Financeiro Q4",
                    "Conteúdo confidencial do relatório financeiro... (10 MB)",
                    3
                ),
                ["DOC-002"] = new ConfidentialDocument(
                    "DOC-002",
                    "Estratégia de Mercado 2025",
                    "Planos estratégicos confidenciais... (50 MB)",
                    5
                ),
                ["DOC-003"] = new ConfidentialDocument(
                    "DOC-003",
                    "Manual do Funcionário",
                    "Políticas e procedimentos... (2 MB)",
                    1
                )
            };
        }

        public ConfidentialDocument? Get(string documentId)
        {
            Console.WriteLine($"[Repository] Carregando documento {documentId} do banco...");
            Thread.Sleep(500); // Simulando operação custosa
            
            if (_database.TryGetValue(documentId, out ConfidentialDocument? doc))
            {
                Console.WriteLine($"[Repository] Documento carregado: {doc.SizeInBytes / (1024 * 1024)} MB");
                return doc;
            }
            
            return null;
        }

         public void Update(string documentId, string newContent)
        {
            Console.WriteLine($"[Repository] Atualizando documento {documentId}...");
            Thread.Sleep(300);
            
            if (_database.TryGetValue(documentId, out ConfidentialDocument? value))
                value.Content = newContent;
        }
    }
}