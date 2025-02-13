﻿using System;
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
        public static int score = 0;
        public static int lives = 5;
        public static int difficulty;

        
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        Ball chaseBall = new Ball(40, 100, 10, 10);
        Player hero;
        Boolean leftArrowDown, rightArrowDown, upArrowDown, downArrowDown;
        List<Ball> balls = new List<Ball>();
        Random randgen = new Random();  


        public GameScreen()
        {
            InitializeComponent();
            InitializeGame();
        }

        public void InitializeGame()
        {

            hero = new Player(50, 100);
            //putting variables in here instead of at the top makes them easier to reset
            //int x = randgen.Next(10, this.Width - 30);
            //int y = randgen.Next(10, this.Height - 30);
            Ball chaseBall = new Ball(40, 100, 10, 10);
            
            for (int i = 0; i < difficulty; i++)
            {
                NewBall();
            }


        }

        private void engine_Tick(object sender, EventArgs e)
        {

            if (leftArrowDown && hero.x > 0)
            {
                hero.Move("left");
            }
            if (rightArrowDown && hero.x < this.Width - hero.width)
            {
                hero.Move("right");
            }
            if (upArrowDown && hero.y > 0)
            {
                hero.Move("up");
            }
            if (downArrowDown && hero.x < this.Height - hero.height)
            {
                //hero.y += hero.speed;
                hero.Move("down");
            }

            chaseBall.Move(this.Width, this.Height);


            foreach (Ball b in balls)
            {
                b.Move(this.Width, this.Height);
            }

            foreach (Ball b in balls)
            {
               chaseBall.Collision(b);
            }

            if (chaseBall.Collision(hero))
            {
                lives++;
                score++;
            }

            foreach (Ball b in balls)
            {
               if (b.Collision(hero))
                {
                    NewBall();
                    lives--;
                    break;
                }
            }

            if (lives == 0)
            {
                engine.Stop();
                Form1.ChangeScreen(this, new GameOverScreen());
            }
            

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(whiteBrush, hero.x, hero.y, hero.width, hero.height);
            e.Graphics.FillEllipse(greenBrush, chaseBall.x, chaseBall.y, chaseBall.size, chaseBall.size);
            foreach (Ball b in balls)
            {
                e.Graphics.FillEllipse(redBrush, b.x, b.y, b.size, b.size);
            }
        }


        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
            }
        }

        public void NewBall()
        {
            int x = randgen.Next(10, this.Width - 30);
            int y = randgen.Next(10, this.Height - 30);
            Ball newBall = new Ball(x, y, 10, 10);
            balls.Add(newBall);
        }
    }
}
