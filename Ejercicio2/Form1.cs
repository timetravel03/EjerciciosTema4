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

namespace Ejercicio2//Titulo, Gestión acceptbutton, aceptar 0 y corregir mensaje, Centrado, no se ve en taskbar, reset de imagen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Colores";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.buttonColor.Click += new EventHandler((object sender, EventArgs e) => CambiaElColorDeFondo());
            this.buttonCargar.Click += new EventHandler((object sender, EventArgs e) => CargarImagen());
            this.buttonSalir.Click += new EventHandler((object sender, EventArgs e) => this.Close());
            //this.buttonSalir
            foreach (var item in Controls)
            {
                if (item.GetType() == typeof(Button))
                {
                    ((Button)item).MouseEnter += new EventHandler(MouseEnteredHandler);
                    ((Button)item).MouseLeave += new EventHandler(MouseExitedHandler);
                }
            }

            this.textBoxR.Enter += new EventHandler(rgbEnter);
            this.textBoxG.Enter += new EventHandler(rgbEnter);
            this.textBoxB.Enter += new EventHandler(rgbEnter);
        }

        private void CambiaElColorDeFondo()
        {
            if (textBoxR.Text != "" || textBoxG.Text != "" || textBoxB.Text != "")
            {
                if ((int.TryParse(textBoxR.Text.Trim(), out int r) && (int.TryParse(textBoxG.Text.Trim(), out int g)) && (int.TryParse(textBoxB.Text.Trim(), out int b))))
                {
                    if ((r >= 0 && r < 256) && (g >= 0 && g < 256) && (b >= 0 && b < 256))
                    {
                        this.BackColor = Color.FromArgb(r, g, b);
                    }
                    else
                    {
                        MessageBox.Show("Los parámetros RGB deben estar entre 0 y 256", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Los parámetros RGB no son válidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Quieres cerrar la aplicaión?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void CargarImagen()
        {
            if (textBoxRuta.Text != "")
            {
                string rutaImagen = textBoxRuta.Text;
                if (File.Exists(rutaImagen))
                {
                    try
                    {
                        Image image = Image.FromFile(rutaImagen);
                        labelImagen.Image = image;
                    }
                    catch (OutOfMemoryException)
                    {
                        MessageBox.Show("El archivo no es una imagen", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("La ruta proporcionada no existe", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MouseEnteredHandler(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.PaleVioletRed;
        }

        private void MouseExitedHandler(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.Gainsboro;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            foreach (var item in this.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    ((TextBox)item).Text = "";
                }
            }
            this.labelImagen.Image = null;
        }

        private void textBoxRuta_Enter(object sender, EventArgs e)
        {

            this.AcceptButton = buttonCargar;
        }

        private void rgbEnter(object sender, EventArgs e)
        {
            this.AcceptButton = buttonColor;
        }
    }
}
