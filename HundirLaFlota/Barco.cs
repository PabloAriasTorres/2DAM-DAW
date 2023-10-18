using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HundirLaFlota
{
    public class Barco
    {
        private string nombre;
        private bool vivo;
        private string casilla;

        public Barco(string nombre, bool vivo, string casilla)
        {
            this.Nombre = nombre;
            this.Vivo = vivo;
            this.Casilla = casilla;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public bool Vivo { get => vivo; set => vivo = value; }
        public string Casilla { get => casilla; set => casilla = value; }
    }
}
