using System.Configuration;

namespace DocumentManagementApp.Utilities
{
  public static class ConfigurationUtility
  {
    public static string GetAppSetting(string key)
    {
      string value = ConfigurationManager.AppSettings[key];
      return value;
    }
    public static string GetApiBaseUrl()
    {
      return GetAppSetting("BaseUrl");
    }
  }
}