using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA4_4_2_DicePool
{
    //biuld a single die
    /*
      Create a class representing a single die. The constructor should accept an integer indicating how many sides the die has. The class should have a function to simulate rolling the die, returning a random number within the valid range.
     */
    
    class OneDie
    {
        public int Sides { get; private set; }
        public OneDie()
        {

        }
        public OneDie(int sides)
        {
            this.Sides = sides;
            //this.RollValue = RollIt(sides); //initially included because a die will always have a number on the top.
        }
        public int RollIt(int sides, Random random)
        {
            return random.Next(1, (sides + 1));
        }
    }
}
