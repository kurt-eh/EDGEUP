﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateContact
{
    class Program
    {
        static List<Contact> myContactList = new List<Contact>();
        static void Main(string[] args)
        {
            
            do
            {   
                Console.WriteLine("Build your contact list.  Instructions:");
                Console.WriteLine("You need a single name and a phone number.");
                Console.WriteLine("To add a new name type \"add <Name> <Number>\". You can do this multiple times to add extra numbers for any given name.");
                Console.WriteLine("To update a number type \" update <Old Number> <Updated Name> <New Number>\"");
                Console.WriteLine("To delete a contact type the command \"delete <Number>\".");
                Console.WriteLine("Type \"find <Name>\" to get a list of that contact’s phone numbers.");
                Console.WriteLine("Type \"display\" to show the complete list of all contacts and their phone numbers.");
                Console.WriteLine("To exit the loop type \"exit\".");
                string[] values = GetInput();                
                if (values[0].ToLower() == "exit")
                {
                    break;
                }
                else if (values[0].ToLower() == "add")
                {
                    while (values.Length <= 2)
                    {
                        Console.WriteLine("Please try again");
                        values = GetInput();
                    }
                    values[2] = CheckLength(values[2]);
                    bool found = false;
                    for (int i = 0; i < myContactList.Count; i++)
                    {
                        if (myContactList[i].Name.ToLower() == (values[1].ToLower())) //searches list for existing name
                        {
                            myContactList[i].PhoneNumbers.Add(values[2]); //adds number to an existing contact in list
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        myContactList.Add(new Contact(values[1], values[2]));   //initialize a new contact in the list
                    }
                    Console.WriteLine("Added {0} {1} to the list.\n", values[1], values[2]);
                }
                else if (values[0].ToLower() == "delete")
                {
                    while (values.Length < 2)
                    {
                        Console.WriteLine("Please try again");
                        values = GetInput();
                    }
                    values[1] = CheckLength(values[1]);
                    values[1] = CheckForNumber(values[1]); //asks user to re-enter number if it is not found.                    
                    int indx = 1;
                    List<string> tempName = new List<string>();
                    foreach (Contact person in myContactList)
                    {
                        if (person.PhoneNumbers.Contains(values[1]))
                        {
                            Console.WriteLine("Contact {0}: {1} has that number {2}.", indx, person.Name, values[1]);
                            tempName.Add(person.Name);
                            indx++;
                        }
                    }
                    Console.WriteLine("Which person (by above number) do you want to delete from your contact list?");
                    int choice = int.Parse(Console.ReadLine().Trim());
                    for (int i = 0; i < myContactList.Count; i++)
                    {
                        if (myContactList[i].Name.Contains(tempName[choice-1]))
                        {
                            myContactList.Remove(myContactList[i]);  //deletes the contact.
                        }
                    }
                    Console.WriteLine("Removed {0} from the list.\n", tempName[choice-1]);
                    tempName.Clear();
                }
                else if (values[0].ToLower() == "update")
                {
                    while (values.Length <= 3)
                    {
                        Console.WriteLine("Please try again");
                        values = GetInput();
                    }
                    values[3] = CheckLength(values[3]);
                    values[1] = CheckForNumber(values[1]);
                    int indx = 1;
                    List<string> tempName = new List<string>();
                    foreach (Contact person in myContactList)
                    {
                        if (person.PhoneNumbers.Contains(values[1]))
                        {
                            Console.WriteLine("Contact {0}: {1} has that number {2}.", indx, person.Name, values[1]);
                            tempName.Add(person.Name);
                            indx++;
                        }
                    }
                    Console.WriteLine("Which person (by above number) do you want to update from your contact list?");
                    int choice = int.Parse(Console.ReadLine().Trim());
                    for (int i = 0; i < myContactList.Count; i++)
                    {
                        if (myContactList[i].Name.Contains(tempName[choice - 1]))
                        {
                            Console.WriteLine("Do you want to update the number?(y/n");
                            string answer = (Console.ReadLine().Trim().ToLower().Substring(0, 1));
                            if (answer == "y")
                            {
                                myContactList[i].PhoneNumbers.Remove(values[1]);
                                myContactList[i].PhoneNumbers.Add(values[3]);
                            }
                            Console.WriteLine("Do you want to update the name?(y/n");
                            answer = (Console.ReadLine().Trim().ToLower().Substring(0,1));
                            if (answer=="y")
                            {
                                myContactList[i].Name = values[2];
                            }
                        }
                    }
                    Console.WriteLine("Updated {0} on the list.\n", values[2]);
                    tempName.Clear();
                }
                else if (values[0].ToLower() == "find")
                {
                    bool found = false;
                    do
                    {
                        for (int i = 0; i < myContactList.Count; i++)    // loop asks for a new name if not found.
                        {
                            if (myContactList[i].Name.ToLower() == (values[1].ToLower()))  // loop prints contact info if found.
                            {
                                Console.WriteLine(myContactList[i].Name);
                                found = true;
                                foreach (string number in myContactList[i].PhoneNumbers)
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
                    Display();
                }
                else if (values[0].ToLower() == "clear")
                {
                    Console.WriteLine("All contacts delteted.");
                    myContactList.Clear();
                }
                Console.WriteLine("<<Press any key to clear the screen and continue>>");
                Console.ReadKey();
                Console.Clear();
            } while (true);
        }
        static string[] GetInput()     //loop only allows primary commands.
        {
            do
            {
                Console.WriteLine("\nPlease enter a command:");
                string inputCommand = Console.ReadLine().Trim();
                string[] values = inputCommand.Split(' ');
                while (inputCommand.Contains("  ")) inputCommand.Replace("  ", " ");
                List<string> check = new List<string> { "add", "delete", "update", "find", "display", "clear", "exit" };
                if (check.Contains(values[0].ToLower()))
                {
                    return values;
                }
                else
                {
                    Console.WriteLine("Invalid command, try again: add, delete, update, find, display, or exit. ");
                }
            } while (true);
        }
        static string CheckLength(string value)  //loop ensures numbers are 10 digits.
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
        static string CheckForNumber(string value)      //loop prompts for number re-entry if number not found.
        {
            for (int i = 0; i < myContactList.Count; i++)
            {
                do
                {
                    if (myContactList[i].PhoneNumbers.Contains(value))
                    {
                        return value;
                    }
                    else if (!(myContactList[i].PhoneNumbers.Contains(value)))
                    {
                        Console.WriteLine("Number not a contact, input new number or 00 to display all names/numbers.");
                        value = (Console.ReadLine().Trim());
                        if (value == "00")
                        {
                            Display();
                            Console.WriteLine("Please enter the number of the contact you want to match.");
                            value = (Console.ReadLine().Trim());
                        }
                        else
                        {
                            value = CheckLength(Console.ReadLine().Trim());
                        }
                    }
                } while (myContactList[i].PhoneNumbers.Contains(value));
            }
            return value;
        }
        static void Display()
        {
            if (myContactList.Count == 0)
            {
                Console.WriteLine("No contacts to display!");
            }
            for (int i = 0; i < myContactList.Count; i++)
            {
                Console.WriteLine("Name: {0}", myContactList[i].Name);
                for (int j = 0; j < myContactList[i].PhoneNumbers.Count; j++)
                {
                    Console.WriteLine("Number: {0}", myContactList[i].PhoneNumbers[j]);
                }
            }
        }
    }
}
