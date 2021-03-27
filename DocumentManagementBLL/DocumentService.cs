using DocumentManagementDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementBLL
{
  public class DocumentService : IDocumentService
  {
    private IDocumentRepository _DocumentRepository;

    public DocumentService(IDocumentRepository documentRepository)
    {
      _DocumentRepository = documentRepository;
    }

    public Task<List<Document>> GetDocumentByUserId(int userId)
    {
      return _DocumentRepository.GetDocumentByUserId(userId);
    }

    public Task SaveDocument(Document document)
    {
      return _DocumentRepository.SaveDocument(document);
    }
  }
}
