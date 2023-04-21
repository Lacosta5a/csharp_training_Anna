﻿using OpenQA.Selenium.Internal;
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
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
           
            if (Object.ReferenceEquals(Surname, other.Surname))
            {
                return true;
            }
            if (Object.ReferenceEquals(Name, other.Name))
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
            if (Object.ReferenceEquals(other.Surname, Surname))
            {
                return 1;
            }
            if (Object.ReferenceEquals(other.Name, Name))
            {
                return 1;
            }
            return other.Surname.CompareTo(Surname) + other.Name.CompareTo(Name);
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
