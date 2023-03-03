using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallDodgeTemplate
{
    internal class Player
    {
        public int x, y;
        public int speed = 6;
        public int width = 30, 
                   height = 10;


        public Player(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
        }

    }
}
