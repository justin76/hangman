using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            label1.BringToFront();
           

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
            this.Show();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hangman 1.0 -> C# Project Developed by Mohammad Abbas","About Hangman 1.0",MessageBoxButtons.OK);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("How to play: You have got 9 Chances to guess the correct word and save the hangman from being hanged","Instructions",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
