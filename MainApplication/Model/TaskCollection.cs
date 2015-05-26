using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApplication.Model
{
    class TaskCollection : ObservableCollection<DbTask>
    {
        public TaskCollection()
        {
            using (var db = new Db_StroikomEntities())
            {
                IQueryable<DbTask> task = db.Tasks.Where(t => t.Performance);
                task.ToList().ForEach(c => this.Add(c));
            }
        }
    }
}
