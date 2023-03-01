using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallDodgeTemplate
{
    public partial class GameScreen : UserControl
    {

        Ball chaseBall = new Ball(40, 100, 10,10);
        SolidBrush greenBrush = new SolidBrush(Color.Green);

        public GameScreen()
        {
            InitializeComponent();
        }

        private void engine_Tick(object sender, EventArgs e)
        {

            /*chaseBall.x += chaseBall.xSpeed;
            chaseBall.y += chaseBall.ySpeed;*/

            chaseBall.Move(this.Width, this.Height);

            /*if(chaseBall.x > this.Width - chaseBall.size || chaseBall.x < 0)
            {
                chaseBall.xSpeed *= -1;
            }
            if (chaseBall.y > this.Height - chaseBall.size || chaseBall.y < 0)
            {
                chaseBall.ySpeed *= -1;
            }*/


            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(greenBrush, chaseBall.x, chaseBall.y, chaseBall.size, chaseBall.size);
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
