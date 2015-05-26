using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApplication.Model
{
    class OrdersOrSalesCollection : ObservableCollection<DbOrdersOrSales>
    {
        public OrdersOrSalesCollection()
        {
            using (var db = new Db_StroikomEntities())
            {
                IQueryable<DbOrdersOrSales> or = db.OrdersOrSales.Include("Personnel").Include("Status").Include("Storage").Include("Partner").Include("OrderStorageSaleGoods");
                or.Where(o => o.Status_id != 3).ToList().ForEach(o =>
                {
                    o.Summa = o.OrderStorageSaleGoods.Sum(s => s.Count * s.PriceOfUnit);
                    this.Add(o);
                });
            }
        }

        public OrdersOrSalesCollection(bool isOrder)
        {
            using (var db = new Db_StroikomEntities())
            {
                IQueryable<DbOrdersOrSales> or = db.OrdersOrSales.Include("Personnel").Include("Status").Include("Storage").Include("Partner").Include("OrderStorageSaleGoods");
                or.Where(o => o.isOrder == isOrder && o.Status_id != 3 && o.Status_id != 5).ToList().ForEach(o =>
                {
                    o.Summa = o.OrderStorageSaleGoods.Sum(s => s.Count * s.PriceOfUnit);
                    this.Add(o);
                });
            }
        }

        public void AddOrders(DbOrdersOrSales ordersOrSales, OrderStorageSaleGoodsCollectoin orderStorageSaleGoodsCollectoin)
        {
            using (var db = new Db_StroikomEntities())
            {
                db.OrdersOrSales.Add(ordersOrSales);
                db.SaveChanges();
                int  i = ordersOrSales.IdOrderOrSale;

                orderStorageSaleGoodsCollectoin.SaveDb(ordersOrSales);

                IQueryable<DbOrdersOrSales> or = db.OrdersOrSales.Include("Personnel").Include("Status").Include("Storage").Include("Partner").Include("OrderStorageSaleGoods");

                DbOrdersOrSales tmp = or.Single(o => o.IdOrderOrSale == ordersOrSales.IdOrderOrSale);
                tmp.Summa = tmp.OrderStorageSaleGoods.Sum(s => s.Count * s.PriceOfUnit);
                this.Add(tmp);             
            }
        }

        public void EditStatus(DbOrdersOrSales os)
        {
            using (var db = new Db_StroikomEntities())
            {
                DbOrdersOrSales oos = db.OrdersOrSales.Single(o => o.IdOrderOrSale == os.IdOrderOrSale);
                oos.Status_id += 1;

                if (oos.Status_id == 3)
                {
                    foreach(var o in oos.OrderStorageSaleGoods)
                    {
                        o.OrderOrStorageOrSale = 2;
                    }
                }

                if (oos.Status_id == 6)
                {
                    oos.Status_id = 5;                                    
                }

                db.SaveChanges();
            }
        }
    }
}
