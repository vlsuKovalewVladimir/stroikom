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
    
    public partial class DbModules
    {
        public DbModules()
        {
            this.OrderStorageSaleGoods = new HashSet<DbOrderStorageSaleGoods>();
        }
    
        public int IdModule { get; set; }
        public string LittleModule { get; set; }
        public string FullModule { get; set; }
    
        public virtual ICollection<DbOrderStorageSaleGoods> OrderStorageSaleGoods { get; set; }
    }
}
