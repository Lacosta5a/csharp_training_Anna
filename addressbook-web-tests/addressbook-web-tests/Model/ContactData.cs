using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string name;
        public string surname = "";

        public ContactData (string name)
        {
            this.name = name;
        }

        public bool Equals (ContactData other)
        {
            if (Object.ReferenceEquals(other.Surname, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(other.Name, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this.Surname, other))
            {
                return true;
            }
            if (Object.ReferenceEquals(this.Name, other))
            {
                return true;
            }
            return Surname == other.Surname && Name == other.Name; 
        }

        public override int GetHashCode()
        {
            return Surname.GetHashCode() + Name.GetHashCode();
        }

        public override string ToString()
        {
            return Surname + Name;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other.Surname, null))
            {
                return 1;
            }
            if (Object.ReferenceEquals(other.Name, null))
            {
                return 1;
            }
            return Surname.CompareTo(other.Surname) + Name.CompareTo(other.Name);
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
