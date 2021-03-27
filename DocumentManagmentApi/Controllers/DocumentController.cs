using DocumentManagementBLL;
using DocumentManagementDAL;
using System.Threading.Tasks;
using System.Web.Http;

namespace DocumentManagmentApi.Controllers
{
  public class DocumentController : ApiController
  {
    private IDocumentService _DocumentService;
    public DocumentController(IDocumentService documentService)
    {
      _DocumentService = documentService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("user/{userId}/documents")]
    public async Task<IHttpActionResult> GetAsync(int userId)
    {
      var documents= await _DocumentService.GetDocumentByUserId(userId);
      return Ok(documents);
    }

    [HttpPost]
    [Route("user/document")]
    public async Task<IHttpActionResult> PostAync(Document document)
    {
      await _DocumentService.SaveDocument(document);
      return Ok();
    }
  }
}
