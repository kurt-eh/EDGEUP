using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockBuster
{
    /*
    1. Create a class called VHSTape. Include member variables representing the following:
      a.The name of the movie.
      b.The movie’s length (in minutes).
      b.Whether or not the movie is currently rented.
      d.How far along the tape is currently played.
    2. Add functions to VHSTape to do the following:
      a.Play the tape a given amount.
      b.Rewind the tape a given amount.
      c.Set whether or not the tape is rented.
      d.A constructor that initializes the movie’s name and length to given values. The movie should initially be not rented, and rewound to the movie’s beginning.
    3. Create a class called Mockbuster. Include member variables representing the following:
      a.The address of the store.
      b.A list of movies at the store.
    4.Add methods to Mockbuster to do the following:
      a.Add a movie.
      b.Check if the store has a movie, given the movie’s name.
      c.Check if the store has an unrented copy of a movie, given the movie’s name.
      d.Rent a movie, given the movie’s name. This function should return the VHSTape object.
      e.Return a movie, given the movie’s name.
      f.A constructor that initializes the store’s address to a given value. The list of movies should initially be empty.

    5. Complete the program with some method for printing values.*/
    class Program
    {
        static Mockbuster store = new Mockbuster();
        static VHSTape rentedTape = new VHSTape();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Store Rental Sysyem setup.");
            Mockbuster store = BuildAStore();
            MovieCommand();
        }
        static void Instructions()
        {
            Console.Clear();
            Console.WriteLine("Type \"add <movie title> <time in minutes>\" to add a movie.");
            Console.WriteLine("Type \"check <movie title>\" to see if your movie is in the inventory by key word or phrase.");
            Console.WriteLine("Type \"is <movie title> rented\" to see if a movie is rented by key word or phrase.");
            Console.WriteLine("Type \"rent <movie title>\" to rent a movie.");
            Console.WriteLine("Type \"play <'all' or 'n' time in minutes>\" to play all or 'n' minutes of the movie you rented.");
            Console.WriteLine("Type \"rewind <'all' or 'n' time in minutes>\" to rewind all or 'n' minutes of the movie you rented.");
            Console.WriteLine("Type \"return <movie title>\" to return the movie you rented.");
            Console.WriteLine("Type \"exit\" close the program.");
        }
        static void MovieCommand()
        {
            bool haveRental = false;
            do
            {
                Instructions();
                string command = null;
                if (haveRental == true)
                {
                    Console.WriteLine("\nYou have rented {0}, and watched {1} minutes of it. {2} minutes of the movie remains to be seen. \nBe kind, rewind.", rentedTape.MovieName, rentedTape.PlayedTime, (rentedTape.MovieLength - rentedTape.PlayedTime));
                }
                Console.WriteLine("\nPlease enter a command:");
                command = Console.ReadLine().Trim();
                string[] option = command.Split(' ');
                for (int i = 0; i < option.Length; i++)
                {
                    option[i] = option[i].Trim();
                }
                command = option[0];
                string title = null;
                string time = null;
                bool checkTime = false;
                switch (option[0].ToLower())
                {
                    case "add":
                        time = option[option.Length - 1];
                        checkTime = int.TryParse(time, out int temp);
                        if (!checkTime)
                        {
                            do
                            {
                                Console.WriteLine("Please add the length of the move in minutes.");
                                time = Console.ReadLine().Trim();
                                checkTime = int.TryParse(time, out temp);
                            } while (!checkTime);
                        }
                        for (int i = 1; i < option.Length - 1; i++)
                        {
                            title += " " + option[i];
                        }
                        title = title.Trim();
                        break;
                    case "play":
                    case "rewind":
                        time = option[option.Length - 1];
                        if (time.ToLower() != "all")
                        {
                            checkTime = int.TryParse(time, out temp);
                            if (checkTime == false)
                            {
                                do
                                {
                                    Console.WriteLine("Please add how many minutes.");
                                    time = Console.ReadLine().Trim();
                                    checkTime = int.TryParse(time, out temp);
                                } while (checkTime == false);
                            }
                        }
                        break;
                    case "is":
                        command = "isitout";
                        for (int i = 1; i < option.Length - 1; i++)
                        {
                            title += " " + option[i];
                        }
                        title = title.Trim();
                        break;
                    case "check":
                    case "rent":
                        for (int i = 1; i < option.Length; i++)
                        {
                            title += " " + option[i];
                        }
                        title = title.Trim();
                        break;
                    case "return":
                        if (option.Length == 1)
                        {
                            title = rentedTape.MovieName;
                        }
                        else
                        {
                            for (int i = 1; i < option.Length; i++)
                            {
                                title += " " + option[i];
                            }
                            title = title.Trim();
                        }
                        break;
                }
                if (command.ToLower().Contains("exit"))
                {
                    Console.WriteLine("Thank you for using Mockbuster");
                    break;
                }
                else if (command.ToLower().Contains("add"))
                {
                    store.AddAMovie(title, time);
                }
                else if (command.ToLower().Contains("check"))
                {
                    store.CheckInventory(title);
                }
                else if (command.ToLower().Contains("isitout"))
                {
                    store.RentalStatus(title);
                }
                else if (command.ToLower().Contains("show"))
                {
                    store.ShowInventory();
                }
                else if (command.ToLower().Contains("rent"))
                {
                    rentedTape = store.RentTape(title);
                    haveRental = true;
                }
                else if (command.ToLower().Contains("play"))
                {
                    if (time.ToLower() == "all")
                    {
                        rentedTape.PlayedTime = rentedTape.MovieLength;
                    }
                    else
                    {
                        rentedTape.PlayedTime += int.Parse(time);
                    }
                    if (rentedTape.PlayedTime >= rentedTape.MovieLength)
                    {
                        rentedTape.PlayedTime = rentedTape.MovieLength;
                        Console.WriteLine("You have finished watching {0}.\nBe kind, rewind!", rentedTape.MovieName);
                    }
                    else
                    {
                        Console.WriteLine("You have played {0} of {1} minutes of the movie {2}. {3} minutes remain.", rentedTape.PlayedTime, rentedTape.MovieLength, rentedTape.MovieName, (rentedTape.MovieLength - rentedTape.PlayedTime));
                    }
                }
                else if (command.ToLower().Contains("rewind"))
                {
                    if (time == "all" || (rentedTape.PlayedTime - (int.Parse(time)) <= 0))
                    {
                        rentedTape.PlayedTime = 0;
                        Console.WriteLine("Thank you for being kind. {0} is entirely rewound!", rentedTape.MovieName);
                    }
                    else
                    {
                        rentedTape.PlayedTime -= int.Parse(time);
                        Console.WriteLine("You have rewound {0} minutes of {1}. You must rewind {2} minutes more to rewind it entirely.", time, rentedTape.MovieName, rentedTape.PlayedTime);
                    }
                }
                else if (command.ToLower().Contains("return"))
                {
                    if (rentedTape.PlayedTime > 0)
                    {
                        Console.WriteLine("You are returning {0} without rewinding it. Please rewind {1} minutes before returning. Be kind, rewind!", rentedTape.MovieName, rentedTape.PlayedTime);
                        do
                        {
                            Console.WriteLine("Do you want to rewind to the beginning? (y/n)");
                            string confirm = (Console.ReadLine()).Trim().ToLower();
                            if (confirm.StartsWith("y"))
                            {
                                Console.WriteLine("Thank you for being kind. {0} is entirely rewound!", rentedTape.MovieName);
                                rentedTape.PlayedTime = 0;
                            }
                            else
                            {
                                Console.WriteLine("Please finish rewinding the tape. \nWe will continue to ask until you do rewind the tape to the beginning.");
                            }
                        } while (rentedTape.PlayedTime > 0);
                    }
                    store.ReturnTape(title);
                    rentedTape = null;
                    haveRental = false;
                }
                else if (command == "")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Input not recognized, please try again.");

                }
                Console.WriteLine("\n<<Press any key to continue.>>");
                Console.ReadKey();
            } while (true);
        }
        static Mockbuster BuildAStore()
        {
            /* Remove comments to querry user to enter the store.
                * Console.Clear();
            Console.WriteLine("First we need to build a store:");
            Console.WriteLine("Plesae enter the store's street number.");
            string streetNum = Console.ReadLine().Trim();
            Console.WriteLine("Plesae enter the store's street name.");
            string streetName = Console.ReadLine().Trim();
            Console.WriteLine("Plesae enter the store's city.");
            string city = Console.ReadLine().Trim();
            Console.WriteLine("Plesae enter the store's province.");
            string province = Console.ReadLine().Trim();
            Console.WriteLine("Plesae enter the store's postal code.");
            string postal = Console.ReadLine().Trim();
            Mockbuster store = new Mockbuster(streetNum, streetName, city, province, postal);
            Console.Clear();*/

            Mockbuster store = new Mockbuster() { StreetNumber = "123", StreetName = "Fake Street", City = "Springfield", Province = "AB", PostalCode = "ABC123" };
            Console.WriteLine("Welcome to store: \n{0} - {1} \n{2}, {3} \n{4}", store.StreetNumber, store.StreetName, store.City, store.Province, store.PostalCode);
            Console.WriteLine("\n<<Press any key to continue.>>");
            Console.ReadKey();
            return store;
        }
        
    }
}
