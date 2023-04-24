using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        public ContactData (string name)
        {
            Name = name;
        }

        public bool Equals (ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
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
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }   
            if (other.Surname==Surname)
            {
                return other.Name.CompareTo(Name);   
            }
            return other.Surname.CompareTo(Surname);
        }

        public ContactData(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public string Name {get; set;}

        public string Surname { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string AllPhones
        { 
            get 
            {
                if (AllPhones!=null) 
                {
                    return AllPhones;
                }
                else
                {
                    return CleanUpPhone(HomePhone) + CleanUpPhone(MobilePhone) + CleanUpPhone(WorkPhone);
                }
            } 
            set 
            {
                AllPhones = value;
            } 
        }

        private string CleanUpPhone(string phone)
        {
            if (phone == null)
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
        }

        public string AllEmails
        {
            get
            {
                if (AllEmails != null)
                {
                    return AllEmails;
                }
                else
                {
                    return Email + Email2 + Email3;
                }
            }
            set
            {
                AllEmails = value;
            }
        }
    }
}
