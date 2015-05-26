using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApplication.Model
{
    class OperationsCollection : ObservableCollection<DbOperations>
    {
        public OperationsCollection()
        {
            using (var db = new Db_StroikomEntities())
            {
                DbSet<DbOperations> operations = db.Operations;
                operations.ToList().ForEach(o => this.Add(o));
            }
        }
    }
}
