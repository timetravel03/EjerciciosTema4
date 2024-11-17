using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenPrueba
{
    public partial class FrmDatos : Form
    {
        private string nombre;
        private int edad;

        public string Nombre
        {
            get { return nombre; }
        }

        public int Edad
        {
            get { return edad; }
        }

        public FrmDatos()
        {
            InitializeComponent();
            btnAceptar.MouseEnter += new EventHandler(EntraYCambia);
            btnCancelar.MouseEnter += new EventHandler(EntraYCambia);
            btnAceptar.MouseLeave += new EventHandler(SaleYCambia);
            btnCancelar.MouseLeave += new EventHandler(SaleYCambia);
        }

        private void FrmDatos_Load(object sender, EventArgs e)
        {
            for (int i = 18; i <= 100; i++)
            {
                cboEdad.Items.Add(i);
            }
        }

        private void EntraYCambia(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Blue;
        }

        private void SaleYCambia(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Gainsboro;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() != "" && cboEdad.SelectedItem != null)
            {
                nombre = txtNombre.Text.Trim();
                edad = int.Parse(cboEdad.SelectedItem.ToString());
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
