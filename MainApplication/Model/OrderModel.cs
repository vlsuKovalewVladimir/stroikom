using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel;

namespace MainApplication.Model
{
    class OrderModel : INotifyPropertyChanged
    {
        private int id;
        public int Id
        {
            set
            {
                id = value;
                NotifyPropertyChanged("Id");
            }
            get { return id; }
        }
        public DateTime Date { set; get; }
        public string Status { set; get; }
        public string PartnerName { set; get; }
        public DateTime PeriodDate { set; get; }
        public StorageModel Storage { set; get; }
        public PersonnelModel Personnel { set; get; }
        public string Comment { set; get; }
        public double Summa { set; get; }

        public ICollection<GoodsModel> Goods { set; get; }
        public ICollection<CashModel> Cash { set; get; }


        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
