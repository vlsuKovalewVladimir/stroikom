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
    
    public partial class DbTask
    {
        public int IdTask { get; set; }
        public string NameTask { get; set; }
        public System.DateTime StartDate { get; set; }
        public int Time { get; set; }
        public bool Performance { get; set; }
        public int Personnel_id { get; set; }
    
        public virtual DbPersonnels Personnel { get; set; }
    }
}
