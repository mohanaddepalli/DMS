using DocumentManagementApp.Models;
using DocumentManagementApp.Utilities;
using DocumentManagementDAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace DocumentManagementApp.ClientServices
{
  public class DocumentClientService
  {
    public async Task<List<DocumentModel>> GetDocuments(string userId)
    {
      List<DocumentModel> docs = new List<DocumentModel>();
      List<Document> documents = new List<Document>();
      var client = new HttpClient();
      client.BaseAddress = new Uri(ConfigurationUtility.GetApiBaseUrl());
      HttpResponseMessage responseMessage = await client.GetAsync("user/"+userId + "/documents");
      if (responseMessage.IsSuccessStatusCode)
      {
        var responseData = responseMessage.Content.ReadAsStringAsync().Result;
        documents = JsonConvert.DeserializeObject<List<Document>>(responseData);
      }
      foreach(var d in documents)
      {
        docs.Add(new DocumentModel { FileId = d.DocumentId, FileName = d.DocumentName, FilePath = d.DocumentPath });
      }
      return docs;
    }
    public async Task<HttpStatusCode> CreateDocument(Document document)
    {
      var client = new HttpClient();
      client.BaseAddress = new Uri(ConfigurationUtility.GetApiBaseUrl());
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      HttpResponseMessage responseMessage = await client.PostAsJsonAsync("user/document", document);
      return responseMessage.StatusCode;
    }
  }
}