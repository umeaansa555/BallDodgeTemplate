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

        
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        Ball chaseBall = new Ball(40, 100, 10, 10);
        List<Ball> balls = new List<Ball>();
        Random randgen = new Random();  


        public GameScreen()
        {
            InitializeComponent();
            InitializeGame();
        }

        public void InitializeGame()
        {
            //putting variables in here instead of at the top makes them easier to reset
            int x = randgen.Next(10, this.Width - 30);
            int y = randgen.Next(10, this.Height - 30);
            Ball chaseBall = new Ball(40, 100, 10, 10);
            
            for (int i = 0; i < 4; i++)
            {
                x = randgen.Next(10, this.Width - 30);
                y = randgen.Next(10, this.Height - 30);
                Ball newBall = new Ball(x, y, 10, 10);
                balls.Add(newBall);
            }


        }

        private void engine_Tick(object sender, EventArgs e)
        {

            chaseBall.Move(this.Width, this.Height);


            foreach (Ball b in balls)
            {
                b.Move(this.Width, this.Height);
            }


            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(greenBrush, chaseBall.x, chaseBall.y, chaseBall.size, chaseBall.size);
            foreach (Ball b in balls)
            {
                e.Graphics.FillEllipse(redBrush, b.x, b.y, b.size, b.size);
            }
        }


        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
