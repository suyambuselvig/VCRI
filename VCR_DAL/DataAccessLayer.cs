using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VCR_DAL
{
    public class DataAccessLayer:VCRIEntities1
    {
        VCRIEntities1 dbContext = new VCRIEntities1();
        VCR_DAL.Login login_user = new Login();
        VCR_DAL.Trade trade_value = new Trade();
        VCR_DAL.Dosage dosage_value = new Dosage();
        VCR_DAL.Formulation formula_value = new Formulation();
        VCR_DAL.Drug drug_value = new Drug();
        VCR_DAL.Stock stock_value = new Stock();
        VCR_DAL.Order order_value = new Order();
        VCR_DAL.Transaction transact_value = new Transaction();
        public Login Authenticate(String uid, String pwd)
        {
            var credentials=(dbContext.Logins.Where(a => (a.userid.Equals(uid)) && (a.passwrd.Equals(pwd)))).FirstOrDefault();
            if (credentials!=null)
            {
                Login l = new Login();
                l = (Login)credentials;
                return l;
            }
            else
            {
                return null;
            }

        }
        public string get_formulation_value(string drugid)
        {
            
            VCR_DAL.Drug drug_details= (VCR_DAL.Drug)(from p in dbContext.Drugs select p).Where(p => p.Drug_Code.Equals(drugid)).FirstOrDefault();
            VCR_DAL.Formulation formulation_details = (VCR_DAL.Formulation)dbContext.Formulations.Find(drug_details.Formulation_code);
            VCR_DAL.Stock stock_details= (VCR_DAL.Stock)(from p in dbContext.Stocks select p).Where(p => p.Drug_Code.Equals(drugid)).Where(p=>p.Expiry_Date>=DateTime.Now).FirstOrDefault();
            return formulation_details.ShortName+","+stock_details.Quantity ;
        }
        public bool Create_User(Login l)
        {
            try
            {
                dbContext.Logins.Add(l);
                dbContext.SaveChanges();
                return true;
                
            }
            catch (Exception e)
            {
                return false ;
            }
        }
        public List<VCR_DAL.Login> fetch_User()
        {
            var login_table = (from p in dbContext.Logins select p).ToList();
            return login_table;
        }
        public bool Create_Trade(Trade t)
        {
            try
            {
                t.Trade_Code = fetch_PK("Trade");
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
                d.Drug_Code = fetch_PK("Drug");
                dbContext.Drugs.Add(d);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Create_Order(Order o)
        {
            try
            {
                o.Order_Code = fetch_PK("Order");
                dbContext.Orders.Add(o);
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
                s.Stock_ID = dbContext.Database.SqlQuery<int>("Select NEXT VALUE for dbo.Stock_ID;").FirstOrDefault();
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
                t.TransactionID= fetch_PK("SaleTransaction");
                dbContext.Transactions.Add(t);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<VCR_DAL.Trade> fetch_trade()
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
        public List<VCR_DAL.Transaction> fetch_transaction()
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
        public List<VCR_DAL.Drug> get_drug()
        {
            try
            {
                var drug_table = (from p in dbContext.Drugs select p).Where(p => p.Stock.Expiry_Date >= DateTime.Now).ToList();
                return drug_table;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool update_stock(string drug,int count)
        {
            var original = dbContext.Stocks.Find(drug);
            try
            {
                original.Quantity -= count;
                dbContext.Entry(original).CurrentValues.SetValues(original);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<VCR_DAL.Drug> fetch_drug()
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
        public List<VCR_DAL.Stock> fetch_stock()
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
        public List<VCR_DAL.Order> fetch_Order()
        {
            try
            {
                var order_table = (from p in dbContext.Orders select p).ToList();
                return order_table;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<VCR_DAL.Dosage> fetch_Dosage()
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
        public List<VCR_DAL.Formulation> fetch_Formulations()
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
                f.Formulation_code = fetch_PK("Formulation");
                dbContext.Formulations.Add(f);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public VCR_DAL.Formulation get_formula_details(String formulaid)
        {
            try
            {
                var formula_table = (VCR_DAL.Formulation)(from p in dbContext.Formulations select p).Where(p => p.Formulation_code.Equals(formulaid)).FirstOrDefault();
                return formula_table;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public VCR_DAL.Drug get_drug_details(String drugid)
        {
            try
            {
                var drug_table = (VCR_DAL.Drug)(from p in dbContext.Drugs select p).Where(p => p.Drug_Code.Equals(drugid)).FirstOrDefault();
                return drug_table;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public VCR_DAL.Order get_order_details(String orderid)
        {
            try
            {
                var order_table = (VCR_DAL.Order)(from p in dbContext.Orders select p).Where(p => p.Order_Code.Equals(orderid)).FirstOrDefault();
                return order_table;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public VCR_DAL.Transaction get_transaction_details(String transactid)
        {
            try
            {
                var transact_table = (VCR_DAL.Transaction)(from p in dbContext.Transactions select p).Where(p => p.TransactionID.Equals(transactid)).FirstOrDefault();
                return transact_table;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public VCR_DAL.Stock get_stock_details(String drugid)
        {
            try
            {
                var stock_table = (VCR_DAL.Stock)(from p in dbContext.Stocks select p).Where(p => p.Drug_Code.Equals(drugid)).FirstOrDefault();
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
        public bool update_order_details(Order order, String orderid)
        {
            var original = dbContext.Orders.Find(orderid);
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
                d.Dosage_Code = fetch_PK("Dosage");
                dbContext.Dosages.Add(d);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public VCR_DAL.Trade get_trade_details(String tradeid)
        {
            try
            {
                var trade_table = (VCR_DAL.Trade)(from p in dbContext.Trades select p).Where(p => p.Trade_Code.Equals(tradeid)).FirstOrDefault();
                return trade_table;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public VCR_DAL.Dosage get_dosage_details(String dosageid)
        {
            try
            {
                var dosage_table = (VCR_DAL.Dosage)(from p in dbContext.Dosages select p).Where(p => p.Dosage_Code.Equals(dosageid)).FirstOrDefault();
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
        public bool update_trade_details(Trade trade,String tradeid) 
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
                int value=-1;
                if(table.Equals("SaleTransaction"))
                {
                    value = dbContext.Database.SqlQuery<int>("Select NEXT VALUE for dbo.TransactionID;").FirstOrDefault();
                }
                else
                    value = dbContext.Database.SqlQuery<int>("Select NEXT VALUE for dbo."+table+"_Code;").FirstOrDefault();

                String pk_value = table.Substring(0,2)+value.ToString();
                
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
                login_user = (VCR_DAL.Login)(dbContext.Logins.Where(p => p.userid.Equals(userid)).FirstOrDefault());
                dbContext.Logins.Remove(login_user);
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
                trade_value = (VCR_DAL.Trade)(dbContext.Trades.Where(p => p.Trade_Code.Equals(tradeid)).FirstOrDefault());
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
                transact_value = (VCR_DAL.Transaction)(dbContext.Transactions.Where(p => p.TransactionID.Equals(transactid)).FirstOrDefault());
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
                drug_value = (VCR_DAL.Drug)(dbContext.Drugs.Where(p => p.Drug_Code.Equals(drugid)).FirstOrDefault());
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
                stock_value = (VCR_DAL.Stock)(dbContext.Stocks.Where(p => p.Drug_Code.Equals(drugid)).FirstOrDefault());
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
                order_value = (VCR_DAL.Order)(dbContext.Orders.Where(p => p.Order_Code.Equals(orderid)).FirstOrDefault());
                dbContext.Orders.Remove(order_value);
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
                dosage_value = (VCR_DAL.Dosage)(dbContext.Dosages.Where(p => p.Dosage_Code.Equals(dosageid)).FirstOrDefault());
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
                formula_value = (VCR_DAL.Formulation)(dbContext.Formulations.Where(p => p.Formulation_code.Equals(formulaid)).FirstOrDefault());
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
