﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using VCRI.Models;


namespace VCRI.Controllers
{
    public class TransactionController : Controller
    {
        //
        // GET: /Transaction/

        VCRI_DAL.DataAccessLayer dal = new VCRI_DAL.DataAccessLayer();
        //VCRI_DAL.Transaction transaction_data = new VCRI_DAL.Transaction();
        Transaction transaction = new Transaction();  // Model CLASS
      

        public ActionResult Index()
        {
            
            List<VCRI_DAL.Transaction> list_transaction = dal.fetch_transaction();
            var list_transaction_Model = new List<Models.Transaction>();
            int i = 0;
            foreach (VCRI_DAL.Transaction tr in list_transaction)
            {

               list_transaction_Model.Add(Mapper.Map<Transaction>(tr));
               i++;
            }
            return View(list_transaction_Model);
        }


        //GET: /Transaction Create

        public ActionResult Create()
        {
            List<VCRI_DAL.Drug> list_drug = dal.get_drug();
            VCRI.Models.Drug d_Model = new Drug();
            List<Drug> list_drug_Model = new List<Drug>();
            foreach (VCRI_DAL.Drug d in list_drug)
            {
                list_drug_Model.Add(Mapper.Map<Drug>(d));
            }

            ViewData["drug"] = list_drug_Model;
            return View();
        }

        [HttpPost]
        public ActionResult CreateTransaction(FormCollection form)
        {
            try
            {
                ULogin trd_User = (ULogin)Session["user_ID"];

                transaction.TransactionID = "";
                transaction.Drug_Code = form["drug"];
                transaction.Drug_Count = Convert.ToInt32(form["Drug_Count"]);
                transaction.Sold_By = trd_User.user_ID ;
                transaction.Sold_Datetime = System.DateTime.Now;
                transaction.Comment = form["Comment"];
                transaction.BuyerName = form["BuyerName"];

               // am testing here

                //  Mapper.CreateMap<Models.Transaction, VCRI_DAL.Transaction>();
             //  transaction_data = Mapper.Map<Models.Transaction, VCRI_DAL.Transaction>(transaction);

                //transaction_data = Mapper.Map< VCRI_DAL.Transaction>(transaction);

                //bool status = dal.Create_Transaction(transaction_data);

                bool status = dal.Create_Transaction(Mapper.Map<VCRI_DAL.Transaction>(transaction));

                if (status)
                {
                    if (dal.update_stock(transaction.Drug_Code, Convert.ToInt32(form["Drug_Count"])))
                    {
                        TempData["msg"] = "Data Inserted Successfully";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View("Invalid_user");
                    }
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

        #region "DELETE  / EDIT  "
        ////
        //// GET: /Transaction/Edit/5

        //public ActionResult Edit(string transactid)
        //{
        //    //Mapper.CreateMap<VCRI_DAL.Drug, Models.Drug>();
        //    //Mapper.CreateMap<Models.Drug, VCRI_DAL.Drug>();


        //    List<VCRI_DAL.Drug> list_drug = dal.fetch_drug();
        //    VCRI.Models.Drug d_Model = new Drug();
        //    List<Drug> list_drug_Model = new List<Drug>();
        //    foreach (VCRI_DAL.Drug t1 in list_drug)
        //    {
        //        //list_drug_Model.Add(Mapper.Map<VCRI_DAL.Drug, VCRI.Models.Drug>(t1));
        //        list_drug_Model.Add(Mapper.Map<Drug>(t1));

        //    }

        //    ViewData["drug"] = list_drug_Model;
        //    transaction_data = dal.get_transaction_details(transactid);
        //    ViewData["current_drug"] = (Mapper.Map<VCRI_DAL.Drug, VCRI.Models.Drug>(dal.get_drug_details(transaction_data.Drug_Code))).Drug_Name;
        //    transaction = Mapper.Map<VCRI_DAL.Transaction, Models.Transaction>(transaction_data);
        //    return View(transaction);
        //}

        ////
        //// POST: /Transaction/Edit/5

        //[HttpPost]
        //public ActionResult Edit(Models.Transaction t, FormCollection collection)
        //{
        //    try
        //    {

        //        string tid = t.TransactionID;
        //        //Mapper.CreateMap<Models.Transaction, VCRI_DAL.Transaction>();
        //        t.Drug_Code = collection["drug"];
        //        //transaction_data = Mapper.Map<Models.Transaction, VCRI_DAL.Transaction>(t);
        //        transaction_data = Mapper.Map<VCRI_DAL.Transaction>(t);

        //        bool status = dal.update_transact_details(transaction_data, tid);
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
        //// GET: /Transaction/Delete/5

        //public ActionResult Delete(string transactid)
        //{
        //    try
        //    {
        //        bool status = dal.Delete_transaction(transactid);
        //        if (status)
        //        {
        //            TempData["msg"] = "Data Deleted Successfully";
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

        //[HttpPost]
        //public string getformulation(string id)
        //{
        //        string formula_name = dal.get_formulation_value(id.Trim());
        //        return formula_name;

        //}

        #endregion
    }
}
