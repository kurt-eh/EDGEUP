using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA4_3_1_Contact_List
{
    public class Contact
    {
        public string contactName;
        public List<string> contactNumbers = new List<string>();

        public Contact() //base constructor
        {
        
        }

        public Contact(string name, string number ) //build constructor w/ arguements from main.
        {
            this.contactName = name;
            this.contactNumbers.Add(number);
        }
        public void DisplayContact()
        {
            Console.WriteLine(contactName);
            foreach (string number in contactNumbers)
            {
                Console.WriteLine("{0} ", number);
            }
            Console.WriteLine("");
        }

    }
}
