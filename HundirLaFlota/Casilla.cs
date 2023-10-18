using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HundirLaFlota
{
    public class Casilla
    {
        private string nombre;
        private string sprite;

        public Casilla(string nombre, string sprite)
        {
            this.Nombre = nombre;
            this.Sprite = sprite;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Sprite { get => sprite; set => sprite = value; }
    }
}
