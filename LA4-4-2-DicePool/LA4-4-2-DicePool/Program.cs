using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA4_4_2_DicePool
{

    /**
*Many tabletop games use dice for various game mechanics. Dice come in many shapes and sizes, commonly having 4, 6, 8, 10, 12, or 20 sides. Many games require you to gather a set of dice of different sizes and roll them together. Create a program that simulates dice for a tabletop game.

Create a class representing a single die. The constructor should accept an integer indicating how many sides the die has. The class should have a function to simulate rolling the die, returning a random number within the valid range.
Create a class representing a pool of dice. This class should have functions to add or remove a die from the pool. The class should also have a function to roll all the dice in the pool and return the total that was rolled.
*/
    class Program
    {
        static ManyDice die = new ManyDice();
        static void Main(string[] args)
        {
            Console.WriteLine("Let's roll some dice!");
            Console.WriteLine("Please enter the number of dice you want to roll in the following format:");
            Console.WriteLine("xdy, where \"x\" is the number of dice you want and \"y\" is how many sides they have.");
            Console.WriteLine("Example: 2d6 is 2 6-sided dice. Perfect for playing Catan! (or Monopoly)");
            Console.WriteLine("Please limit your dice to d4, d6, d8, d10, d12, d20");
            
            PlayDice();
            Console.ReadKey();
        }
        static void PrintCommands()
        {
            Console.WriteLine("To add a die, type \"add xdy\" to add x number of y sided dice.");
            Console.WriteLine("To remove a die, type \"remove xdy.\"  to remove x number of y sided dice.");
            Console.WriteLine("Type \"dice\" to see a list of all the dice in the pile.");
            Console.WriteLine("Type \"roll\" to roll all the dice and see the results!");
            Console.WriteLine("Type \"clear\" to clear all the dice and start agin!");
            Console.WriteLine("Type \"commands\" or press enter on a blank line to see the command list again.");
            Console.WriteLine("Type \"exit\" to exit program\n");
        }

        static void PlayDice()
        {
            bool firstTime = true; 
            string[] xDy = null;
            int numberOfDice = 1;
            int numberOfSides = 1;
            string option = null;
            string[] words = null;
            string command = null;
            bool commandError;
            do 
            {
                
                do
                {
                    commandError = false;
                    PrintCommands();
                    if (firstTime == false)
                    {
                        switch (command.ToLower())
                        {
                            case "add":
                            case "remove":
                                Console.WriteLine("Last Command: {0} {1}d{2}", command, numberOfDice, numberOfSides);
                                break;
                            case "dice":
                            case "roll":
                            case "clear":
                            case "commands":
                                Console.WriteLine("Last Command: {0}",command);

                                break;
                        }
                    }
                    firstTime = false;
                    Console.WriteLine("Enter your command:");
                    option = CheckCommand();
                    if (option == "")
                    {
                        commandError = true;
                        continue;
                    }
                    words = option.Split(' ');
                    command = words[0];
                    if (words.Length > 1)
                    {
                    xDy = words[1].Split('d');                    
                        bool check = int.TryParse(xDy[0], out numberOfDice);
                        if (check == false)
                        {
                            commandError = true;
                        }
                        check = int.TryParse(xDy[1], out numberOfSides);
                        if (check == false)
                        {
                            commandError = true;
                        }
                        else
                        {
                            numberOfSides = CheckDice(numberOfSides);
                        }
                        if (xDy[1] == "" || xDy[0] == "")
                        {
                            commandError = true;
                        }
                    }
                    if (commandError == true)
                    {
                        Console.WriteLine("I think you had a typo. \nPlease enter numbers in the format: <number of dice>d<number of sides> (ie: 2d6 for 2 6-sided dice)");
                    }
                //Console.Clear();
                      
                } while (commandError == true);

                if (command == "exit") 
                {
                    Console.WriteLine("Thank you, play again, soon!");
                    break;
                }
                else if (command == "add") 
                {
                    die.AddDie(numberOfDice, numberOfSides);
                    
                }
                else if (command == "remove")
                {                    
                    die.Remove(numberOfDice, numberOfSides);
                }
                else if (command == "dice")
                {
                    die.Display();
                }
                else if (command == "roll")
                {
                    die.ReRollDice();
                }
                else if (command == "clear")
                {
                    Console.WriteLine("All dice have been removed from the bag. \nPlease add more dice.");
                    die.Clear();
                }
                else
                {
                    PrintCommands();
                }
            } while (true);            
        }
        static int CheckDice(int sides)
        {
            List<int> check = new List<int> {4,6,8,10,12,20};
            while (!check.Contains(sides))
            {
                Console.WriteLine("{0}-sided dice are not available.\nPlease enter 4,6,8,10,12 or 20");
                sides = int.Parse(Console.ReadLine());                
            }
               return sides;            
        }
        static string CheckCommand()
        {
            string instructions = Console.ReadLine();
            instructions = instructions.ToLower().Trim();
            string[] words = instructions.Split(' ');
            string test = words[0];
            List<string> check = new List<string> { "add", "remove", "dice", "roll","clear", "commands", "", "exit" };
            while (!check.Contains(words[0]))
            {
                Console.WriteLine("Command not recognized.\nPlease enter \"add xdy\", \"remove xdy\", \"dice\", \"roll\",\"clear\", or \"exit\"");
                instructions = Console.ReadLine(); 
                instructions = instructions.ToLower().Trim();
                words = instructions.Split(' ');
                test = words[0];
            }
            return instructions;
        }

        
    }
}
