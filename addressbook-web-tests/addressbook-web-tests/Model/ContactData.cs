using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    internal class ContactData
    {
        private string name;
        private string surname = "";

        public ContactData (string name)
        {
            this.name = name;
        }
        public ContactData(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
    }
}
