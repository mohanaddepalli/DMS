using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentManagementDAL
{
  public class DocumentRepository
  {
    public async Task SaveDocument(Document document)
    {
      using (var context = new DMSEntities())
      {
        context.Configuration.ProxyCreationEnabled = true;
        context.Entry(document).State = EntityState.Added;
        int x = await (context.SaveChangesAsync());
      }
    }
    public async Task<List<Document>> GetDocumentByUserId(int userId)
    {
      List<Document> documents = null;
      using (var context = new DMSEntities())
      {
        context.Configuration.ProxyCreationEnabled = false;
        documents = await (context.Documents.Where(s => s.UserId == userId).ToListAsync());
      }
      return documents;
    }
  }
}