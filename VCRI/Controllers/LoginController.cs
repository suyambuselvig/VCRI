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
        VCR_DAL.DataAccessLayer dal = new VCR_DAL.DataAccessLayer();
        VCRI.Models.Login log = new Models.Login();
        VCR_DAL.Login log_data = new VCR_DAL.Login();

        public ActionResult Index()
        {
          //  Mapper.CreateMap<VCR_DAL.Login, Models.Login>();

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

            VCR_DAL.Login l = dal.Authenticate(form["userid"], form["passwrd"]);
            if (l != null)
            {
                var log1 = Mapper.Map<VCR_DAL.Login, Models.Login>(l);
                //String role = log.role.ToString().Trim();
                //TempData["user"] = log;
                Session["user_d"] = log1;
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
            List<VCR_DAL.Login> list_user = dal.fetch_User();
            var list_users_Model = new List<Models.Login>();
            int i = 0;
            foreach (VCR_DAL.Login user in list_user)
            {
                list_users_Model.Add(Mapper.Map<VCR_DAL.Login, Models.Login>(user));
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
                log_data.userid = form["userid"];
                log_data.username = form["username"];
                log_data.passwrd = form["passwrd"];
                log_data.role = form["role"];
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
