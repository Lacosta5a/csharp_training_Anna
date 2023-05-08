using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;
using System.Xml.Serialization;
using System.Diagnostics.Eventing.Reader;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name ="addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public ContactData()
        {
        }

      
        private string allPhones;
        private string allEmails;
        private string allData;
        private string nameSurnameAddress;
        private string homeMobileWorkPhones;

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

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }


        [Column(Name="firstname")]
        public string Name {get; set;}

        [Column(Name = "lastname")]
        public string Surname { get; set; }

        public string Address { get; set; }

        [XmlIgnore]
        public string HomePhone { get; set; }

        [XmlIgnore]
        public string MobilePhone { get; set; }

        [XmlIgnore]
        public string WorkPhone { get; set; }

        [XmlIgnore]
        public string Email { get; set; }

        [XmlIgnore]
        public string Email2 { get; set; }

        [XmlIgnore]
        public string Email3 { get; set; }

        [Column(Name="deprecated")]
        public string Deprecated { get; set; }

        [XmlIgnore]
        public string NameSurnameAddress
        {
            get
            {
                if (nameSurnameAddress != null)
                {
                    return nameSurnameAddress;
                }
                else
                {
                    return Name + CheckIfSpaceNeeded(" ")+ Surname +CheckNewLineNeeded("\r\n")+Address.Trim();
                }
            }
            set
            {
                nameSurnameAddress = value;
            }
        }

        private string CheckNewLineNeeded(string v)
        {
            if (Address == null || Address == "")
            {
                return null;
            }
            else
            {
                if (Address != null || Address != "")
                {
                    if (Name != null || Name != "")
                    {
                        if (Surname == null || Surname == "")
                        {
                            return "\r\n";
                        }
                    }
                    
                    if (Name == null || Name == "")
                    {
                        if (Surname != null || Surname != "")
                        {
                            return "\r\n";
                        }
                    }
                }
                return "\r\n";
            }
        }



        private string CheckIfSpaceNeeded(string v)
        {
            if (Name ==null||Name=="")
            {
                return null;
            }
            if (Surname == null || Surname == "")
            {
                return null;
            }
            else
            {
                return " ";
            }
        }

        [XmlIgnore]
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
                    return AddedH(HomePhone)+ СheckNewLineBeforeM("\r\n")+ 
                        AddedM(MobilePhone) + СheckNewLineBeforeW("\r\n")+ AddedW(WorkPhone);
                }              
            
            }
            set
            {
                homeMobileWorkPhones = value;
            }
        }

        private string СheckNewLineBeforeM(string v)
        {
            if (MobilePhone == null || MobilePhone == "")
            {
                return null;
            }
            else
            {
                if (MobilePhone != null || MobilePhone != "")
                {
                    if (HomePhone != null || HomePhone != "")
                    {
                        return "\r\n";
                    }
                }
                return null;
            }
        }

        private string СheckNewLineBeforeW(string v)
        {
            if (WorkPhone == null || WorkPhone == "")
            {
                return null;
            }
            else
            {
                if (WorkPhone != null || WorkPhone != "")
                {
                    if (MobilePhone != null || MobilePhone != "")
                    {
                        return "\r\n";
                    }
                }
                return null;
            }
        }

        private string AddedH(string homePhone)
        {
            if (homePhone == null || homePhone == "")
            {
                return "";
            }
            return "H: "+HomePhone;
        }

        private string AddedM(string mobilePhone)
        {
            if (mobilePhone == null || mobilePhone == "")
            {
                return "";
            }
            return "M: " + MobilePhone;
        }

        private string AddedW(string workPhone)
        {
            if (workPhone == null || workPhone == "")
            {
                return "";
            }
            return "W: " + WorkPhone;
        }

        [XmlIgnore]
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

        [XmlIgnore]
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

        [XmlIgnore]
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
                else
                {
                    if (allEmails != null || allEmails != "")
                    {
                        if (NameSurnameAddress == null || NameSurnameAddress == "")
                        {
                            if (homeMobileWorkPhones == null || homeMobileWorkPhones == "")
                            {
                                return allEmails;
                            }
                        }
                    }
                }
                return "\r\n\r\n" + allEmails;
            }
        }

        private string CleanUpAllPhones(string homeMobileWorkPhones)
        {
            if (homeMobileWorkPhones == null || homeMobileWorkPhones == "")
            {
                return "";
            }
            else
            {
                if (homeMobileWorkPhones != null || homeMobileWorkPhones != "")
                {
                    if (NameSurnameAddress == null || NameSurnameAddress == "")
                    {
                        return homeMobileWorkPhones;
                    }
                }
            }
            return "\r\n\r\n" + homeMobileWorkPhones;
        }

        private string CleanUpNameSurnameAddress(string nameSurnameAddress)
        {
            if (nameSurnameAddress == null || nameSurnameAddress == "")
            {
                return "";
            }
            return nameSurnameAddress;
        }

        public static List<ContactData> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from c in db.Contacts.Where(x=>x.Deprecated== "0000-00-00 00:00:00") select c).ToList();
            }
        }
    }
}
