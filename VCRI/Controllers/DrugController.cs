using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VCRI.Models;

namespace VCRI.Controllers
{
    
    public class DrugController : Controller
    {
        VCRI_DAL.DataAccessLayer dal = new VCRI_DAL.DataAccessLayer();
        VCRI.Models.Drug drug = new Models.Drug();
        VCRI_DAL.Drug drug_data = new VCRI_DAL.Drug();
        //
        // GET: /Drug/

        //public ActionResult Index()
        //{
        //    Mapper.CreateMap<VCRI_DAL.Drug, Models.Drug>().ForMember(dos => dos.uname, map => map.MapFrom(name => name.Login.username));
        //    Mapper.CreateMap<VCRI_DAL.Drug, Models.Drug>().ForMember(dos => dos.dname, map => map.MapFrom(name => name.Dosage.Dosage_Description));
        //    Mapper.CreateMap<VCRI_DAL.Drug, Models.Drug>().ForMember(dos => dos.fname, map => map.MapFrom(name => name.Formulation.Formulation_Name));
        //    Mapper.CreateMap<VCRI_DAL.Drug, Models.Drug>().ForMember(dos => dos.tname, map => map.MapFrom(name => name.Trade.Trade_Name));
        //    Mapper.CreateMap<Models.Drug, VCRI_DAL.Drug>();
        //    List<VCRI_DAL.Drug> list_drug = dal.fetch_drug();
        //    var list_drug_Model = new List<Models.Drug>();
        //    int i = 0;
        //    foreach (VCRI_DAL.Drug tr in list_drug)
        //    {
        //        list_drug_Model.Add(Mapper.Map<VCRI_DAL.Drug, Models.Drug>(tr));
        //        i++;
        //    }
        //    return View(list_drug_Model);
        //}

        ////
        //// GET: /Drug/Details/5

        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        ////
        //// GET: /Drug/Create

        //public ActionResult Create()
        //{
        //    Mapper.CreateMap<VCRI_DAL.Drug, Models.Drug>().ForMember(dos => dos.Created_By, map => map.MapFrom(name => name.Login.username));
        //    Mapper.CreateMap<Models.Drug, VCRI_DAL.Drug>();
        //    Mapper.CreateMap<VCRI_DAL.Formulation, VCRI.Models.Formulation>();
        //    Mapper.CreateMap<VCRI_DAL.Dosage, VCRI.Models.Dosage>();
        //    Mapper.CreateMap<VCRI_DAL.Trade, VCRI.Models.Trade>();
        //    List<VCRI_DAL.Formulation> list_formula=dal.fetch_Formulations();
        //    VCRI.Models.Formulation f_Model=new Formulation();
        //    List<Formulation> list_formula_Model = new List<Formulation>();
        //    foreach(VCRI_DAL.Formulation f in list_formula)
        //    {
        //        list_formula_Model.Add(Mapper.Map<VCRI_DAL.Formulation, VCRI.Models.Formulation>(f));
                
        //    }

        //    ViewData["formula"] = list_formula_Model;

        //    List<VCRI_DAL.Dosage> list_dosage = dal.fetch_Dosage();
        //    VCRI.Models.Dosage d_Model = new Dosage();
        //    List<Dosage> list_dosage_Model = new List<Dosage>();
        //    foreach (VCRI_DAL.Dosage d in list_dosage)
        //    {
        //        list_dosage_Model.Add(Mapper.Map<VCRI_DAL.Dosage, VCRI.Models.Dosage>(d));
        //    }

        //    ViewData["dosage"] = list_dosage_Model;

        //    List<VCRI_DAL.Trade> list_trade = dal.fetch_trade();
        //    VCRI.Models.Trade t_Model = new Trade();
        //    List<Trade> list_trade_Model = new List<Trade>();
        //    foreach (VCRI_DAL.Trade t in list_trade)
        //    {
        //        list_trade_Model.Add(Mapper.Map<VCRI_DAL.Trade, VCRI.Models.Trade>(t));
                
        //    }

        //    ViewData["trade"] = list_trade_Model;
        //    return View();
        //}

        ////
        //// POST: /Drug/Create

