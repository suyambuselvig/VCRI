using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace VCRI.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        VCRI_DAL.DataAccessLayer dal = new VCRI_DAL.DataAccessLayer();
        VCRI_DAL.ULogin log_data = new VCRI_DAL.ULogin();

        public ActionResult Index()
        {
           return View();
        }

        //
        // GET: /Login/Details/5
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Authenticate(FormCollection form)
        {

            VCRI_DAL.ULogin l = dal.Authenticate(form["user_ID"], form["user_Pwd"]);
            if (l != null)
            {
                var log1 = Mapper.Map<VCRI_DAL.ULogin, Models.ULogin>(l);
                //String role = log.role.ToString().Trim();
                Session["user_ID"] = log1;
                return RedirectToAction("Index", "Employee");

            }
            else
            {
                return View("Invalid_user");
            }
        }

        //
        // GET: /Login/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult ViewUser()
        {
            List<VCRI_DAL.ULogin> list_user = dal.fetch_User();
            var list_users_Model = new List<Models.ULogin>();
            int i = 0;
            foreach (VCRI_DAL.ULogin user in list_user)
            {
                list_users_Model.Add(Mapper.Map<VCRI_DAL.ULogin, Models.ULogin>(user));
                i++;
            }
            ViewBag.user_list = list_users_Model;
            return View(list_users_Model);
        }

        //
        // POST: /Login/Create

        [HttpPost]
        public ActionResult CreateUser(FormCollection form)
        {
            try
            {
                log_data.user_ID  = form["user_ID"];
                log_data.user_Name = form["user_Name"];
                log_data.user_Pwd = form["user_Pwd"];
                log_data.role = form["role"];
                log_data.date_Created  = DateTime.Now;
                bool status = dal.Create_User(log_data);
                if(status)
                {
                    return RedirectToAction("Create");
                }
                else{
                    return View("Invalid_user");
                }                
            }
            catch
            {
                return null;
            }
        }
        //
        // GET: /Login/Edit/5

         //
        // POST: /Login/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index"); 
            }
            catch
            {
                return View();
            }
        }

    
        public ActionResult Delete(string userid)
        {
            try
            {
              bool status = dal.Delete_User(userid);
                if (status)
                {
                    return RedirectToAction("ViewUser");
                }
                else
                {
                    return View("Invalid_user");
                }
               
            }
            catch
            {
                return View("Invalid_user");
            }
        }

            
    }
}
