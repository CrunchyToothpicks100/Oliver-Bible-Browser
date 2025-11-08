using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSU_CIS310_MVC.model
{
    class Book
    {
        private int id;
        private string name;

        public Book(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
        }
    }
}
