using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MainApplication.Model
{
    class OrderCollection : ObservableCollection<OrderModel>
    {
        public OrderCollection()
        {
            using (var db = new Db_StroikomEntities())
            {
                var order = from o in db.OrdersOrSales
                            where o.isOrder == true
                            select new OrderModel
                            {
                                Id = o.IdOrderOrSale,
                                Date = o.DateOrderOrSale
                            };

                order.ToList().ForEach(o => this.Add(o));
            }            
        }
    }
}
