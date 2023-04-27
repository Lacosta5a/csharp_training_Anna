using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allData;
        private string nameSurnameAddress;
        private string homeMobileWorkPhones;
        private string emailEmail2Email3;

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
        public string NameSurnameAddress
        {
            get
            {
                if (nameSurnameAddress != null)
                {
                    return nameSurnameAddress;
                }
                if (Name == null|| Name=="")
                {
                    return Surname + "\r\n" + Address.Trim();
                }
                if (Surname == null || Surname == "")
                {
                    return Name+ "\r\n" + Address.Trim();
                }
                if (Address == null || Address == "")
                {
                    return Name + " " + Surname + "\r\n";
                }
                else
                {
                    return Name+" "+Surname+ "\r\n" + Address.Trim(); 
                }
            }
            set
            {
                nameSurnameAddress = value;
            }
        }
        public string HomeMobileWorkPhones
        {
            get
            {
                if (homeMobileWorkPhones != null)
                {
                    return homeMobileWorkPhones;
                }
                else
                {
                    return "H: "+HomePhone + "\r\n"+"M: " +MobilePhone + "\r\n"+ "W: " +WorkPhone.Trim(); ;
                }
            }
            set
            {
                homeMobileWorkPhones = value;
            }
        }



        public string AllPhones
        { 
            get 
            {
                if (allPhones!=null) 
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUpPhone(HomePhone) + CleanUpPhone(MobilePhone) + CleanUpPhone(WorkPhone)).Trim(); ;
                }
            } 
            set 
            {
                allPhones = value;
            } 
        }

        public string CleanUpPhone(string phone)
        {
            if (phone == null || phone=="")
            {
                return "";
            }
            return Regex.Replace(phone,"[ -()]","") +"\r\n";
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail (Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string CleanUpEmail(string emails)
        {
            if (emails == null || emails == "")
            {
                return "";
            }
            return emails + "\r\n";
        }

        public string AllData
        {
            get
            {
                if (allData != null)
                {
                    return allData;
                }
                else
                {
                    return CleanUpNameSurnameAddress(NameSurnameAddress) + CleanUpAllPhones(HomeMobileWorkPhones)                         
                        + CleanUpAll3Email(AllEmails);
                }
            }
            set
            {
                allData = value;
            }
        }

        private object CleanUpAll3Email(string allEmails)
        {
            {
                if (allEmails == null || allEmails == "")
                {
                    return "";
                }
                return "\r\n\r\n"+AllEmails;
            }
        }

        private string CleanUpAllPhones(string homeMobileWorkPhones)
        {
            if (homeMobileWorkPhones == null || homeMobileWorkPhones == "")
            {
                return "";
            }
            return homeMobileWorkPhones;
        }

        private string CleanUpNameSurnameAddress(string nameSurnameAddress)
        {
            if (nameSurnameAddress == null || nameSurnameAddress == "")
            {
                return "";
            }
            return nameSurnameAddress + "\r\n\r\n";
        }
    }
}
