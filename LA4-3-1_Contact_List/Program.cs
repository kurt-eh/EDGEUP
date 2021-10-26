using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA4_3_1_Contact_List
{
    class Program
    {
        /**
* *
Write a program that stores your phone’s contact list. A contact has a name and a phone number (10 digits). The user should be able to type “add <Name> <Number>” to add a new contact with a given phone number, or to update an existing contact by adding a phone number “update <Old Number> <Updated Name> <New Number>”. If a user has more than one phone number, they will use the add command multiple times. A user can delete a contact by using the command “delete <Number>”. Finally, the user should also be able to type “find <Name>” to get a list of that contact’s phone numbers. The program should keep running until the user types the command: exit.

Hint: You will need to create a Contact object for this
*/
        static void Main(string[] args)
        {
            List<Contact> contacts = new List<Contact>();
            Console.WriteLine("Build your contact list.  Instructions:");
            Console.WriteLine("You need a single name and a phone number.");
            Console.WriteLine("To add a new name type \"add <Name> <Number>\". You can do this multiple times to add extra numbers for any given name.");
            Console.WriteLine("To update a number type \" update <Old Number> <Updated Name> <New Number>\"");
            Console.WriteLine("To delete a contact type the command \" delete <Number>\".");
            Console.WriteLine("Type “find <Name>” to get a list of that contact’s phone numbers.");
            Console.WriteLine("To exit the loop type \"exit\".");

            do
            {
                string[] values = GetInput();
                if (values[0].ToLower() == "exit")
                {
                    break;
                }
                else if (values[0].ToLower() == "add")
                {
                    string temp1 = values[2];
                    values[2] = CheckLength(values[2], contacts);  //tests for 10 digit number
                    values[2] = DuplicateNumber(values[2], contacts); //looks for duplicate number
                    string temp2 = values[2];
                    bool found = false;

                    if (contacts.Count == 0)
                    {
                        contacts.Add(new Contact(values[1], values[2]));   //initialize a new contact in the list if list is empty. 
                    }
                    else { 
                        for (int i = 0; i < contacts.Count; i++)
                        {
                            if (contacts[i].contactName == (values[1])) //searches list for existing name
                            {
                                contacts[i].contactNumbers.Add(values[2]); //adds number to an existing contact in list
                                found = true;
                            }
                        }
                        if (!found)
                        {
                            contacts.Add(new Contact(values[1], values[2]));   //initialize a new contact in the list   
                        }
                    }

                    Console.WriteLine("Added {0} {1} to the list.\n", values[1], values[2]);
                }
                else if (values[0].ToLower() == "delete")
                {
                    string test = values[1];
                    values[1] = CheckLength(test, contacts);  //checks for 10 digit number
                    values[1] = CheckForNumber(test, contacts); //asks user to re-enter number if it is not found.
                    string temp = null;
                    for (int i = 0; i < contacts.Count; i++)
                    {
                        if (contacts[i].contactNumbers.Contains(values[1])) //finds number in the list
                        {
                            temp = contacts[i].contactName;
                            contacts.Remove(contacts[i]);  //deletes the contact.
                        }
                    }
                    Console.WriteLine("Removed {0} from the list.\n", temp);
                }
                else if (values[0].ToLower() == "update")
                { 
                    string test = values[1];
                    values[1] = CheckLength(test, contacts);  //Checks both numbers for duplicats/presence/length
                    values[1] = CheckForNumber(test, contacts);
                    string test2 = values[3];
                    values[3] = CheckLength(test2, contacts);
                    values[3] = DuplicateNumber(test2, contacts);

                    for (int i = 0; i < contacts.Count; i++)
                    {
                        if (contacts[i].contactNumbers.Contains(values[1]))
                        {
                            contacts[i].contactNumbers.Remove(values[1]); //updates the contact name and number.
                            contacts[i].contactNumbers.Add(values[3]);
                            contacts[i].contactName = values[2];
                        }
                    }
                    Console.WriteLine("Updated {0} on the list.\n", values[2]);
                }
                else if (values[0].ToLower() == "find")
                {
                    bool found = false;
                    do
                    {
                        for (int i = 0; i < contacts.Count; i++)    // loop asks for a new name if not found.
                        {
                            if (contacts[i].contactName == (values[1]))  // loop prints contact info if found.
                            {
                                Console.WriteLine(contacts[i].contactName);
                                found = true;
                                foreach (string number in contacts[i].contactNumbers)
                                {
                                    Console.WriteLine(number);                                    
                                }
                                Console.WriteLine("");
                                continue;
                            }
                        }
                        if (!found)
                        {
                            Console.WriteLine("Contact not found. Please enter name again.");
                            values[1] = Console.ReadLine();
                        }                        
                    } while (!found);
                    
                }
                else if (values[0].ToLower() == "display")  // prints all contacts + indicies.
                {
                    if (contacts.Count == 0)
                    {
                        Console.WriteLine("No contacts to display!");
                    }
                    for  (int i=0; i<contacts.Count;i++)
                    {
                        Console.WriteLine("Name {1}: {0}", contacts[i].contactName, i);
                        for (int j = 0; j <contacts[i].contactNumbers.Count;j++)
                        {                            
                            Console.WriteLine("Number {0},{1}: {2}", i, j, contacts[i].contactNumbers[j]);
                        }
                    }
                }

            } while (true);                    
        }
        static string[] GetInput()     //loop only allows primary commands.
        {
            do

            {
                string inputCommand = Console.ReadLine();
                string[] values = inputCommand.Split(' ');
                inputCommand.Trim();
                while (inputCommand.Contains("  ")) inputCommand.Replace("  ", " ");
                List<string> check = new List<string> { "add", "delete", "update", "find", "display"};
                
                if (check.Contains(values[0]))
                { 
                    return values; 
                }
                else
                {
                    Console.WriteLine("Invalid command, try again: add, delete, update, find, or display ");
                }
            } while (true);
        }
        static string DuplicateNumber(string value, List<Contact> contacts)  //loop looks for duplicate numbers and prompts for re-entry if found.
        {
            do
            {
                for (int i = 0; i<contacts.Count;i++)
                {
                    do
                    {
                        if (contacts[i].contactNumbers.Contains(value))
                        {
                            Console.WriteLine("Duplicate number, input new number");
                            value = CheckLength(Console.ReadLine(), contacts);

                        }                               
                        else if (!(contacts[i].contactNumbers.Contains(value)))
                        {
                            return value;
                        }
                                                           
                    } while (contacts[i].contactNumbers.Contains(value));
                    
                }
                return value;
            }while (true);
        }
        static string CheckLength(string value, List<Contact> contacts)  //loop ensures numbers are 10 digits.
        {
            
            do
            {                
                    do
                    {
                    if (value.Length != 10)
                    {
                        Console.WriteLine("Please enter a 10 digit number. ie: 1234567890");
                        value = Console.ReadLine();
                    }
                    else if (value.Length == 10)
                        {
                            return value;
                        }

                    } while (value.Length != 10);

                
                return value;
            } while (true);

        }
        static string CheckForNumber(string value, List<Contact> contacts)      //loop prompts for number re-entry if number not found.
        {
            do
            {
                for (int i = 0; i < contacts.Count; i++)
                {
                    do
                    {
                        if (contacts[i].contactNumbers.Contains(value))
                        {
                            return value;
                        }
                        else if (!(contacts[i].contactNumbers.Contains(value)))
                        {
                            Console.WriteLine("Number not a contact, input new number");
                            value = CheckLength(Console.ReadLine(), contacts);
                        }

                    } while (contacts[i].contactNumbers.Contains(value));
                }
                return value;
            } while (true);
        }
    }
}
