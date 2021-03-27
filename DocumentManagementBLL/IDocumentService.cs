using DocumentManagementDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementBLL
{
  public interface IDocumentService
  {
    Task SaveDocument(Document document);
    Task<List<Document>> GetDocumentByUserId(int userId);
  }
}
