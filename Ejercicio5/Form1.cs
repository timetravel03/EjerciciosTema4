using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio5
{
    public partial class Form1 : Form
    {
        private List<string> listaL1;
        private List<string> listaL2;
        private ToolTip tooltip;
        private string tituloFormulario;
        private char[] titulo;
        private int contador;
        public Form1()
        {
            InitializeComponent();
            listaL1 = new List<string>();
            listaL2 = new List<string>();

            tooltip = new ToolTip();
            tooltip.InitialDelay = 200;

            tooltip.SetToolTip(this.textBox1, "Texto que se quiere añadir");
            tooltip.SetToolTip(this.listBox2, "Nº de elementos: " + listaL2.Count);
            tooltip.SetToolTip(this.buttonTras, "Transfiere elementos de esta lista a la otra");
            tooltip.SetToolTip(this.buttonTras2, "Transfiere elementos de esta lista a la otra");
            tooltip.SetToolTip(this.buttonElim, "Elimina los elementos seleccionados en esta lista");

            tituloFormulario = this.Text;
            titulo = tituloFormulario.ToCharArray();

            timer1.Interval = 200;
            timer1.Start();

            contador = 0;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string textoTextBox = this.textBox1.Text.Trim();

            if (textoTextBox != "" && !listBox1.Items.Contains(textoTextBox) && !listBox2.Items.Contains(textoTextBox))
            {
                listBox1.Items.Add(textoTextBox);
                this.labelPrincipal.Text = String.Format("Nº de elementos: {0}", this.listBox1.Items.Count);
            }
        }

        private void buttonElim_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.SelectedItems.Count - 1; i >= 0; i--)
            {
                listBox1.Items.Remove(listBox1.SelectedItems[i]);
            }
            this.labelIndices.Text = "Índices seleccionados:\n";
            this.labelPrincipal.Text = String.Format("Nº de elementos: {0}", this.listBox1.Items.Count);
        }

        private void RefrecarListbox()
        {
            this.listBox1.Items.Clear();
            this.listBox2.Items.Clear();
            foreach (string elemento in listaL1)
            {
                this.listBox1.Items.Add(elemento);
            }
            foreach (string elemento in listaL2)
            {
                this.listBox2.Items.Add(elemento);
            }

            this.labelPrincipal.Text = String.Format("Nº de elementos: {0}", this.listBox1.Items.Count);
            tooltip.SetToolTip(this.listBox2, "Nº de elementos: " + listaL2.Count);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string indicesFormato = "";
            ListBox.SelectedIndexCollection indices = this.listBox1.SelectedIndices;
            for (int i = 0; i < indices.Count; i++)
            {
                if (i != indices.Count - 1)
                {
                    indicesFormato += indices[i] + ", ";
                }
                else
                {
                    indicesFormato += indices[i];
                }
            }
            this.labelIndices.Text = "Índices seleccionados:\n" + indicesFormato;
        }

        private void buttonTras_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.SelectedItems.Count - 1; i >= 0; i--)
            {
                listBox2.Items.Add(listBox1.SelectedItems[i]);
                listBox1.Items.Remove(listBox1.SelectedItems[i]);
            }
            this.labelIndices.Text = "Índices seleccionados:\n";
            tooltip.SetToolTip(this.listBox2, "Nº de elementos: " + listaL2.Count);
            this.labelPrincipal.Text = String.Format("Nº de elementos: {0}", this.listBox1.Items.Count);
        }

        private void buttonTras2_Click(object sender, EventArgs e)
        {
            if (this.listBox2.SelectedItem != null)
            {
                listBox1.Items.Add(this.listBox2.SelectedItem.ToString());
                listBox2.Items.Remove(this.listBox2.SelectedItem.ToString());
                tooltip.SetToolTip(this.listBox2, "Nº de elementos: " + listaL2.Count);
                this.labelPrincipal.Text = String.Format("Nº de elementos: {0}", this.listBox1.Items.Count);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            contador++;
            char temp = titulo[titulo.Length - 1];

            for (int i = titulo.Length - 1; i > 0; i--)
            {
                titulo[i] = titulo[i - 1];
            }

            titulo[0] = temp;

            this.Text = new string(titulo);
            if (contador % 2 == 0)
            {
                this.Icon = Properties.Resources.paper;
            }
            else
            {
                this.Icon = Properties.Resources.explorer;
            }

        }
    }
}
