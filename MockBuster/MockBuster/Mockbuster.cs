using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockBuster
{

    /*
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
    class Mockbuster
    {
        private string _streetNumber, _streetName, _city, _province, _postalCode;
        private List<VHSTape> _inventory = new List<VHSTape>();

        public Mockbuster()
        {

        }
        public List<VHSTape> Inventory
        {
            get { return this._inventory; }
            set
            {
                this._inventory = value;
            }
        }

        public string StreetNumber
        {
            get
            {
                return _streetNumber;
            }
            set
            {
                this._streetNumber = value;
            }
        }
        public string StreetName
        {
            get
            {
                return _streetName;
            }
            set
            {
                this._streetName = value;
            }
        }
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                this._city = value;
            }
        }
        public string Province
        {
            get
            {
                return _province;
            }
            set
            {
                this._province = value;
            }
        }
        public string PostalCode
        {
            get
            {
                return _postalCode;
            }
            set
            {
                this._postalCode = value;
            }
        }
        public Mockbuster(string streetNum, string streetName, string city, string province, string postal)
        {
            this.StreetNumber = streetNum;
            this.StreetName = streetName;
            this.City = city;
            this.Province = province;
            this.PostalCode = postal;
        }
        public void AddAMovie(string title, string time)
        {
            bool duplicate = false;
            foreach (VHSTape tape in this.Inventory)
            {
                if (title.ToLower() == tape.MovieName.ToLower())
                {
                    Console.WriteLine("We already have that in inventory, please try again.");
                    duplicate = true;
                }
            }
            if (duplicate == false)
            {
                this.Inventory.Add(new VHSTape(title, int.Parse(time)));
                Console.WriteLine("You have added {0} to the inventory. It is {2} minutes long.\nWe now have {1} movies in our library. ", this.Inventory[this.Inventory.Count - 1].MovieName, this.Inventory.Count, this.Inventory[this.Inventory.Count - 1].MovieLength);
            }
        }
        public void CheckInventory(string title)
        {
            int count = 0;
            foreach (VHSTape tape in this.Inventory)
            {
                if (tape.MovieName.ToLower().Contains(title.ToLower()))
                {
                    Console.WriteLine("{0} is available in our inventory.", tape.MovieName);
                    count++;
                }
            }
            if (count >= 1)
            {
                Console.WriteLine("We hope you found what you were looking for!");
            }
            else
            {
                Console.WriteLine("{0} is not available in our inventory!", title);
            }
        }
        public void ShowInventory()
        {
            Console.WriteLine("Our {0} movies are:", this.Inventory.Count);
            foreach (VHSTape tape in this.Inventory)
            {
                Console.WriteLine("Movie: {0}, Length: {1} minutes, How much have they played? {2} minutes, Is it rented?: {3}", tape.MovieName, tape.MovieLength, tape.PlayedTime, tape.IsRented);
            }
        }
        public void RentalStatus(string title)
        {
            bool found = false;
            bool haveIT = false;
            foreach (VHSTape tape in this.Inventory)
            {
                if (tape.MovieName.ToLower().Contains(title.ToLower()) && tape.IsRented == false)
                {
                    Console.WriteLine("{0} is available to rent.", tape.MovieName);
                    found = true;
                }
                if (tape.MovieName.ToLower().Contains(title.ToLower()))
                {
                    haveIT = true;
                }
            }
            if (found == false && haveIT == true)
            {
                Console.WriteLine("{0} has been rented!", title);
            }
            else if (haveIT == false)
            {
                Console.WriteLine("We do not have {0} in our inventory", title);
            }
        }
        public VHSTape RentTape(string title)
        {
            bool found = false;
            VHSTape notFound = new VHSTape();
            foreach (VHSTape tape in this.Inventory)
            {
                if (title.ToLower() == tape.MovieName.ToLower())
                {
                    tape.IsRented = true;
                    Console.WriteLine("You have rented {0}. \nBe kind, rewind!", tape.MovieName);
                    found = true;
                    return tape;
                }
            }
            if (found == false)
            {
                Console.WriteLine("We are sorry, {0} is not in inventory!", title);
            }
            return notFound;
        }
        public void ReturnTape(string title)
        {
            foreach (VHSTape tape in this.Inventory)
            {
                if (title.ToLower() == tape.MovieName.ToLower())
                {
                    tape.IsRented = false;
                    Console.WriteLine("You have returned: " + tape.MovieName);
                }
            }
        }
    }
}
