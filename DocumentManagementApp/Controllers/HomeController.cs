using DocumentManagementDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    public ActionResult Login(string username, string password)
    {
      if (ModelState.IsValid)
      {
        var userRepo = new UserRepository();
        var user = userRepo.ValidateUser(username, password);
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