using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA4_4_2_DicePool
{
    /*
      Create a class representing a pool of dice. This class should have functions to add or remove a die from the pool. The class should also have a function to roll all the dice in the pool and return the total that was rolled.
    */
    //create a list of dice, building each from the single die class
    class ManyDice
    {
        private List<OneDie> _dicePool = new List<OneDie>();
        public List<OneDie> DicePool
        {
            get
            {
                return this._dicePool;
            }
            set
            {
                this._dicePool = value;
            }
        }
        public ManyDice()
        {

        }
        public void AddDie(int number, int sides)
        {
            for (int i = 0; i < number; i++)
            {
                OneDie die = new OneDie(sides);
                this.DicePool.Add(die);
            }
            Console.WriteLine("\nYou have added {0} {1}-sided dice.", number, sides);
            IsAre();
            Pause();
        }
        public void ReRollDice(Random random)
        {
            int count = 0;
            int total = 0;
            Console.WriteLine("Here is your roll:");
            foreach (OneDie die in this.DicePool)
            {
                Console.Write("\nd" + die.Sides);
                count = die.RollIt(die.Sides, random);
                Console.Write(": " + count);
                total += count;
            }
            Console.WriteLine("\nThe sum of all the dice is: {0}!\n", total);
            Pause();
        }
        public void Remove(int howMany, int numSides)
        {
            //Sean's solution:
            int howManyCount = 0;
            List<OneDie> diceToRemove = new List<OneDie>();
            foreach (OneDie die in this.DicePool)
            {
                if (numSides == die.Sides && howManyCount < howMany)
                {
                    diceToRemove.Add(die);
                    howManyCount++;
                }
            }
            foreach (OneDie dieToRemove in diceToRemove)
            {
                this.DicePool.Remove(dieToRemove);
            }
            //My original solution:             
            /* 
            int startCount = this.DicePool.Count;
           int howManyCount = 0;
           for (int i = 0; i < this.DicePool.Count; i++)
           {
               while (this.DicePool[i].Sides == numSides)
               {
                   this.DicePool.Remove(this.DicePool[i]);
                   howManyCount++;
                   if (howMany == howManyCount)
                   break;
               }
           }
           */
            Console.WriteLine("You have removed {0} {1}-sided dice.", howManyCount, numSides);
            IsAre();
            Pause();
        }
        public void IsAre()
        {
            if (this.DicePool.Count == 1)
            {
                Console.WriteLine("There is {0} die in the dice bag.", this.DicePool.Count);
            }
            else
            {
                Console.WriteLine("There are {0} dice in the dice bag.", this.DicePool.Count);
            }
        }
        public void Clear()
        {
            this.DicePool.Clear();
            Console.WriteLine("The dice bag is empty.");
            Pause();
        }
        public void Pause()
        {
            Console.WriteLine("<<Press any key to clear screen and continue>>");
            Console.ReadKey();
            Console.Clear();
        }
        public void Display()
        {
            int d4, d6, d8, d10, d12, d20;
            d4 = d6 = d8 = d10 = d12 = d20 = 0;
            IsAre();
            Console.WriteLine("These is what is in the bag:");
            foreach (OneDie die in this.DicePool)
            {
                switch (die.Sides)
                {
                    case 4:
                        d4++;
                        break;
                    case 6:
                        d6++;
                        break;
                    case 8:
                        d8++;
                        break;
                    case 10:
                        d10++;
                        break;
                    case 12:
                        d12++;
                        break;
                    case 20:
                        d20++;
                        break;
                }
            }
            Console.WriteLine(d4 + "d4");
            Console.WriteLine(d6 + "d6");
            Console.WriteLine(d8 + "d8");
            Console.WriteLine(d10 + "d10");
            Console.WriteLine(d12 + "d12");
            Console.WriteLine(d20 + "d20\n");
            Pause();
        }
    }
}
