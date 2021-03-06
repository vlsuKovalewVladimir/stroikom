//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MainApplication.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class DbOrdersOrSales
    {
        public DbOrdersOrSales()
        {
            this.Cashs = new HashSet<DbCash>();
            this.OrderStorageSaleGoods = new HashSet<DbOrderStorageSaleGoods>();
        }
    
        public int IdOrderOrSale { get; set; }
        public System.DateTime DateOrderOrSale { get; set; }
        public int Status_id { get; set; }
        public int Partner_id { get; set; }
        public System.DateTime PeriodDate { get; set; }
        public int Storage_id { get; set; }
        public bool isOrder { get; set; }
        public int Personnel_id { get; set; }
        public string Comment { get; set; }

        public double Summa { get; set; }
    
        public virtual ICollection<DbCash> Cashs { get; set; }
        public virtual DbPersonnels Personnel { get; set; }
        public virtual DbPartners Partner { get; set; }
        public virtual DbStatus Status { get; set; }
        public virtual ICollection<DbOrderStorageSaleGoods> OrderStorageSaleGoods { get; set; }
        public virtual DbStorages Storage { get; set; }
    }
}