        //[HttpPost]
        //public ActionResult CreateDrug(FormCollection collection)
        //{
        //    try
        //    {
        //        VCRI.Models.Login formula_User = (VCRI.Models.Login)Session["user_ID"];
        //        drug.Drug_Code = "";
        //        drug.Drug_Name = collection["Drug_Name"];
        //        drug.Created_By = formula_User.userid;
        //        drug.Created_Datetime = System.DateTime.Now;
        //        drug.Dosage_Code = collection["dosage"];
        //        drug.Formulation_code = collection["formula"];
        //        drug.Trade_Code = collection["trade"];
        //        Mapper.CreateMap<Models.Drug, VCRI_DAL.Drug>();
        //        drug_data = Mapper.Map<Models.Drug, VCRI_DAL.Drug>(drug);
        //        bool status = dal.Create_Drug(drug_data);
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
        //// GET: /Drug/Edit/5

        //public ActionResult Edit(string drugid)
        //{
        //    Mapper.CreateMap<VCRI_DAL.Drug, Models.Drug>();
        //    Mapper.CreateMap<Models.Drug, VCRI_DAL.Drug>();
        //    Mapper.CreateMap<VCRI_DAL.Formulation, VCRI.Models.Formulation>();
        //    Mapper.CreateMap<VCRI_DAL.Dosage, VCRI.Models.Dosage>();
        //    Mapper.CreateMap<VCRI_DAL.Trade, VCRI.Models.Trade>();
        //    List<VCRI_DAL.Formulation> list_formula = dal.fetch_Formulations();
        //    VCRI.Models.Formulation f_Model = new Formulation();
        //    List<Formulation> list_formula_Model = new List<Formulation>();
        //    foreach (VCRI_DAL.Formulation f in list_formula)
        //    {
        //        list_formula_Model.Add(Mapper.Map<VCRI_DAL.Formulation, VCRI.Models.Formulation>(f));

        //    }

        //    ViewData["formula"] = list_formula_Model;
            
        //    List<VCRI_DAL.Dosage> list_dosage = dal.fetch_Dosage();
        //    VCRI.Models.Dosage d_Model = new Dosage();
        //    List<Dosage> list_dosage_Model = new List<Dosage>();
        //    foreach (VCRI_DAL.Dosage d in list_dosage)
        //    {
        //        list_dosage_Model.Add(Mapper.Map<VCRI_DAL.Dosage, VCRI.Models.Dosage>(d));
        //    }

        //    ViewData["dosage"] = list_dosage_Model;

        //    List<VCRI_DAL.Trade> list_trade = dal.fetch_trade();
        //    VCRI.Models.Trade t_Model = new Trade();
        //    List<Trade> list_trade_Model = new List<Trade>();
        //    foreach (VCRI_DAL.Trade t1 in list_trade)
        //    {
        //        list_trade_Model.Add(Mapper.Map<VCRI_DAL.Trade, VCRI.Models.Trade>(t1));

        //    }

        //    ViewData["trade"] = list_trade_Model;
        //    drug_data = dal.get_drug_details(drugid);
        //    ViewData["current_formula"] = (Mapper.Map<VCRI_DAL.Formulation, VCRI.Models.Formulation>(dal.get_formula_details(drug_data.Formulation_code))).Formulation_Name;
        //    ViewData["current_dosage"] = (Mapper.Map<VCRI_DAL.Dosage, VCRI.Models.Dosage>(dal.get_dosage_details(drug_data.Dosage_Code))).Dosage_Description;
        //    ViewData["current_trade"] = (Mapper.Map<VCRI_DAL.Trade, VCRI.Models.Trade>(dal.get_trade_details(drug_data.Trade_Code))).Trade_Name;
        //    drug = Mapper.Map<VCRI_DAL.Drug, Models.Drug>(drug_data);
        //    return View(drug);
        //}

        ////
        //// POST: /Drug/Edit/5

        //[HttpPost]
        //public ActionResult Edit(Models.Drug t,FormCollection collection)
        //{
        //    try
        //    {             
            
        //        string tid = t.Drug_Code;
        //        Mapper.CreateMap<Models.Drug, VCRI_DAL.Drug>();
        //        t.Dosage_Code = collection["dosage"];
        //        t.Formulation_code = collection["formula"];
        //        t.Trade_Code = collection["trade"];
        //        drug_data = Mapper.Map<Models.Drug, VCRI_DAL.Drug>(t);

        //        bool status = dal.update_drug_details(drug_data, tid);
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

        ////
        //// GET: /Drug/Delete/5

        public ActionResult Delete(string drugid)
        {
            try
            {
                bool status = dal.Delete_drug(drugid);
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
        // POST: /Drug/Delete/5

        
    }
}
