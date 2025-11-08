using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Input;

namespace MSSU_CIS310_MVC.model
{
    class Translation
    {
        private int id;
        private string table;
        private string abbreviation;

        public Translation(int id, string table, string abbreviation)
        {
            this.id = id;
            this.table = table;
            this.abbreviation = abbreviation;
        }

        public int Id
        {
            get { return id; }
        }

        public string Table
        {
            get { return table; }
        }

        public string Abbreviation
        {
            get { return abbreviation; }
        }
    }
}
