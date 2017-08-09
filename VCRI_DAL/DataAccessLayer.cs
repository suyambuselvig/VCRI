using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCRI_DAL
{
    public class DataAccessLayer : VCRIEntities
    {
        VCRIEntities dbContext = new VCRIEntities();
        VCRI_DAL.ULogin login_user = new ULogin();
        VCRI_DAL.Trade trade_value = new Trade();
        VCRI_DAL.Dosage dosage_value = new Dosage();
        VCRI_DAL.Formulation formula_value = new Formulation();
        VCRI_DAL.Drug drug_value = new Drug();
        VCRI_DAL.Stock stock_value = new Stock();
        VCRI_DAL.PurchaseOrder  order_value = new PurchaseOrder();    
        VCRI_DAL.Transaction transact_value = new Transaction();

        public ULogin Authenticate(String uid, String pwd)
        {
            var credentials = (dbContext.ULogins.Where(a => (a.user_ID.Equals(uid)) && (a.user_Pwd.Equals(pwd)))).FirstOrDefault();
            if (credentials != null)
            {
                ULogin l = new ULogin();
                l = (ULogin)credentials;
                return l;
            }
            else
            {
                return null;
            }

        }
        public string get_formulation_value(string drugid)
        {

            drug_value = (VCRI_DAL.Drug)(from p in dbContext.Drugs select p).Where(p => p.drug_Code.Equals(drugid)).FirstOrDefault();
            formula_value = (VCRI_DAL.Formulation)dbContext.Formulations.Find(drug_value.formulation_Code);
            stock_value  = (VCRI_DAL.Stock)(from p in dbContext.Stocks select p).Where(p => p.stock_Code.Equals(drugid)).Where(p => p.expiry_Date >= DateTime.Now).FirstOrDefault();
            return formula_value.shortName  + "," + stock_value.stock_BalanceQuantity;
        }
        public bool Create_User(ULogin l)
        {
            try
            {
                dbContext.ULogins.Add(l);
                dbContext.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<VCRI_DAL.ULogin> fetch_User()
        {
            var login_table = (from p in dbContext.ULogins select p).ToList();
            return login_table;
        }
        public bool Create_Trade(Trade t)
        {
            try
            {
                t.trade_Code = fetch_PK("Trade");
                dbContext.Trades.Add(t);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Create_Drug(Drug d)
        {
            try
            {
                d.drug_Code = fetch_PK("Drug");
                dbContext.Drugs.Add(d);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Create_Order(PurchaseOrder o)
        {
            try
            {
                o.po_Code  = fetch_PK("PurchaseOrder");
                dbContext.PurchaseOrders.Add(o);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Create_Stock(Stock s)
        {
            try
            {
                s.stock_Code = dbContext.Database.SqlQuery<string>("Select NEXT VALUE for dbo.stock_code;").FirstOrDefault();
                dbContext.Stocks.Add(s);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Create_Transaction(Transaction t)
        {
            try
            {
                t.transaction_Code = fetch_PK("SaleTransaction");
                dbContext.Transactions.Add(t);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<VCRI_DAL.Trade> fetch_trade()
        {
            try
            {
                var trade_table = (from p in dbContext.Trades select p).ToList();
                return trade_table;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<VCRI_DAL.Transaction> fetch_transaction()
        {
            try
            {
                var transaction_table = (from p in dbContext.Transactions select p).ToList();
                return transaction_table;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<VCRI_DAL.Drug> get_drug()
        {
            try
            {
                var drug_table = (from p in dbContext.Drugs select p).ToList(); //.Where(p => p.Stock.Expiry_Date >= DateTime.Now).ToList();
                return drug_table;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool update_stock(string drug, int count)
        {
            var original = dbContext.Stocks.Find(drug);
            try
            {
                original.stock_BalanceQuantity -= count;
                dbContext.Entry(original).CurrentValues.SetValues(original);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<VCRI_DAL.Drug> fetch_drug()
        {
            try
            {
                var drug_table = (from p in dbContext.Drugs select p).ToList();
                return drug_table;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<VCRI_DAL.Stock> fetch_stock()
        {
            try
            {
                var stock_table = (from p in dbContext.Stocks select p).ToList();
                return stock_table;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<VCRI_DAL.PurchaseOrder > fetch_Order()
        {
            try
            {
                var order_table = (from p in dbContext.PurchaseOrders  select p).ToList();
                return order_table;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<VCRI_DAL.Dosage> fetch_Dosage()
        {
            try
            {
                var dosage_table = (from p in dbContext.Dosages select p).ToList();
                return dosage_table;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<VCRI_DAL.Formulation> fetch_Formulations()
        {
            try
            {
                var formula_table = (from p in dbContext.Formulations select p).ToList();
                return formula_table;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Create_Formulation(Formulation f)
        {
            try
            {
                f.formulation_code = fetch_PK("Formulation");
                dbContext.Formulations.Add(f);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public VCRI_DAL.Formulation get_formula_details(String formulaid)
        {
            try
            {
                var formula_table = (VCRI_DAL.Formulation)(from p in dbContext.Formulations select p).Where(p => p.formulation_code.Equals(formulaid)).FirstOrDefault();
                return formula_table;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public VCRI_DAL.Drug get_drug_details(String drugid)
        {
            try
            {
                var drug_table = (VCRI_DAL.Drug)(from p in dbContext.Drugs select p).Where(p => p.drug_Code.Equals(drugid)).FirstOrDefault();
                return drug_table;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public VCRI_DAL.PurchaseOrder  get_order_details(String orderid)
        {
            try
            {
                var order_table = (VCRI_DAL.PurchaseOrder )(from p in dbContext.PurchaseOrders  select p).Where(p => p.po_Code.Equals(orderid)).FirstOrDefault();
                return order_table;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public VCRI_DAL.Transaction get_transaction_details(String transactid)
        {
            try
            {
                var transact_table = (VCRI_DAL.Transaction)(from p in dbContext.Transactions select p).Where(p => p.transaction_Code.Equals(transactid)).FirstOrDefault();
                return transact_table;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public VCRI_DAL.Stock get_stock_details(String drugid)
        {
            try
            {
                var stock_table = (VCRI_DAL.Stock)(from p in dbContext.Stocks select p).Where(p => p.stock_Code.Equals(drugid)).FirstOrDefault();
                return stock_table;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool update_formula_details(Formulation formula, String formulaid)
        {
            var original = dbContext.Formulations.Find(formulaid);
            try
            {
                dbContext.Entry(original).CurrentValues.SetValues(formula);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool update_drug_details(Drug drug, String drugid)
        {
            var original = dbContext.Drugs.Find(drugid);
            try
            {
                dbContext.Entry(original).CurrentValues.SetValues(drug);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool update_order_details(PurchaseOrder  order, String orderid)
        {
            var original = dbContext.PurchaseOrders.Find(orderid);
            try
            {
                dbContext.Entry(original).CurrentValues.SetValues(order);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool update_transact_details(Transaction transact, String transactid)
        {
            var original = dbContext.Transactions.Find(transactid);
            try
            {
                dbContext.Entry(original).CurrentValues.SetValues(transact);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool update_stock_details(Stock stock, String drugid)
        {
            var original = dbContext.Stocks.Find(drugid);
            try
            {
                dbContext.Entry(original).CurrentValues.SetValues(stock);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Create_Dosage(Dosage d)
        {
            try
            {
                d.dosage_Code = fetch_PK("Dosage");
                dbContext.Dosages.Add(d);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public VCRI_DAL.Trade get_trade_details(String tradeid)
        {
            try
            {
                var trade_table = (VCRI_DAL.Trade)(from p in dbContext.Trades select p).Where(p => p.trade_Code.Equals(tradeid)).FirstOrDefault();
                return trade_table;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public VCRI_DAL.Dosage get_dosage_details(String dosageid)
        {
            try
            {
                var dosage_table = (VCRI_DAL.Dosage)(from p in dbContext.Dosages select p).Where(p => p.dosage_Code.Equals(dosageid)).FirstOrDefault();
                return dosage_table;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool update_dosage_details(Dosage dosage, String dosageid)
        {
            var original = dbContext.Dosages.Find(dosageid);
            try
            {
                dbContext.Entry(original).CurrentValues.SetValues(dosage);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool update_trade_details(Trade trade, String tradeid)
        {
            var original = dbContext.Trades.Find(tradeid);
            try
            {
                dbContext.Entry(original).CurrentValues.SetValues(trade);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public String fetch_PK(String table)
        {
            try
            {
                int value = -1;
                if (table.Equals("SaleTransaction"))
                {
                    value = dbContext.Database.SqlQuery<int>("Select NEXT VALUE for dbo.TransactionID;").FirstOrDefault();
                }
                else
                    value = dbContext.Database.SqlQuery<int>("Select NEXT VALUE for dbo." + table + "_Code;").FirstOrDefault();

                String pk_value = table.Substring(0, 2) + value.ToString();

                return pk_value;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public bool Delete_User(String userid)
        {
            try
            {
                login_user = (VCRI_DAL.ULogin)(dbContext.ULogins.Where(p => p.user_ID.Equals(userid)).FirstOrDefault());
                dbContext.ULogins.Remove(login_user);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public bool Delete_trade(String tradeid)
        {
            try
            {
                trade_value = (VCRI_DAL.Trade)(dbContext.Trades.Where(p => p.trade_Code.Equals(tradeid)).FirstOrDefault());
                dbContext.Trades.Remove(trade_value);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public bool Delete_transaction(String transactid)
        {
            try
            {
                transact_value = (VCRI_DAL.Transaction)(dbContext.Transactions.Where(p => p.transaction_Code.Equals(transactid)).FirstOrDefault());
                dbContext.Transactions.Remove(transact_value);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public bool Delete_drug(String drugid)
        {
            try
            {
                drug_value = (VCRI_DAL.Drug)(dbContext.Drugs.Where(p => p.drug_Code.Equals(drugid)).FirstOrDefault());
                dbContext.Drugs.Remove(drug_value);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public bool Delete_stock(String drugid)
        {
            try
            {
                stock_value = (VCRI_DAL.Stock)(dbContext.Stocks.Where(p => p.stock_Code.Equals(drugid)).FirstOrDefault());
                dbContext.Stocks.Remove(stock_value);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool Delete_Order(String orderid)
        {
            try
            {
                order_value = (VCRI_DAL.PurchaseOrder )(dbContext.PurchaseOrders.Where(p => p.po_Code.Equals(orderid)).FirstOrDefault());
                dbContext.PurchaseOrders.Remove(order_value);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public bool Delete_dosage(String dosageid)
        {
            try
            {
                dosage_value = (VCRI_DAL.Dosage)(dbContext.Dosages.Where(p => p.dosage_Code.Equals(dosageid)).FirstOrDefault());
                dbContext.Dosages.Remove(dosage_value);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public bool Delete_formulation(String formulaid)
        {
            try
            {
                formula_value = (VCRI_DAL.Formulation)(dbContext.Formulations.Where(p => p.formulation_code.Equals(formulaid)).FirstOrDefault());
                dbContext.Formulations.Remove(formula_value);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

    }
}


