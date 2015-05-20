using System;

namespace MainApplication.Model
{
    class PartnerModel
    {
        public PartnerModel() {}
        public PartnerModel(int id, string name, string adress, DateTime data, string phone, string relationship, string inn, string bik, string director)
        {
            this.Id = id;
            this.Name = name;
            this.Adress = adress;
            this.Data = data;
            this.Phone = phone;
            this.Relationship = relationship;
            this.Inn = inn;
            this.Bik = bik;
            this.Director = director;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public DateTime Data { get; set; }
        public string Phone { get; set; }
        public string Relationship { get; set; }
        public string Inn { get; set; }
        public string Bik { get; set; }
        public string Director { get; set; }
    }
}
