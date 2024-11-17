using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPrueba
{
    internal class Record
    {
        public string Nombre { get; set; }
        private int edad;
        public int Edad
        {
            get { return edad; }
            set
            {
                if (value >= 0)
                {
                    edad = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public int Puntuacion { get; set; }

        public Record(string nombre, int edad, int puntuacion)
        {
            Nombre = nombre;
            Edad = edad;
            Puntuacion = puntuacion;
        }

        public override string ToString()
        {
            return Nombre + " " + Edad + " " + Puntuacion;
        }
    }
}
