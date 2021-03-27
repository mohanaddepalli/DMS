using System.Collections.Generic;
using System.Threading.Tasks;

namespace DocumentManagementDAL
{
  public interface IDocumentRepository
  {
    Task SaveDocument(Document document);
    Task<List<Document>> GetDocumentByUserId(int userId);

  }
}