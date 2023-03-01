using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallDodgeTemplate
{
    internal class Ball
    {
        public int x, y, xSpeed, ySpeed;
        public int size = 20;

        public Ball(int _x, int _y, int _xSpeed, int _ySpeed)
        {
            this.x = _x;
            this.y = _y;
            this.xSpeed = _xSpeed;
            this.ySpeed = _ySpeed;
        }

        public void Move( int screenWidth, int screenHeight)
        {
            xSpeed = 10;
            ySpeed = 10;
            x += xSpeed;
            y += ySpeed;

            if (x > screenWidth - size || x < 0)
            {
                xSpeed *= -1;
            }
            if (y > screenHeight - size || y < 0)
            {
                ySpeed *= -1;
            }
        }
    }
}
