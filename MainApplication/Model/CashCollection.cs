using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApplication.Model
{
    class CashCollection : ObservableCollection<DbCash>
    {
        public CashCollection()
        {
            using (var db = new Db_StroikomEntities())
            {
                IQueryable<DbCash> cash = db.Cash.Include("Operation").Include("OrderOrSale");
                cash.ToList().ForEach(c => this.Add(c));
            }
        }

        public void AddCash(DbCash cash)
        {
            using (var db = new Db_StroikomEntities())
            {
                db.Cash.Add(cash);
                db.SaveChanges();

                this.Add(cash);
            }
        } 
    }
}
