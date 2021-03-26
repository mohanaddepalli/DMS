using DocumentManagementDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DocumentManagmentApi.Controllers
{
  public class DocumentController : ApiController
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("user/{userId}/documents")]
    public async Task<IHttpActionResult> GetAsync(int userId)
    {
      var documentRepository = new DocumentRepository();
      var documents= await documentRepository.GetDocumentByUserId(userId);
      return Ok(documents);
    }

    [HttpPost]
    [Route("user/document")]
    public async Task<IHttpActionResult> PostAync(Document document)
    {
      var documentRepository = new DocumentRepository();
      await documentRepository.SaveDocument(document);
      return Ok();
    }
  }
}
