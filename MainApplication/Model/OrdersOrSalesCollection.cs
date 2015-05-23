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
        public OrdersOrSalesCollection(bool isOrder)
        {
            using (var db = new Db_StroikomEntities())
            {
                IQueryable<DbOrdersOrSales> or = db.OrdersOrSales.Include("Personnel").Include("Status").Include("Storage").Include("Partner").Include("OrderStorageSaleGoods");
                or.Where(o => o.isOrder == isOrder).ToList().ForEach(o =>
                {
                    o.Summa = o.OrderStorageSaleGoods.Sum(s => s.Count * s.PriceOfUnit);
                    this.Add(o);
                });
            }
        }

        public void AddOrdersOrSales(DbOrdersOrSales ordersOrSales)
        {
            using (var db = new Db_StroikomEntities())
            {
                db.OrdersOrSales.Add(ordersOrSales);
                db.SaveChanges();
                int  i = ordersOrSales.IdOrderOrSale;

                IQueryable<DbOrdersOrSales> or = db.OrdersOrSales.Include("Personnel").Include("Status").Include("Storage").Include("Partner").Include("OrderStorageSaleGoods");

                this.Add(or.Single(o => o.IdOrderOrSale == ordersOrSales.IdOrderOrSale));
                
            }
        }

    }
}
