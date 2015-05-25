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
        public OrderStorageSaleGoodsCollectoin() { }

        public OrderStorageSaleGoodsCollectoin(int i)
        {
            using (var db = new Db_StroikomEntities())
            {
                IQueryable<DbOrderStorageSaleGoods> ossg = db.OrderStorageSaleGoods.Include("Module").Include("Goods").Include("OrderOrSale");
                ossg.Where(o => o.OrderOrStorageOrSale == i && !o.isDelete).ToList().ForEach(o => { o.NameStorage = o.OrderOrSale.Storage.Name; o.NameAdress = o.OrderOrSale.Storage.Ardess; this.Add(o); });
            }
        }

        public OrderStorageSaleGoodsCollectoin(DbOrdersOrSales or)
        {
            using (var db = new Db_StroikomEntities())
            {
                IQueryable<DbOrderStorageSaleGoods> ossg = db.OrderStorageSaleGoods.Include("Module").Include("Goods");
                ossg.Where(o => o.OrderOrSale_Id == or.IdOrderOrSale && !o.isDelete).ToList().ForEach(o => this.Add(o));
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
