using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_WindowsFormsApp
{
    public partial class Form1 : Form
    {
        short count = 0;
        double Num;
        bool pressed = false;
        string operation;

        Point start_point;
        bool Mouse_Down;

        public Form1()
        {
            InitializeComponent();
        }

      

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if ((textBox.Text == "0") || (pressed == true && count == 0) )
            {
                textBox.Clear();
            }
            
            Button b = (Button)sender;
            textBox.Text = textBox.Text + b.Text;
            count++;
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            textBox.Text = "0";
            Num = 0;
            pressed = false;    
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (textBox.Text.Length > 1)
            {
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1, 1);
                //Num = Double.Parse(textBox.Text);
            }
            else if (textBox.Text.Length == 1)
            {
                textBox.Text = "0";

            }
            
        }

     

        private void operator_Click(object sender, EventArgs e)
        {
            count = 0;
            Button b = (Button) sender;
            if (pressed && (operation !=""))
            {
                Num = Calculate(operation);
                textBox.Text = Num.ToString(); 
                operation = b.Text;
           
            }
            else
            {
                operation = b.Text;
                //buttonEqual.PerformClick(); 
                Num = Double.Parse(textBox.Text);
                pressed = true;
            }
            
        }

    

        private double Calculate(string opr)
        {
            switch (operation)
            {
                case "+":
                    Num = Num + Double.Parse(textBox.Text);
                    break;
                case "-":
                    Num = Num - Double.Parse(textBox.Text);
                    break;
                case "*":
                    Num = Num * Double.Parse(textBox.Text);
                    break;
                case "/":
                    Num = Num / (Double.Parse(textBox.Text));
                    break;
                default:
                    break;          
            }
            return Num; 
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            count = 0;
            Num = Calculate(operation);
            textBox.Text = Num.ToString();
            operation = "";
            
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Mouse_Down = true;
            start_point = new Point(e.X, e.Y);

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mouse_Down)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.start_point.X, p.Y - this.start_point.Y);

            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Mouse_Down = false;
        }
    }
}
