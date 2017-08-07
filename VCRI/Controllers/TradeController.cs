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
        VCR_DAL.DataAccessLayer dal = new VCR_DAL.DataAccessLayer();
        VCRI.Models.Trade trade = new Models.Trade();
        VCR_DAL.Trade trade_data = new VCR_DAL.Trade();
        
        //public ActionResult Index()
        //{
        //    Mapper.CreateMap<VCR_DAL.Trade, Models.Trade>().ForMember(dos => dos.uname, map => map.MapFrom(name => name.Login.username));
        //    Mapper.CreateMap<Models.Trade, VCR_DAL.Trade>();   
        //    List<VCR_DAL.Trade> list_trade = dal.fetch_trade();
        //    var list_trade_Model = new List<Models.Trade>();
        //    int i = 0;
        //    foreach (VCR_DAL.Trade tr in list_trade)
        //    {
        //        list_trade_Model.Add(Mapper.Map<VCR_DAL.Trade, Models.Trade>(tr));
        //        i++;
        //    }
        //    return View(list_trade_Model);
        //}


        ////
        //// GET: /Trade/Create

        //public ActionResult Create()
        //{
        //   return View();
        //}

        //[HttpPost]
        //public ActionResult CreateTrade(FormCollection form)
        //{
        //    try
        //    {
        //        VCRI.Models.Login trd_User = (VCRI.Models.Login)Session["user_d"];
        //        trade.Trade_Code = "";
        //        trade.Trade_Name = form["Trade_Name"];
        //        trade.Description = form["Description"];
        //        trade.Created_By = trd_User.userid;
        //        trade.Created_datetime = System.DateTime.Now;
        //        Mapper.CreateMap<Models.Trade, VCR_DAL.Trade>();
        //        trade_data = Mapper.Map<Models.Trade, VCR_DAL.Trade>(trade);
        //        bool status = dal.Create_Trade(trade_data);
        //        if (status)
        //        {
        //            TempData["msg"] = "Data Inserted Successfully";
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            return View("Invalid_user");
        //        }
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        ////
        //// GET: /Trade/Edit/5

        //public ActionResult Edit(string tradeid)
        //{
        //    Mapper.CreateMap<VCR_DAL.Trade, Models.Trade>();
        //    trade_data = dal.get_trade_details(tradeid);
        //    trade = Mapper.Map<VCR_DAL.Trade, Models.Trade>(trade_data);
        //    return View(trade);
        //}

        ////
        //// POST: /Trade/Edit/5

        //[HttpPost]
        //public ActionResult Edit(Models.Trade t)
        //{
        //    try
        //    {
        //        string tid = t.Trade_Code;
        //        Mapper.CreateMap<Models.Trade, VCR_DAL.Trade>();

        //        trade_data= Mapper.Map<Models.Trade, VCR_DAL.Trade>(t);
               
        //        bool status = dal.update_trade_details(trade_data,tid);
        //        if (status)
        //        {
        //            TempData["msg"] = "Data Updated Successfully";
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            return View("Invalid_user");
        //        }
        //    }
        //    catch(Exception e)
        //    {
        //        return View("Invalid_user");
        //    }
        //}

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
