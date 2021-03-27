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
  public class UserClientService
  {
    public async Task<User> ValidateUser(string userName, string password)
    {
      User user = null;
      var client = new HttpClient();
      client.BaseAddress = new Uri(ConfigurationUtility.GetApiBaseUrl());
      HttpResponseMessage responseMessage = await client.GetAsync("user/validate?userName=" + userName + "&password=" + password);
      if (responseMessage.IsSuccessStatusCode)
      {
        var responseData = responseMessage.Content.ReadAsStringAsync().Result;
        user = JsonConvert.DeserializeObject<User>(responseData);
      }
      return user;
    }
  }
}