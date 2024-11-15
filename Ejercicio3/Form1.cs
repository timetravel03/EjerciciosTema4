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

namespace Ejercicio3
{
    public partial class Form1 : Form// Excepciones, imagen tamaño original
    {
        private bool checkMarcado;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = "c:\\";
                ofd.Filter = "JPG|*.jpg|PNG|*.png|All Files|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string ruta = ofd.FileName;
                    FormularioImagen form = new FormularioImagen();
                    form.ruta = ruta;
                    if (checkMarcado)
                    {
                        form.ShowDialog();
                    } else
                    {
                        form.Show();
                    }
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox temp = ((CheckBox)sender);
            temp.ForeColor = temp.Checked ? Color.Red : Color.Black;
            checkMarcado = temp.Checked;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("¿De verdad quieres salir?", "Cerrar Formulario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
