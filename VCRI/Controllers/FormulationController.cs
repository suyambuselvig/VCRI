using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VCRI.Controllers
{
    public class FormulationController : Controller
    {
        VCR_DAL.DataAccessLayer dal = new VCR_DAL.DataAccessLayer();
        VCRI.Models.Formulation formulation = new Models.Formulation();
        VCR_DAL.Formulation formulation_data = new VCR_DAL.Formulation();

        //public ActionResult Index()
        //{
        //    Mapper.CreateMap<VCR_DAL.Formulation, Models.Formulation>().ForMember(dos => dos.uname, map => map.MapFrom(name => name.Login.username));
        //    Mapper.CreateMap<Models.Formulation, VCR_DAL.Formulation>();
        //    List<VCR_DAL.Formulation> list_formulation = dal.fetch_Formulations();
        //    var list_formulation_Model = new List<Models.Formulation>();
        //    int i = 0;
        //    foreach (VCR_DAL.Formulation tr in list_formulation)
        //    {
        //        list_formulation_Model.Add(Mapper.Map<VCR_DAL.Formulation, Models.Formulation>(tr));
        //        i++;
        //    }
        //    return View(list_formulation_Model);
        //}

        
        //// GET: /Formulation/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////
        //// POST: /Formulation/Create

        //[HttpPost]
        //public ActionResult CreateFormula(FormCollection collection)
        //{
        //    try
        //    {
        //        VCRI.Models.Login formula_User = (VCRI.Models.Login)Session["user_d"];
        //        formulation.Formulation_code= "";
        //        formulation.Formulation_Name = collection["Formulation_Name"];
        //        formulation.Created_By= formula_User.userid;
        //        formulation.Created_Datetime = System.DateTime.Now;
        //        formulation.Description = collection["Description"];
        //        formulation.ShortName = collection["ShortName"];
        //        Mapper.CreateMap<Models.Formulation, VCR_DAL.Formulation>();
        //        formulation_data = Mapper.Map<Models.Formulation, VCR_DAL.Formulation>(formulation);
        //        bool status = dal.Create_Formulation(formulation_data);
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
        //    catch (Exception e)
        //    {
        //        return View("Invalid_user");
        //    }
        //}

        ////
        //// GET: /Formulation/Edit/5

        //public ActionResult Edit(string formulaid)
        //{
        //    Mapper.CreateMap<VCR_DAL.Formulation, Models.Formulation>();
        //    formulation_data = dal.get_formula_details(formulaid);
        //    formulation = Mapper.Map<VCR_DAL.Formulation, Models.Formulation>(formulation_data);
        //    return View(formulation);
            
        //}

        ////
        //// POST: /Formulation/Edit/5

        //[HttpPost]
        //public ActionResult Edit(Models.Formulation f)
        //{
        //    try
        //    {
        //        string fid = f.Formulation_code;
        //        Mapper.CreateMap<Models.Formulation, VCR_DAL.Formulation>();

        //        formulation_data = Mapper.Map<Models.Formulation, VCR_DAL.Formulation>(f);

        //        bool status = dal.update_formula_details(formulation_data, fid);
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
        //// GET: /Formulation/Delete/5

        public ActionResult Delete(string formulaid)
        {
            try
            {
                bool status = dal.Delete_formulation(formulaid);
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
