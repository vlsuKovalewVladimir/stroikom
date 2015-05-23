using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApplication.Model
{
    class GoodsCollection : ObservableCollection<DbGoods>
    {
        public GoodsCollection()
        {
            using (var db = new Db_StroikomEntities())
            {
                DbSet<DbGoods> goods = db.Goods;
                goods.ToList().ForEach(g => this.Add(g));
            }
        }
    }
}
