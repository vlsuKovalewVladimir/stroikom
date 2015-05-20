using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainApplication.Model
{
    class CashModel
    {
        public int Id { get; set; }
        public string Discription { get; set; }
        public DateTime Date { get; set; }
        public double Sum { get; set; }
        public string Operation { get; set; }
        public string Dogovor { get; set; }
    }
}
