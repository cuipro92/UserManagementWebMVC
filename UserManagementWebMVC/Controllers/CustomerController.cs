using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagementWebMVC.DataAccess;
using UserManagementWebMVC.Models;

namespace UserManagementWebMVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        [HttpGet]
        public ActionResult Index()
        {
            DataAccessLayer objDB = new DataAccessLayer();
            return View(objDB.Selectalldata());
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            DataAccessLayer objDB = new DataAccessLayer();
            if (search == null)
            {
                return View(objDB.Selectalldata());
            }
            else return View(objDB.SearchText(search));
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(CustomerModel objCustomer)
        {
            objCustomer.Birthday = Convert.ToDateTime(objCustomer.Birthday);
            if (ModelState.IsValid) //checking model is valid or not
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.InsertData(objCustomer);
                ViewData["result"] = result;
                ModelState.Clear(); //clearing model
                return RedirectToAction("Index");

            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        //[HttpGet]
        //public ActionResult ShowAllCustomerDetails(string id)
        //{
        //    CustomerModel objCustomer = new CustomerModel();
        //    DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata

        //    objCustomer = objDB.SelectDatabyID(id);
        //    return View(objCustomer);
        //}


        [HttpGet]
        public ActionResult Edit(string id)
        {
            //CustomerModel _objCustomer = new CustomerModel();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata

            return View(objDB.SelectDatabyID(id));
        }

        [HttpPost]
        public ActionResult Edit(CustomerModel objCustomer)
        {

            objCustomer.Birthday = Convert.ToDateTime(objCustomer.Birthday);
            if (ModelState.IsValid) //checking model is valid or not
            {
                DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata
                string result = objDB.UpdateData(objCustomer);
                ViewData["result"] = result;
                ModelState.Clear(); //clearing model
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            //CustomerModel objCustomer = new CustomerModel();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata
            if (!string.IsNullOrEmpty(id))
            {
                ViewBag.Error = objDB.DeleteData(id);

            }
            return RedirectToAction("Index");
        }
    }
}
