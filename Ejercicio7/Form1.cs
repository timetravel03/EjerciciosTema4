using Ejercicio2;
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
using static Ejercicio2.Aula;

namespace Ejercicio7
{
    public partial class Form1 : Form
    {
        private Aula aula;
        private string infoAlumno;
        public Form1()
        {
            InitializeComponent();
            string home = Environment.GetEnvironmentVariable("homepath");
            string nombresCSV;
            using (StreamReader sr = new StreamReader(home+"\\bladerunner.txt"))
            {
                nombresCSV = sr.ReadToEnd();
            }

            aula = new Aula(nombresCSV.Split(';'));

            foreach (string nombre in aula.Alumnos)
            {
                comboBoxAlumno.Items.Add(nombre);
            }
            comboBoxAlumno.SelectedIndex = 0;
            foreach (Aula.Asignaturas asignatura in Enum.GetValues(typeof(Aula.Asignaturas)))
            {
                comboBoxAsig.Items.Add(asignatura);
            }
            comboBoxAsig.SelectedIndex = 0;
            CrearTabla();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ActualizarInformacion();
        }

        private void comboBoxAlumno_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarInformacion();
        }
        private void comboBoxAsig_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarInformacion();
        }

        private void ActualizarInformacion()
        {
            int alumno = comboBoxAlumno.SelectedIndex;
            Aula.Asignaturas asignatura = (Aula.Asignaturas)comboBoxAsig.SelectedIndex;
            aula.MaxYMin(alumno, out int max, out int min);
            infoAlumno = String.Format("Media Total: {0}\nMedia de {3}: {4}\n\nMedia de {1}: {2}\nNota máxima y mínima de {1}: {5}", Math.Round(aula.Media(), 2), aula[alumno], Math.Round(aula.Media(alumno), 2), asignatura.ToString(), Math.Round(aula.Media(asignatura), 2), max + " y " + min);
            labelInfoAlumno.Text = infoAlumno;
        }

        public void CrearTabla()
        {
            string[] nombresAsig = Enum.GetNames(typeof(Aula.Asignaturas));
            int cabeceraY = 100;
            int cabeceraX = 110;
            int espacio = 80;
            Label labelTemp;

            for (int i = 0; i < nombresAsig.Length; i++)
            {
                labelTemp = new Label();
                labelTemp.Text = nombresAsig[i];
                labelTemp.Size = new Size(75, 20);
                labelTemp.Location = new Point(cabeceraX, cabeceraY);
                this.Controls.Add(labelTemp);
                cabeceraX += espacio;
            }


            int x = 30;
            int y = 150;

            for (int i = 0; i < aula.Alumnos.Length; i++)
            {
                labelTemp = new Label();
                labelTemp.Text = aula[i];
                labelTemp.Size = new Size(100, 20);
                labelTemp.Location = new Point(x, y);
                this.Controls.Add(labelTemp);
                x += espacio + 20;
                for (int j = 0; j < nombresAsig.Length; j++)
                {
                    labelTemp = new Label();
                    labelTemp.Text = aula.Notas[i, j].ToString();
                    labelTemp.Size = new Size(20, 20);
                    labelTemp.TextAlign = ContentAlignment.MiddleCenter;
                    labelTemp.Location = new Point(x, y);
                    ToolTip ttp = new ToolTip();
                    ttp.SetToolTip(labelTemp, nombresAsig[j] + "\n" + aula[i]);
                    labelTemp.MouseEnter += new EventHandler((object s, EventArgs e) => { ((Label)s).BackColor = Color.Yellow; });
                    labelTemp.MouseLeave += new EventHandler((object s, EventArgs e) => { ((Label)s).BackColor = DefaultBackColor; });
                    this.Controls.Add(labelTemp);
                    x += espacio;
                }
                x = 30;
                y += 50;
            }
        }
    }
}
