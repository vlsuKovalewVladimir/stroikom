using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApplication.Model
{
    class OrderStorageSaleGoodsCollectoin : ObservableCollection<DbOrderStorageSaleGoods>
    {
        public OrderStorageSaleGoodsCollectoin(){}

        public OrderStorageSaleGoodsCollectoin(DbOrdersOrSales or)
        {
            using (var db = new Db_StroikomEntities())
            {
                IQueryable<DbOrderStorageSaleGoods> ossg = db.OrderStorageSaleGoods.Include("Module");
                ossg.Where(o => o.OrderOrSale_Id == or.IdOrderOrSale).ToList().ForEach(o => this.Add(o));
            }
        }

        public void AddGoodsNoSaveDb(DbOrderStorageSaleGoods ossg)
        {
            this.Add(ossg);
        }

        public void SaveDb(DbOrdersOrSales or)
        {
            using (var db = new Db_StroikomEntities())
            {
                foreach (var i in this)
                {
                    i.OrderOrSale_Id = or.IdOrderOrSale;
                    db.OrderStorageSaleGoods.Add(i);
                }
                db.SaveChanges();
            }
        }
    }
}
