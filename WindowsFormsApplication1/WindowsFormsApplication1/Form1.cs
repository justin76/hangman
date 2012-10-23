using System;
using System.Collections;
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
    public partial class Form1 : Form
    {
       
        PictureBox pBox;
        Bitmap bm;
        Graphics graphics;
        enum bodyParts { Rope ,Head , lEye, rEye, body, lHand, rHand, lLeg, rLeg, platform };
        String currWord = "";
        List<Label> blanks = new List<Label>();
        int chances = 0;
        void Image(bodyParts bp)
        {
            Pen pb = new Pen(Color.Brown);
            Pen pw = new Pen(Color.YellowGreen, 5);
            SolidBrush sbr = new SolidBrush(Color.Brown);
            SolidBrush sbrw = new SolidBrush(Color.White);
            Pen tp = new Pen(Color.SaddleBrown, 10);
            refr();
            if (bp == bodyParts.platform)
            {
                graphics.DrawLine(tp, 500, 400, 500, 100); // Pole
                graphics.DrawLine(tp, 500, 100, 400, 100); // Rope Support
                graphics.DrawLine(tp, 350, 400, 550, 400); // Base or Platform
                return;
            }
            if (bp == bodyParts.Rope)
            {
            graphics.DrawLine(pw, 400, 100, 400, 150);  // Rope
            }
            if (bp == bodyParts.Head)
            {        
            graphics.FillEllipse(sbr, 375, 150, 50, 50);// Head
            }
            if (bp == bodyParts.body)
            {
            graphics.DrawLine(pb, 400, 200, 400, 300);  // Body
            }
            if (bp == bodyParts.rHand)
            {
                graphics.DrawLine(pb, 400, 225, 375, 250);  // Rigt Hand
            }
            if (bp == bodyParts.lHand)
            {
                graphics.DrawLine(pb, 400, 225, 425, 250);  // Left Hand
            }
            if (bp == bodyParts.rLeg)
            {
                graphics.DrawLine(pb, 400, 300, 375, 325);  // Right Leg
            }
            if (bp == bodyParts.lLeg)
            {
                graphics.DrawLine(pb, 400, 300, 425, 325); // Left Leg
            }
            if (bp == bodyParts.rEye)
            {
                graphics.FillEllipse(sbrw, 385, 160, 10, 15); // Right Eye
            }
            if (bp == bodyParts.lEye)
            {
                graphics.FillEllipse(sbrw, 405, 160, 10, 15); // Left Eye      
            }
        }
            public Form1()
                    {
            InitializeComponent();
                    }
            void refr()
                    {
            pBox.Image = bm;      // Bitmap image on picturebox
                    }
            public void game()
                    {
            currWord = randomWord().ToString();
            label2.Text = randomWord().ToString().Length.ToString();
           

                int loc = 10;
                for (int x = 0; x <= randomWord().Length - 1; x++)
                    {
                blanks.Add(new Label());
                blanks[x].Location = new Point(30 + loc, 30);
                blanks[x].Text = "-";
                blanks[x].Font = new Font(blanks[x].Font.Name, 15.0F, blanks[x].Font.Style, blanks[x].Font.Unit);
                blanks[x].Parent = groupBox1;
                blanks[x].BringToFront();
                blanks[x].CreateControl();
                loc = loc + 20;
                    }
                    }
            public String randomWord()
                    {
            List<String> wordList = new List<String>();
            List<String> hint = new List<string>();
            // Places
            wordList.Add("Argentina"); 
            wordList.Add("SaoPaulo");
            wordList.Add("London");
            wordList.Add("Chicago");
            //Game
            wordList.Add("Hangman"); 
            //Sports
            wordList.Add("Cricket"); 
            wordList.Add("Football");
            wordList.Add("Tennis");
            wordList.Add("Boxing");
            wordList.Add("Racing");
            //Animal
            wordList.Add("cat");
            wordList.Add("dog");
            //Reading
            wordList.Add("book"); 
            //Meals
            wordList.Add("breakfeast"); 
            //Communication
            wordList.Add("telephone"); 
           
            //Amalgamation
            wordList.Add("mixture"); 
            // Expression
            wordList.Add("music");     
            //Species
            wordList.Add("animal");   
            wordList.Add("plant");
            //Learning Academy
            wordList.Add("school");
            //Structure  
            wordList.Add("Building");  
            
            //Office Tools
            wordList.Add("pen");    
            wordList.Add("pencil");
            wordList.Add("paper");
            Random random = new Random();
            int i = new int();
            i = wordList.Count;
            int j = random.Next(0, i);
            int wordLoc = j;
            String word = wordList[j].ToString().ToLower();
            return word;
                     }
            private void Form1_Load(object sender, EventArgs e)
                     {
            
            pBox = new PictureBox();
            pBox.Parent = this;
            pBox.Location = new Point(10, 10);
            pBox.Size = new Size(590, 450);
            bm = new Bitmap(pBox.Width, pBox.Height);
            graphics = Graphics.FromImage(bm);
            game();
            Image(bodyParts.platform);

                     }
            private void Enter_Click(object sender, EventArgs e)
                     {
            if (String.IsNullOrEmpty(letter.Text))
                     {
                MessageBox.Show("Please only enter an Alphabet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
                     }
            char input = letter.Text.ToLower().ToCharArray()[0];
            if (String.IsNullOrWhiteSpace(input.ToString()) || !char.IsLetter(input))
                     {
                MessageBox.Show("Please only enter an Alphabet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     return;
                     }
                     if (currWord.Contains(input.ToString()))
                     {
                     for (int l = 0; l < currWord.Length; l++)
                     {
                     if (currWord[l] == input)
                    
                        blanks[l].Text = input.ToString();
                     }
                     }
            else
                     {
                     MessageBox.Show("Wrong Guess! Try again", "Miss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     label3.Text += " " + letter.Text.ToString() + ",";
                     Image((bodyParts)chances);
                     chances++;
                     if (chances == 9)
                     {
                     DialogResult dr =  MessageBox.Show("Game Over: Do you want to try again ?", "Game Over",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                     switch (dr) 
                     {
                         case DialogResult.Yes:
                             this.Close();
                             break;
                         case DialogResult.No:
                             Application.Exit(); 
                             break;
                         default:
                             Application.Exit();
                             break;
                     }           
                     }
                     }
            foreach (Label la in blanks)
                if (la.Text == "-")
                    return;
            DialogResult dr2 = MessageBox.Show("Congratulations, You Win! Do you want to Play again?", "WIN", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    switch (dr2)
                    {
                        case DialogResult.Yes:
                            this.Close();
                            break;
                        case DialogResult.No:
                            Application.Exit();
                            break;
                        default:
                            Application.Exit();
                            break;
                    }
                    }
                    }
                    }
   
