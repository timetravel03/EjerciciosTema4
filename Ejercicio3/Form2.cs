using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio3
{
    public partial class FormularioImagen : Form
    {
        public string ruta;
        public FormularioImagen()
        {
            InitializeComponent();
        }

        private void FormularioImagen_Load(object sender, EventArgs e)
        {
            try
            {
                Image img = Image.FromFile(ruta);
                this.ClientSize = new Size(img.Width,img.Height);
                this.pictureBox1.Image = img;
                FileInfo f = new FileInfo(ruta);
                this.Text = f.Name;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Argumento no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Sin memoria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Archivo no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
