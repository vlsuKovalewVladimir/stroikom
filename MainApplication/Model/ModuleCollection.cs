using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApplication.Model
{
    class ModuleCollection : ObservableCollection<DbModules>
    {
        public ModuleCollection()
        {
            using (var db = new Db_StroikomEntities())
            {
                DbSet<DbModules> modules = db.Modules;
                modules.ToList().ForEach(m => this.Add(m));
            }
        }
    }
}
