using DocumentManagementApp.ClientServices;
using DocumentManagementDAL;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DocumentManagementApp.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet]
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(string username, string password)
    {
      if (ModelState.IsValid)
      {
        var userClientService = new UserClientService();
        var user = await userClientService.ValidateUser(username, password);
        if (user != null)
        {
          Session["UserId"] = user.UserId;
          Session["UserName"] = user.LoginName;
          return RedirectToAction("Index", "Document");
        }
        else
        {
          ViewBag.error = "Invalid Account";
          return View("Index");
        }
      }
      else
      {
        return View("Index");
      }
    }

    [HttpGet]
    public ActionResult Logout()
    {
      Session.Remove("UserId");
      Session.Remove("UserName");
      return RedirectToAction("Index");
    }
  }
}