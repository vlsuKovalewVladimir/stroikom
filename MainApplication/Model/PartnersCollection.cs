using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApplication.Model
{
    class PartnersCollection : ObservableCollection<DbPartners>
    {
        public PartnersCollection()
        {
            using (var db = new Db_StroikomEntities())
            {
                DbSet<DbPartners> st = db.Partners;
                st.ToList().ForEach(o => this.Add(o));
            }
        }

        public void AddPartner(DbPartners partner)
        {
            using (var db = new Db_StroikomEntities())
            {
                db.Partners.Add(partner);
                db.SaveChanges();
                this.Add(partner);
            }
        }
    }
}
