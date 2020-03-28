using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagementWebMVC.DataAccess;
using UserManagementWebMVC.Models;

namespace UserManagementWebMVC.Controllers
{
    public class AccountController : Controller
    {
      
        [HttpGet]
        public ActionResult IsLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IsLogin(AccountModel objAcc)
        {
            DataAccessLayer objDB = new DataAccessLayer();
            string result = objDB.IsLogin(objAcc.Account, objAcc.Password);
            if (result == "")
            {
                return View();
            }
            else return RedirectToAction("GoToMain");

        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GoToMain()
        {
            return RedirectToAction("Index", "Customer", "");
        }
    }
}