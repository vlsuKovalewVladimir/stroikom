using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApplication.Model
{
    class StoragesCollection : ObservableCollection<DbStorages>
    {
        public StoragesCollection()
        {
            using (var db = new Db_StroikomEntities())
            {
                DbSet<DbStorages> st = db.Storages;
                st.ToList().ForEach(o =>
                {
                    this.Add(o);
                });
            }
        }

        public void AddStorage(DbStorages storage)
        {
            using (var db = new Db_StroikomEntities())
            {
                db.Storages.Add(storage);
                db.SaveChanges();
                this.Add(storage);
            }
        }
    }
}
