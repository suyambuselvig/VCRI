using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VCRI.Controllers
{
    public class DosageController : Controller
    {

        VCR_DAL.DataAccessLayer dal = new VCR_DAL.DataAccessLayer();
        VCRI.Models.Dosage dosage = new Models.Dosage();
        VCR_DAL.Dosage dosage_data = new VCR_DAL.Dosage();
        //public ActionResult Index()
        //{
        //    Mapper.CreateMap<VCR_DAL.Dosage, Models.Dosage>().ForMember(dos=>dos.uname,map=>map.MapFrom(name=>name.Login.username));
        //    Mapper.CreateMap<Models.Dosage, VCR_DAL.Dosage>();
        //    List<VCR_DAL.Dosage> list_dosage = dal.fetch_Dosage();
        //    var list_dosage_Model = new List<Models.Dosage>();
        //    int i = 0;
        //    foreach (VCR_DAL.Dosage tr in list_dosage)
        //    {
        //        list_dosage_Model.Add(Mapper.Map<VCR_DAL.Dosage, Models.Dosage>(tr));
        //        i++;
        //    }
        //    return View(list_dosage_Model);
        //}


        //// GET: /Dosage/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////
        //// POST: /Dosage/Create

        //[HttpPost]
        //public ActionResult CreateDosage(FormCollection collection)
        //{
        //    try
        //    {
        //        VCRI.Models.Login dos_User = (VCRI.Models.Login)Session["user_d"];
        //        dosage.Dosage_Code = "";
        //        dosage.Dosage_Description = collection["Dosage_Description"];
        //        dosage.Created_By = dos_User.userid;
        //        dosage.Created_Datetime = System.DateTime.Now;
        //        Mapper.CreateMap<Models.Dosage, VCR_DAL.Dosage>();
        //        dosage_data = Mapper.Map<Models.Dosage, VCR_DAL.Dosage>(dosage);
        //        bool status = dal.Create_Dosage(dosage_data);
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
        //    catch(Exception e)
        //    {
        //        return View("Invalid_user");
        //    }
        //}

        ////
        //// GET: /Dosage/Edit/5

        //public ActionResult Edit(string dosageid)
        //{
        //    Mapper.CreateMap<VCR_DAL.Dosage, Models.Dosage>();
        //    dosage_data = dal.get_dosage_details(dosageid);
        //    dosage = Mapper.Map<VCR_DAL.Dosage, Models.Dosage>(dosage_data);
        //    return View(dosage);
        //}

        ////
        //// POST: /Dosage/Edit/5

        //[HttpPost]
        //public ActionResult Edit(Models.Dosage t)
        //{
        //    try
        //    {
        //        string tid = t.Dosage_Code;
        //        Mapper.CreateMap<Models.Dosage, VCR_DAL.Dosage>();

        //        dosage_data = Mapper.Map<Models.Dosage, VCR_DAL.Dosage>(t);

        //        bool status = dal.update_dosage_details(dosage_data, tid);
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


        //// POST: /Dosage/Delete/5

        public ActionResult Delete(string dosageid)
        {
            try
            {
                bool status = dal.Delete_dosage(dosageid);
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
