using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    internal class Aula
    {
        // TODO, plantearse rehacerlo sin hashtable
        // 4 Columnas
        //private Hashtable alumnos = new Hashtable();
        private String[] nombresAlumnos;
        private int[,] notas;

        public enum Asignaturas
        {
            Pociones,
            Quidditch,
            Criaturas,
            ArtesOscuras
        }

        public Aula(String[] nombresAlumnos) // Establece el tamaño de notas
        {
            this.nombresAlumnos = Array.ConvertAll(nombresAlumnos, elemento => elemento.Trim().ToUpper());
            notas = new int[nombresAlumnos.Length, 4];
            Random rn = new Random();

            for (int i = 0; i < nombresAlumnos.Length; i++)
            {
                for (int j = 0; j < notas.GetLength(1); j++)
                {
                    notas[i, j] = rn.Next(0, 11);
                }
            }
        }

        public String[] NombresAlumnos
        {
            get { return nombresAlumnos; }
        }

        public String[] Alumnos
        {
            get { return nombresAlumnos; }
        }

        public int[,] Notas
        {
            get { return notas; }
        }

        public Aula(String nombresAlumnos) // Nombres seprarados x comas
        {
            String[] nombresTemp = nombresAlumnos.Split(',');
            this.nombresAlumnos = Array.ConvertAll(nombresTemp, elemento => elemento.Trim().ToUpper());
            notas = new int[nombresTemp.Length, 4];
            Random rn = new Random();
            for (int i = 0; i < nombresTemp.Length; i++)
            {
                for (int j = 0; j < notas.GetLength(1); j++)
                {
                    notas[i, j] = rn.Next(0, 11);
                }
            }
        }

        public String this[int index]
        {
            set
            {
                nombresAlumnos[index] = value;
            }
            get
            {
                return nombresAlumnos[index];
            }
        }

        public void MaxYMin(int alumno, out int max, out int min)
        {
            if (alumno < notas.GetLength(0) && alumno >= 0)
            {
                int[] fila = new int[notas.GetLength(1)];
                for (int i = 0; i < notas.GetLength(1); i++)
                {
                    fila[i] = notas[alumno, i];
                }
                max = fila.Max();
                min = fila.Min();
            }
            else
            {
                max = -1;
                min = -1;
            }
        }

        // Hace la media de todos
        public double Media()
        {
            int[] fila = new int[notas.GetLength(1)];
            double[] medias = new double[notas.GetLength(0)];
            for (int i = 0; i < notas.GetLength(0); i++)
            {
                for (int j = 0; j < notas.GetLength(1); j++)
                {
                    fila[j] = notas[i, j];
                }
                medias[i] = fila.Average();
            }
            return medias.Average();
        }

        // Hace la media de un alumno
        public double Media(int index)
        {
            if (index < notas.GetLength(0) && index >= 0)
            {
                // Hace la media del alumnos
                int[] fila = new int[notas.GetLength(1)];
                for (int i = 0; i < notas.GetLength(1); i++)
                {
                    fila[i] = notas[index, i];
                }
                return fila.Average();
            }
            else
            {
                return -1;
            }
        }

        public double Media(Asignaturas asig)
        {
            if ((int)asig < notas.GetLength(1) && (int)asig >= 0)
            {
                // Hace la media de la asignatura
                int[] columna = new int[notas.GetLength(0)];
                for (int i = 0; i < notas.GetLength(0); i++)
                {
                    columna[i] = notas[i, (int)asig];
                }
                return columna.Average();
            }
            else
            {
                return -1;
            }
        }
    }
}
