﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApplication
{
    class Parameters
    {
        private Parameters() { }

        private static readonly Parameters instance = new Parameters();
        public static Parameters Instance
        {
            get { return Parameters.instance; }
        }

        public string Key = "f0b020bd387189lkh39dc3efa8b08fad20bc9d98";
        public string NameFileConfig = "configuration.config";
        public string ConnectionDb = "";
        public Model.PersonnelModel Personnel { get; set; }

        public StartWindow StartWindowCurrent { get; set; }
        public MainWindow MainWindowCurrent { get; set; }
    }
}
