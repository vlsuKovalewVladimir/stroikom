using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainApplication.Model
{
    class PersonnelModel
    {
        public PersonnelModel() {}
        public PersonnelModel(int id, string lastName, string firstName, string soName)
        {
            this.Id = id;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.SoName = soName;
        }

        public int Id { set; get; }
        public string LastName { set; get; }
        public string FirstName { set; get; }
        public string SoName { set; get; }
        public DateTime Dtr { get; set; }
        public bool Gender { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Post { get; set; }
        public string Password { get; set; }

        public string LittleName 
        {
            get { return String.Format("{0} {1}.{2}.", LastName, FirstName[0], SoName[0]); }
        }

        public string FullName
        {
            get { return String.Format("{0} {1} {2}", LastName, FirstName, SoName); }
        }
    }
}
