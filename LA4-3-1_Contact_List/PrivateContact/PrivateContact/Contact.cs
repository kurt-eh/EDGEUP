using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateContact
{
    class Contact
    {
        private List<string> _phoneNumbers = new List<string>();
        private List<Contact> _contactList = new List<Contact>();
        private List<Contact> ContactList
        {
            get { return this._contactList; }
            set { this._contactList = value; }
        }
        public List<string> PhoneNumbers 
        {
            get { return this._phoneNumbers; }
            set { this._phoneNumbers = value; }
        }
        public string Name { get; set; }
        public Contact() //base constructor
        {
        }
        public Contact (string name, string number)
        {
            this.Name = name;
            this.PhoneNumbers.Add(number);
        }
        
    }
}
