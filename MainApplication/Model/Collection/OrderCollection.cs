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
                                Date = o.DateOrderOrSale,
                                Status = o.Status.NameStatus,
                                Partner = new PartnerModel()
                                {
                                    Id = o.Partner.IdPartner,
                                    Name = o.Partner.Name,
                                    Adress = o.Partner.Adress,
                                    Data = o.Partner.Data,
                                    Phone = o.Partner.Phone,
                                    Relationship = "",
                                    Inn = o.Partner.Inn,
                                    Bik = o.Partner.Bik,
                                    Director = o.Partner.Director
                                },
                                Storage = new StorageModel()
                                {
                                    Id = o.Storage.IdStorage,
                                    Name = o.Storage.Name,
                                    Adress = o.Storage.Ardess
                                },
                                PeriodDate = o.PeriodDate,
                                Personnel = new PersonnelModel() 
                                {
                                    Id = o.Personnel.IdPersonnel, LastName = o.Personnel.LastName, FirstName = o.Personnel.FirstName,
                                    SoName = o.Personnel.SoName, Adress = o.Personnel.Adress, Phone = o.Personnel.Phone,
                                    Post = o.Personnel.Post.Post
                                },
                                Comment = o.Comment,
                                Summa = o.OrderStorageSaleGoods.Sum(s => s.Count * s.PriceOfUnit)
                            };

                order.ToList().ForEach(o => this.Add(o));
            }            
        }
    }
}
