using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VCRI.Controllers
{
    public class TradeController : Controller
    {
        VCRI_DAL.DataAccessLayer dal = new VCRI_DAL.DataAccessLayer();
        VCRI.Models.Trade trade = new Models.Trade();
        VCRI_DAL.Trade trade_data = new VCRI_DAL.Trade();

        public ActionResult Index()
        {
     
            List<VCRI_DAL.Trade> list_trade = dal.fetch_trade();
            var list_trade_Model = new List<Models.Trade>();
            int i = 0;
            foreach (VCRI_DAL.Trade tr in list_trade)
            {
                list_trade_Model.Add(Mapper.Map<VCRI_DAL.Trade, Models.Trade>(tr));
                i++;
            }
            return View(list_trade_Model);
        }


        //
        // GET: /Trade/Create

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTrade(FormCollection form)
        {
            try
            {
                VCRI.Models.ULogin trd_User = (VCRI.Models.ULogin)Session["user_ID"];
                trade_data.trade_Code = form["trade_Code"];
                trade_data.trade_Name = form["trade_Name"];
                trade_data.description = form["description"];
                trade_data.created_By = trd_User.user_ID;
                trade_data.date_Created  = System.DateTime.Now;
               // Mapper.CreateMap<Models.Trade, VCRI_DAL.Trade>();
              //  trade_data = Mapper.Map<Models.Trade, VCRI_DAL.Trade>(trade);
                bool status = dal.Create_Trade(trade_data);
                if (status)
                {
                    TempData["msg"] = "Data Inserted Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Invalid_user");
                }
            }
            catch
            {
                return null;
            }
        }

        //
        // GET: /Trade/Edit/5

        public ActionResult Edit(string tradeid)
        {
         //   Mapper.CreateMap<VCRI_DAL.Trade, Models.Trade>();
            trade_data = dal.get_trade_details(tradeid);
            trade = Mapper.Map<VCRI_DAL.Trade, Models.Trade>(trade_data);
            return View(trade);
        }

        //
        // POST: /Trade/Edit/5

        [HttpPost]
        public ActionResult Edit(Models.Trade t)
        {
            try
            {
                string tid = t.trade_Code;
               // Mapper.CreateMap<Models.Trade, VCRI_DAL.Trade>();

                trade_data = Mapper.Map<Models.Trade, VCRI_DAL.Trade>(t);

                bool status = dal.update_trade_details(trade_data, tid);
                if (status)
                {
                    TempData["msg"] = "Data Updated Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Invalid_user");
                }
            }
            catch (Exception e)
            {
                return View("Invalid_user");
            }
        }

        //
        // GET: /Trade/Delete/5

        public ActionResult Delete(string tradeid)
        {
            try
            {
                bool status = dal.Delete_trade(tradeid);
                if (status)
                {
                    TempData["msg"] = "Data Deleted Successfully";
                    return RedirectToAction("Index");
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
