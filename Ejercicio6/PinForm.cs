using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio6
{
    public partial class PinForm : Form
    {
        private string pinTry;
        private string pin;
        private bool pass;
        private Button[] btnCol;
        private int intentos;

        public PinForm()
        {

            InitializeComponent();
            this.btnCol = CrearBotones();
            this.pass = false;
            this.intentos = 0;
            this.pinTry = "";

            this.FormClosing += new FormClosingEventHandler((object sender, FormClosingEventArgs e) =>
            {
                if (pass)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            });
        }

        public Button[] CrearBotones()
        {
            Button buttonTemp;
            Button[] btnCol = new Button[12];
            int x = 60;
            int y = 50;
            for (int i = 1; i <= 12; i++)
            {
                buttonTemp = new Button();
                buttonTemp.Text = i.ToString();
                buttonTemp.Size = new Size(50, 50);
                buttonTemp.Location = new Point(x, y);

                buttonTemp.Click += new EventHandler(gestionPin);

                this.Controls.Add(buttonTemp);
                if (i % 3 == 0)
                {
                    x = 60;
                    y += 70;
                }
                else
                {
                    x += 60;
                }
                btnCol[i - 1] = buttonTemp;
            }
            btnCol[11].Text = "#";
            btnCol[10].Text = "0";
            btnCol[9].Text = "*";

            return btnCol;
        }

        public void gestionPin(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (pinTry.Length < pin.Length)
            {
                pinTry += button.Text;
            }
            if (pinTry.Length == pin.Length)
            {
                if (pin == pinTry)
                {
                    pass = true;
                    this.Close();
                }
                else
                {
                    intentos++;
                    pinTry = "";
                }
            }
            if (intentos >= 3)
            {
                this.Close();
            }
        }
        private void PinForm_Load(object sender, EventArgs e)
        {
            if (pin == null)
            {
                this.Close();
            }
        }

        public string Pin { set { pin = value; } }

    }
}
