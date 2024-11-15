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

namespace Ejercicio4
{
    public partial class Form1 : Form
    {
        private Hashtable operaciones;
        private delegate void Operacion();
        private int contadorSegundos;
        private int contadorMinutos;
        public Form1()
        {
            InitializeComponent();

            operaciones = new Hashtable();
            operaciones.Add("+", new Operacion(() =>
            {
                if (Double.TryParse(this.textBox1.Text.Trim(), out double op1) && Double.TryParse(this.textBox2.Text.Trim(), out double op2))
                {
                    this.labelResultado.Text = String.Format("= {0:F2}", op1 + op2);
                }
            }));
            operaciones.Add("-", new Operacion(() =>
            {
                if (Double.TryParse(this.textBox1.Text.Trim(), out double op1) && Double.TryParse(this.textBox2.Text.Trim(), out double op2))
                {
                    this.labelResultado.Text = String.Format("= {0:F2}", op1 - op2);
                }
            }));
            operaciones.Add("x", new Operacion(() =>
            {
                if (Double.TryParse(this.textBox1.Text.Trim(), out double op1) && Double.TryParse(this.textBox2.Text.Trim(), out double op2))
                {
                    this.labelResultado.Text = String.Format("= {0:F2}", op1 * op2);
                }
            }));
            operaciones.Add("/", new Operacion(() =>
            {
                if (Double.TryParse(this.textBox1.Text.Trim(), out double op1) && Double.TryParse(this.textBox2.Text.Trim(), out double op2))
                {
                    if (op2 != 0)
                    {
                        this.labelResultado.Text = String.Format("= {0:F2}", op1 / op2);
                    }
                    else
                    {
                        this.labelResultado.Text = "Error: Division por cero";
                    }
                }
            }));

            foreach (var item in Controls)
            {
                if (item.GetType() == typeof(RadioButton))
                {
                    RadioButton rb = (RadioButton)item;
                    rb.CheckedChanged += new EventHandler(radioCheckedChange);
                }
            }

            labelSimbolo.Text = "+";

            timer1.Interval = 1000;
            timer1.Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(this.textBox1.Text, out double op1))
            {
                this.textBox1.BackColor = Color.Red;
            }
            else
            {
                this.textBox1.BackColor = Color.White;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(this.textBox2.Text, out double op1))
            {
                this.textBox2.BackColor = Color.Red;
            }
            else
            {
                this.textBox2.BackColor = Color.White;
            }
        }

        private void radioCheckedChange(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                this.labelSimbolo.Text = radioButton.Text;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Operacion op = (Operacion)operaciones[labelSimbolo.Text];
            op();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            contadorSegundos++;
            if (contadorSegundos == 60)
            {
                contadorMinutos++;
                contadorSegundos = 0;
            }
                this.Text = String.Format("{0:D2}:{1:D2}", contadorMinutos, contadorSegundos);
        }
    }
}
