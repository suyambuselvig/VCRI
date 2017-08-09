using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VCRI.Models;

namespace VCRI.Controllers
{
    public class OrderController : Controller
    {
        VCRI_DAL.DataAccessLayer dal = new VCRI_DAL.DataAccessLayer();
        VCRI.Models.Order order = new Models.Order();
        VCRI_DAL.PurchaseOrder  order_data = new VCRI_DAL.PurchaseOrder ();
        //
        // GET: /Order/

        //public ActionResult Index()
        //{
        //    Mapper.CreateMap<VCRI_DAL.Order, Models.Order>().ForMember(dos => dos.uname, map => map.MapFrom(name => name.Login.username));
        //    Mapper.CreateMap<VCRI_DAL.Order, Models.Order>().ForMember(dos => dos.drugname, map => map.MapFrom(name => name.Drug.Drug_Name));
        //    Mapper.CreateMap<Models.Order, VCRI_DAL.Order>();
        //    List<VCRI_DAL.Order> list_order = dal.fetch_Order();
        //    var list_order_Model = new List<Models.Order>();
        //    int i = 0;
        //    foreach (VCRI_DAL.Order tr in list_order)
        //    {
        //        list_order_Model.Add(Mapper.Map<VCRI_DAL.Order, Models.Order>(tr));
        //        i++;
        //    }
        //    return View(list_order_Model);
        //}

        ////
        //// GET: /Order/Details/5

        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        ////
        //// GET: /Order/Create

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
        //// POST: /Order/Create

        //[HttpPost]
        //public ActionResult CreateOrder(FormCollection collection)
        //{
        //    try
        //    {
        //        VCRI.Models.Login formula_User = (VCRI.Models.Login)Session["user_ID"];
        //        order.Order_Code = "";
        //        order.Order_Count = Convert.ToInt32(collection["Order_Count"]);
        //        order.Order_Date = System.DateTime.Now;
        //        order.Ordered_By = formula_User.userid;
        //        order.Drug_Code = collection["drug"];
        //        Mapper.CreateMap<Models.Order, VCRI_DAL.Order>();
        //        order_data = Mapper.Map<Models.Order, VCRI_DAL.Order>(order);
        //        bool status = dal.Create_Order(order_data);
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
        //// GET: /Order/Edit/5

        //public ActionResult Edit(string orderid)
        //{
        //    Mapper.CreateMap<VCRI_DAL.Drug, Models.Drug>();
        //    Mapper.CreateMap<Models.Drug, VCRI_DAL.Drug>();
           

        //    List<VCRI_DAL.Drug> list_drug = dal.fetch_drug();
        //    VCRI.Models.Drug d_Model = new Drug();
        //    List<Drug> list_drug_Model = new List<Drug>();
        //    foreach (VCRI_DAL.Drug t1 in list_drug)
        //    {
        //        list_drug_Model.Add(Mapper.Map<VCRI_DAL.Drug, VCRI.Models.Drug>(t1));

        //    }

        //    ViewData["drug"] = list_drug_Model;
        //    order_data = dal.get_order_details(orderid);
        //    ViewData["current_drug"] = (Mapper.Map<VCRI_DAL.Drug, VCRI.Models.Drug>(dal.get_drug_details(order_data.Drug_Code))).Drug_Name;
        //    order = Mapper.Map<VCRI_DAL.Order, Models.Order>(order_data);
        //    return View(order);
        //}

        ////
        //// POST: /Order/Edit/5

        //[HttpPost]
        //public ActionResult Edit(Models.Order o, FormCollection collection)
        //{
        //    try
        //    {

        //        string oid = o.Order_Code;
        //        Mapper.CreateMap<Models.Order, VCRI_DAL.Order>();
        //        o.Drug_Code = collection["drug"];
        //        order_data = Mapper.Map<Models.Order, VCRI_DAL.Order>(o);

        //        bool status = dal.update_order_details(order_data, oid);
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
        // GET: /Order/Delete/5

        public ActionResult Delete(String orderid)
        {
            try
            {
                bool status = dal.Delete_Order(orderid);
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
