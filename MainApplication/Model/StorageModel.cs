using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainApplication.Model
{
    class StorageModel
    {
        public StorageModel() { }
        public StorageModel(int id, string name, string adress)
        {
            this.Id = id;
            this.Name = name;
            this.Adress = adress;
        }

        
        public int Id { set; get; }
        public string Name { set; get; }
        public string Adress { set; get; }
    }
}
