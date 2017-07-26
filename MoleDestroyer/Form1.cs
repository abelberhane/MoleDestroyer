using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MoleDestroyer
{
    public partial class Form1 : Form
    {
        //Global Variables
        Random rnd = new Random();
        int locationNum = 0;
        int score = 0;
        int misses = 0;
        bool isHit = false;

        public Form1()
        {
            InitializeComponent();
        }

        //Logic for Mole being hit.
        private void gotMole(object sender, EventArgs e)
        {
            //Increment score and show the dead image when Hit.
            score++;
            Mole.Image = Properties.Resources.dead;

            isHit = true;
            Mole.Enabled = false;
        }

        //
        private void moveMole(object sender, EventArgs e)
        {
            //Score and Miss count is attached to the label
            lblHit.Text = "Hit: " + score;
            lblMiss.Text = "Miss: " + misses;

            //If you miss, Add 1 to the Miss Counter
            if (isHit == false)
            {
                misses++;
            }

            //If you score more than 15 points, Message showing you win pops up
            if (score > 15)
            {
                timer1.Stop();
                Mole.Enabled = false;
                MessageBox.Show("You Win");
            }
            //If you miss more than 10 times, Message showing you lose pops up
            else if (misses > 10)
            {
                timer1.Stop();
                Mole.Enabled = false;
                MessageBox.Show("You Lose");
            }
            
            //The mole is moved regardless if they hit or miss
            moveMole();
        }

        //Logic for moving the Mole. 
        private void moveMole()
        { 
            // When you move a Mole, reset it to not hit and show the Alive Image.
            isHit = false;
            Mole.Enabled = true;
            Mole.Image = Properties.Resources.alive;
            Mole.BackColor = System.Drawing.Color.Transparent;

            //Randomly selects one of the 6 locations below to move the Mole to.
            locationNum = rnd.Next(1, 7);
            switch (locationNum)
            {
                case 1:
                    Mole.Left = 434;
                    Mole.Top = 249;
                    break;

                case 2:
                    Mole.Left = 257;
                    Mole.Top = 211;
                    break;

                case 3:
                    Mole.Left = 58;
                    Mole.Top = 240;
                    break;

                case 4:
                    Mole.Left = 85;
                    Mole.Top = 318;
                    break;

                case 5:
                    Mole.Left = 254;
                    Mole.Top = 364;
                    break;

                case 6:
                    Mole.Left = 416;
                    Mole.Top = 323;
                    break;

                default:
                    break;
            }
        }
    }
}
