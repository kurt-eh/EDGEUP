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
        private int _sides, _rolledValue;
        private static Random _random = new Random((int)DateTime.Now.Ticks);

        public int Sides
        {
            get
            {
                return this._sides;
            }
            set
            {
                this._sides = value;
            }
        }
        public int RollValue
        {
            get
            {
                return this._rolledValue;
            }
            set
            {
                this._rolledValue = value;
                RollIt(value);
            }
        }
        public OneDie()
        {

        }
        public OneDie(int sides)
        {
                this.Sides = sides;
                this.RollValue = RollIt(sides);
                //int x = this.RollValue;
        }

        private int RollIt (int sides)
        {
            return _random.Next(1, (sides + 1));
        }

    }
}
