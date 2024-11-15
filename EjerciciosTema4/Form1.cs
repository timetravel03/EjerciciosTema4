#define KEY
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjerciciosTema4
{
    // Validado
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Button button;
        private int x = 20;
        private int y = 10;
        //Color colorButton = button1.BackColor;
        public Form1()
        {
            InitializeComponent();
            for (int i = 1; i <= 20; i++)
            {
                button = new Button();
                button.Location = new Point(x, y);
                button.Size = new Size(50, 20);
                button.Text = i.ToString();
                button.MouseDown += new MouseEventHandler(this.DynamicOnClick);
                button.MouseMove += new MouseEventHandler(this.MyMouseMove);
                this.Controls.Add(button);
                if (i % 5 == 0)
                {
                    x = 20;
                    y += 30;
                }
                else
                {
                    x += 60;
                }
            }
        }

        private void DynamicOnClick(object sender, EventArgs e)
        {
            this.Text = ((Button)sender).Text;
        }

        private void MyMouseMove(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == typeof(Button))
            {
                Button button = (Button)sender;
                this.Text = String.Format("{{X={0} Y={1}}}", (button.Location.X + e.Location.X), (button.Location.Y + e.Location.Y));
            }
            else
            {
                this.Text = e.Location.ToString();
            }
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            this.Text = "MouseTester";
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                button1.BackColor = Color.Green;
            }
            else if (e.Button == MouseButtons.Right)
            {
                button2.BackColor = Color.Red;
            }
            else
            {
                button1.BackColor = Color.Purple;
                button2.BackColor = Color.Purple;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                button1.BackColor = Color.Gainsboro;
            }
            else if (e.Button == MouseButtons.Right)
            {
                button2.BackColor = Color.Gainsboro;
            }
            else
            {
                button1.BackColor = Color.Gainsboro;
                button2.BackColor = Color.Gainsboro;
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
#if KEY
            if (e.KeyCode == Keys.Escape)
            {
                this.Text = "MouseTester";
            }
            else
            {
                this.Text = e.KeyCode.ToString();
            }
#endif
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
#if !KEY
            if (e.KeyChar == 27) // Esc en  o algo asi
            {
                this.Text = "MouseTester";
            }
            else
            {
                this.Text = e.KeyChar.ToString();
            }
#endif
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Quieres cerrar el formulario?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
