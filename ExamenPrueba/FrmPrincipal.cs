using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ExamenPrueba
{
    public partial class FrmPrincipal : Form
    {
        private int contador;
        private Button[] coleccionBotones;
        private List<CheckBox> checkboxesMarcados;

        public FrmPrincipal()
        {
            InitializeComponent();
            CrearCheckBoxes();

            checkboxesMarcados = new List<CheckBox>();

            btnJugar.BackColor = Color.Beige;
            btnReset.BackColor = Color.Beige;
            btnSalir.BackColor = Color.Beige;

            coleccionBotones = new Button[] { btnJugar, btnReset, btnSalir };

            timer1.Interval = 300;
            contador = 0;
            timer1.Start();

            btnReset.Click += new EventHandler(AccionReset);
            resetToolStripMenuItem.Click += new EventHandler(AccionReset);

            this.FormClosing += new FormClosingEventHandler(formClosingHandler);
            btnSalir.Click += new EventHandler((object o, EventArgs e) => this.Close());
            salirToolStripMenuItem.Click += new EventHandler((object o, EventArgs e) => this.Close());
        }

        private void CrearCheckBoxes()
        {
            CheckBox checkBox;
            ToolTip toolTip;
            int x = 30;
            int y = 30;
            int espacio = 40;
            int contador = 1;

            while (contador <= 49)
            {
                checkBox = new CheckBox();
                checkBox.Size = new System.Drawing.Size(30, 30);
                checkBox.Text = contador.ToString();
                checkBox.TextAlign = ContentAlignment.BottomCenter;
                checkBox.Location = new Point(x, y);
                //checkBox.TabIndex = contador;
                this.Controls.Add(checkBox);
                toolTip = new ToolTip();
                checkBox.CheckStateChanged += new EventHandler(CheckedStateListener);
                toolTip.SetToolTip(checkBox, checkBox.Checked ? "Marcado" : "No Marcado");
                if (contador % 6 == 0)
                {
                    y += espacio;
                    x = 30;
                }
                else
                {
                    x += espacio;
                }
                contador++;
            }
        }

        private void CheckedStateListener(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                checkboxesMarcados.Add((CheckBox)sender);
            }
            else
            {
                checkboxesMarcados.Remove((CheckBox)sender);
                ((CheckBox)sender).BackColor = DefaultBackColor;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (contador >= coleccionBotones.Length)
            {
                contador = 0;
            }
            for (int i = 0; i < coleccionBotones.Length; i++)
            {
                if (i == contador)
                {
                    coleccionBotones[i].BackColor = Color.Yellow;
                }
                else
                {
                    coleccionBotones[i].BackColor = Color.Beige;
                }
            }
            contador++;
        }

        private void AccionReset(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(CheckBox))
                {
                    CheckBox cb = (CheckBox)control;
                    cb.Checked = false;
                    cb.BackColor = DefaultBackColor;
                    ToolTip toolTip = new ToolTip();
                    toolTip.SetToolTip(cb, "No Marcado");
                }
            }
        }

        private void formClosingHandler(object sender, FormClosingEventArgs e)
        {
            if (lstNombres.Items.Count != 0)
            {
                DialogResult dr = MessageBox.Show("Se saldrá de la aplicación", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (dr != DialogResult.OK)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            if (checkboxesMarcados.Count == 6)
            {
                lblResultados.Text = "";
                int aciertos = 0;
                Random rn = new Random();
                int[] numeros = new int[6];
                for (int i = 0; i < numeros.Length; i++)
                {
                    numeros[i] = rn.Next(49) + 1;
                    lblResultados.Text += numeros[i] + " ";
                }
                foreach (CheckBox cb in checkboxesMarcados)
                {
                    foreach (int n in numeros)
                    {
                        if (int.Parse(cb.Text) == n)
                        {
                            cb.BackColor = Color.Gold;
                            aciertos++;
                            break;
                        }
                        else
                        {
                            cb.BackColor = DefaultBackColor;
                        }
                    }
                }

                if (aciertos >= 1)
                {
                    FrmDatos secundario = new FrmDatos();
                    DialogResult dr = secundario.ShowDialog();

                    if (dr == DialogResult.OK)
                    {
                        Record r = new Record(secundario.Nombre, secundario.Edad, aciertos);
                        lstNombres.Items.Add(r.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Se deben marcar 6 checkboxes", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            for (int i = lstNombres.SelectedIndices.Count - 1; i >= 0; i--)
            {
                lstNombres.Items.RemoveAt(lstNombres.SelectedIndices[i]);
            }
        }
    }
}
