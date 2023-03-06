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
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();
        }

        private void easyButton_Click(object sender, EventArgs e)
        {
            GameScreen.difficulty = 5;
            GameScreen.lives = 5;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void mediumButton_Click(object sender, EventArgs e)
        {
            GameScreen.difficulty = 20;
            GameScreen.lives = 3;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void hardButton_Click(object sender, EventArgs e)
        {
            GameScreen.difficulty = 30;
            GameScreen.lives = 3;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
