using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VCRI.Models;
namespace VCRI.Controllers
{
    public class StockController : Controller
    {
        //
        // GET: /Stock/
        VCRI_DAL.DataAccessLayer dal = new VCRI_DAL.DataAccessLayer();
        VCRI.Models.Stock stock = new Models.Stock();
        VCRI_DAL.Stock stock_data = new VCRI_DAL.Stock();
        //public ActionResult Index()
        //{
        //    Mapper.CreateMap<VCRI_DAL.Stock, Models.Stock>().ForMember(dos => dos.drugname, map => map.MapFrom(name => name.Drug.Drug_Name));
        //    Mapper.CreateMap<Models.Stock, VCRI_DAL.Stock>();
        //    List<VCRI_DAL.Stock> list_stock = dal.fetch_stock();
        //    var list_stock_Model = new List<Models.Stock>();
        //    int i = 0;
        //    foreach (VCRI_DAL.Stock tr in list_stock)
        //    {
        //        list_stock_Model.Add(Mapper.Map<VCRI_DAL.Stock, Models.Stock>(tr));
        //        i++;
        //    }
        //    return View(list_stock_Model);
        //}

        ////
        //// GET: /Stock/Details/5

        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        ////
        //// GET: /Stock/Create

        //public ActionResult Create()
        //{
        //    Mapper.CreateMap<VCRI_DAL.Drug, Models.Drug>();
        //    Mapper.CreateMap<Models.Drug, VCRI_DAL.Drug>();
        //    List<VCRI_DAL.Drug> list_drug = dal.fetch_drug();
        //    VCRI.Models.Drug d_Model = new Drug();
        //    List<Drug> list_drug_Model = new List<Drug>();
        //    foreach (VCRI_DAL.Drug d in list_drug)
        //    {
        //        list_drug_Model.Add(Mapper.Map<VCRI_DAL.Drug, VCRI.Models.Drug>(d));
        //    }

        //    ViewData["drug"] = list_drug_Model;


        //    return View();
        //}

        ////
        //// POST: /Stock/Create

        //[HttpPost]
        //public ActionResult CreateStock(FormCollection collection)
        //{
        //    try
        //    {
        //        VCRI.Models.Login formula_User = (VCRI.Models.Login)Session["user_ID"];
        //        stock.Quantity = Convert.ToInt32(collection["Quantity"]);
        //        String date = collection["Expiry_Date"];
        //        stock.Expiry_Date = Convert.ToDateTime(date);
        //        String value = collection["IsActive"];
        //        stock.IsActive = value=="false"?Convert.ToBoolean(collection["IsActive"]):true;
        //        stock.Drug_Code = collection["drug"];
        //        Mapper.CreateMap<Models.Stock, VCRI_DAL.Stock>();
        //        stock_data = Mapper.Map<Models.Stock, VCRI_DAL.Stock>(stock);
        //        bool status = dal.Create_Stock(stock_data);
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
        //        return View("Invalid_user");
        //    }
        //}

        ////
        //// GET: /Stock/Edit/5

        //public ActionResult Edit(string drugid)
        //{

        //    Mapper.CreateMap<VCRI_DAL.Stock, Models.Stock>();
        //    Mapper.CreateMap<Models.Stock, VCRI_DAL.Stock>();
        //    stock_data = dal.get_stock_details(drugid);
        //    stock = Mapper.Map<VCRI_DAL.Stock, Models.Stock>(stock_data);
        //    return View(stock);
        //}

        ////
        //// POST: /Stock/Edit/5

        //[HttpPost]
        //public ActionResult Edit(Models.Stock s, FormCollection collection)
        //{
        //    try
        //    {

        //        string sid = s.Drug_Code;
        //        Mapper.CreateMap<Models.Stock, VCRI_DAL.Stock>();
        //        stock_data = Mapper.Map<Models.Stock, VCRI_DAL.Stock>(s);

        //        bool status = dal.update_stock_details(stock_data, sid);
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
        //    catch (Exception e)
        //    {
        //        return View("Invalid_user");
        //    }
        //}

        //
        // GET: /Stock/Delete/5

        public ActionResult Delete(string drugid)
        {
            try
            {
                bool status = dal.Delete_stock(drugid);
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

        //
        // POST: /Stock/Delete/5

       
    }
}
