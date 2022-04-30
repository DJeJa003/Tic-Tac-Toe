using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1Load(object sender, EventArgs e)
        {
            foreach (Control c in panel2.Controls)
            {
                if(c is Button)
                {
                    c.Click += new System.EventHandler(Btn_click);
                }
            }
        }

        int XorO = 0;
        public void Btn_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text.Equals(""))
            {
                if (XorO % 2 == 0)
                {
                    btn.Text = "X";
                    btn.ForeColor = Color.Blue;
                    label1.Text = "O, your turn";
                    GetTheWinner();
                }
                else
                {
                    btn.Text = "O";
                    btn.ForeColor = Color.Red;
                    label1.Text = "X, your turn";
                    GetTheWinner();
                }
                XorO++;
                if (win == true)
                {
                    foreach (Control c in panel2.Controls)
                    {
                        c.Enabled = false;
                    }
                }
            }
            
        }
        bool win = false;
        public void GetTheWinner()
        {
            if(!button1.Text.Equals("") && button1.Text.Equals(button2.Text) && button1.Text.Equals(button3.Text))
            {
                WinEffect(button1, button2, button3);
                win = true;
            }
            if (!button4.Text.Equals("") && button4.Text.Equals(button5.Text) && button4.Text.Equals(button6.Text))
            {
                WinEffect(button4, button5, button6);
                win = true;
            }
            if (!button7.Text.Equals("") && button7.Text.Equals(button8.Text) && button7.Text.Equals(button9.Text))
            {
                WinEffect(button7, button8, button9);
                win = true;
            }
            if (!button1.Text.Equals("") && button1.Text.Equals(button4.Text) && button1.Text.Equals(button7.Text))
            {
                WinEffect(button1, button4, button7);
                win = true;
            }
            if (!button2.Text.Equals("") && button2.Text.Equals(button5.Text) && button2.Text.Equals(button8.Text))
            {
                WinEffect(button2, button5, button8);
                win = true;
            }
            if (!button3.Text.Equals("") && button3.Text.Equals(button6.Text) && button3.Text.Equals(button9.Text))
            {
                WinEffect(button3, button6, button9);
                win = true;
            }
            if (!button1.Text.Equals("") && button1.Text.Equals(button5.Text) && button1.Text.Equals(button9.Text))
            {
                WinEffect(button1, button5, button9);
                win = true;
            }
            if (!button3.Text.Equals("") && button3.Text.Equals(button5.Text) && button3.Text.Equals(button7.Text))
            {
                WinEffect(button3, button5, button7);
                win = true;
            }
            if(DrawCheck() == 9 && win == false)
            {
                label1.Text = "It's a draw!";
            }
        }
        public int DrawCheck()
        {
            int allBtnsLngth = 0;
            foreach (Control c in panel2.Controls)
            {
                if (c is Button)
                {
                    allBtnsLngth += c.Text.Length;
                }
            }
            return allBtnsLngth;
        }
        public void WinEffect(Button b1, Button b2, Button b3)
        {
            b1.BackColor = Color.Green;
            b2.BackColor = Color.Green;
            b3.BackColor = Color.Green;

            b1.ForeColor = Color.White;
            b2.ForeColor = Color.White;
            b3.ForeColor = Color.White;

            label1.Text = b1.Text + " Wins!";
            string message = "We have a winner!";
            MessageBox.Show(message);
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            XorO = 0;
            win = false;
            label1.Text = "X starts again";
            foreach (Control c in panel2.Controls)
            {
                if (c is Button)
                {
                    c.Text = "";
                    c.BackColor = Color.White;
                }
                c.Enabled = true;
            }
        }
    }
}
