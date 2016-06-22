using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.IO;

namespace Emotional_Bridge
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer read;
        string name;
        string gender;
        int age;
        int count = 0;
        string date = DateTime.Today.ToShortDateString();

        public Form1()
        {
            InitializeComponent();
            read = new SpeechSynthesizer();
            read.SpeakAsync("Welcome to Emotional Bridge");
            read.SpeakAsync("May i know your Name ? ");
        }




           

        public void Form1_Load(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            name = textBox1.Text;
            read.SpeakAsync("May i know your gender ?");
            label5.Visible = true;



        }

        public void button2_Click(object sender, EventArgs e)
        {
            read.SpeakAsync("How old are you ? ");
            button3.Visible = true;
            numericUpDown1.Visible = true; 
            if(radioButton1.Checked == true)
            {
                gender = "Male";
                read.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult);
            }
            else if(radioButton2.Checked == true)
            {
                gender = "Female";
                read.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
            }
            label6.Visible = true;
        }

        public void button3_Click(object sender, EventArgs e)
        {
            if (count == 0)
            {
                button1.Visible = false;
                button2.Visible = false;
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                numericUpDown1.Visible = false;
                textBox1.Visible = false;
                age = Convert.ToInt32(numericUpDown1.Value);
                read.SpeakAsync("Your name is " + name + age + "Years old" + gender);
                label3.Text = "Name : " + name;
                label5.Text = "Gender : " + gender;
                label6.Text = "Age : " + age;
                button3.Text = "Next";
                count = 1;
            }
            else if(count == 1)
            {
                label3.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                radioButton3.Visible = true;
                radioButton4.Visible = true;
                button4.Visible = true;
                button3.Visible = false; 
            }
            else if(count == 2)
            {
                read.SpeakAsync(richTextBox1.Text);
                button4.Visible = true;
                button3.Visible = false;
                richTextBox1.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                read.SpeakAsync("Today's date is : " + date);
                label4.Visible = true;
                label4.Text = date;
            }
            else if (radioButton4.Checked == true)
            {
                label4.Visible = false; 
                richTextBox1.Visible = true;
                button3.Visible = true;
                count=2;
                button4.Visible = false; 

            }
        }
    }
}
