using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel;

namespace MainApplication.Model
{
    class OrderModel
    {
        public int Id { set; get; }
        public DateTime Date { set; get; }
        public string Status { set; get; }
        public PartnerModel Partner { set; get; }
        public DateTime PeriodDate { set; get; }
        public StorageModel Storage { set; get; }
        public PersonnelModel Personnel { set; get; }
        public string Comment { set; get; }
        public double Summa { set; get; }

        public ICollection<GoodsModel> Goods 
        {
            get
            {
                using (var db = new Db_StroikomEntities())
                {
                    var goods = from g in db.OrderStorageSaleGoods
                                where g.OrderOrSale_Id == this.Id
                                select new GoodsModel()
                                {
                                    Name = g.Goods.Name
                                };

                    return goods.ToList();
                } 
            }

            
        }

        public ICollection<CashModel> Cash { set; get; }
    }
}
