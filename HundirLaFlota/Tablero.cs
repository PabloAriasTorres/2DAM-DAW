using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HundirLaFlota
{
    public class Tablero
    {
        private Casilla[,] casillas = new Casilla[10,10];
        private char[] letras = { 'A','B','C','D','E','F','G','H','I','J'};

        public Casilla[,] Casillas { get => casillas; set => casillas = value; }

        //ESTO LO CREA EL PROPIO VISUAL STUDIO AL RELACIONARLO CON OTRA CLASE EN ESTE CASO CON CASILLA
        public Casilla Casilla
        {
            get => default;
            set
            {
            }
        }

        public void meterDatosTablero()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    char nombre = letras[j];
                    Casillas[i, j] = new Casilla(nombre + i.ToString(), "*");
                }
            }
        }

        public void mostrarTablero()
        {
            for(int i=0; i<10;i++)
            {
                for(int j=0; j<10; j++)
                {
                    Console.Write(Casillas[i,j].Sprite);
                    Console.Write(" ");
                }
                Console.Write(i);
                Console.WriteLine();
            }
            for(int i=0; i<letras.Length; i++)
            {
                Console.Write(letras[i]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
