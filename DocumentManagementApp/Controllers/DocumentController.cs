using DocumentManagementApp.Filters;
using DocumentManagementApp.ClientServices;
using DocumentManagementDAL;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DocumentManagementApp.Controllers
{
  [CustomAuthenticationFilter]
  public class DocumentController : Controller
  {
    // GET: Document
    public ActionResult Index()
    {
      return View();
    }

    public async Task<ActionResult> DocumentList()
    {
      DocumentClientService documentService = new DocumentClientService();
      var docs = await documentService.GetDocuments(Session["UserId"].ToString());
      return PartialView("_DocumentListView", docs);
    }

    [HttpPost]
    public async Task<ActionResult> UploadFiles()
    {
      // Checking no of files injected in Request object  
      if (Request.Files.Count > 0)
      {
        try
        {
          //  Get all files from Request object  
          HttpFileCollectionBase files = Request.Files;
          for (int i = 0; i < files.Count; i++)
          {
            HttpPostedFileBase file = files[i];
            string fname;

            // Checking for Internet Explorer  
            if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
            {
              string[] testfiles = file.FileName.Split(new char[] { '\\' });
              fname = testfiles[testfiles.Length - 1];
            }
            else
            {
              fname = file.FileName;
            }

            // Get the complete folder path and store the file inside it.
            if (!Directory.Exists(Server.MapPath("~/Uploads/")))
            {
              Directory.CreateDirectory(Server.MapPath("~/Uploads/"));
            }
            string path = Path.Combine(Server.MapPath("~/Uploads/"), fname);

            file.SaveAs(path);
            Document document = new Document();
            document.CreatedTimestamp = DateTime.UtcNow;
            document.DocumentExtension = file.FileName.Split('.')[1];
            document.DocumentName = file.FileName;
            document.DocumentPath = path;
            document.StatusId = 1;
            document.LastModifiedTimestamp = DateTime.UtcNow;
            document.UserId = Convert.ToInt16(Session["UserId"]);
            DocumentClientService documentService = new DocumentClientService();
            ViewBag.StatusCode = await documentService.CreateDocument(document);
          }
          // Returns message that successfully uploaded  
          return Json("File upload success.");
        }
        catch (Exception ex)
        {
          return Json("Error occurred. Error details: " + ex.Message);
        }
      }
      else
      {
        return Json("No files selected.");
      }
    }
    public async Task<FileResult> DownloadFile(string fileName)
    {
      //Build the File Path.
      string path = Server.MapPath("~/Uploads/") + fileName;
      byte[] result;
      using (FileStream SourceStream = System.IO.File.Open(path, FileMode.Open))
      {
        result = new byte[SourceStream.Length];
        await SourceStream.ReadAsync(result, 0, (int)SourceStream.Length);
      }
      return File(result, "application/octet-stream", fileName);
    }
  }
}