using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio6
{
    public partial class MainForm : Form
    {
        private PinForm form2;
        private Button[] colBotones;
        private DialogResult resultado;
        public MainForm()
        {
            InitializeComponent();
            this.resetToolStripMenuItem.Click += new EventHandler(buttonReset_Click);

            form2 = new PinForm();
            form2.Pin = "6565";
            resultado = form2.ShowDialog();
        }

        public Button[] crearBotones()
        {
            Button buttonTemp;
            Button[] btnCol = new Button[12];
            int x = 60;
            int y = 70;
            for (int i = 1; i <= 12; i++)
            {
                buttonTemp = new Button();
                buttonTemp.Text = i.ToString();
                buttonTemp.Size = new Size(50, 50);
                buttonTemp.Location = new Point(x, y);

                buttonTemp.Click += new EventHandler(gestionBotonesPrincipal);
                buttonTemp.MouseEnter += new EventHandler(MouseEnterButton);
                buttonTemp.MouseLeave += new EventHandler(MouseLeaveButton);

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

        public void gestionBotonesPrincipal(object sender, EventArgs e)
        {
            this.textBox1.Text += ((Button)sender).Text;
            Button temp = ((Button)sender);
            temp.BackColor = Color.PeachPuff;
            temp.MouseLeave -= new EventHandler(MouseLeaveButton);
            temp.MouseEnter -= new EventHandler(MouseEnterButton);

        }

        public void MouseEnterButton(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Lavender;
        }

        public void MouseLeaveButton(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Gainsboro;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (resultado != DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                colBotones = crearBotones();
            }

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            foreach (Button btn in colBotones)
            {
                btn.BackColor = Color.Gainsboro;
                btn.MouseLeave += new EventHandler(MouseLeaveButton);
                btn.MouseEnter += new EventHandler(MouseEnterButton);
            }
        }

        private void grabarNúmeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivos de texto|*.txt|Todos los archivos|*.*";
                DialogResult fileResult = saveFileDialog.ShowDialog();
                if (fileResult == DialogResult.OK)
                {
                    string archivo = saveFileDialog.FileName;
                    using (StreamWriter streamWriter = new StreamWriter(archivo, true))
                    {
                        streamWriter.WriteLine(textBox1.Text);
                    }
                        MessageBox.Show("Número guardado con éxito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No se ha introducido un número", "información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ejercicio 6\nAutor: Telmo Iglesias\nVersion: 1.0", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
