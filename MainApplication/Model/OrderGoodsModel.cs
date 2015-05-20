using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainApplication.Model
{
    class OrderGoodsModel
    {
        public int Id { get; set; }
        public GoodsModel Goods { get; set; }
        public int Count { get; set; }
        public string Module { get; set; }
        public double PriceOfUnit { get; set; }
        public string Comment { get; set; }
        public int OrderOrStorageOrSale { get; set; }
        public bool isDelete { get; set; }
    }
}
