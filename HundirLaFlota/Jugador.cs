using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HundirLaFlota
{
    public class Jugador
    {
        List<Barco> barcos = new List<Barco>();
        private string nombre = "";
        public Jugador(String nombre)
        {
            this.Nombre = nombre;
        }

        public List<Barco> Barcos { get => barcos; set => barcos = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        //ESTO LO CREA EL PROPIO VISUAL STUDIO AL RELACIONARLO CON OTRA CLASE EN ESTE CASO CON BARCO
        public Barco Barco
        {
            get => default;
            set
            {
            }
        }
    }
}
