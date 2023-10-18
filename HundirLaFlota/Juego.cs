using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace HundirLaFlota
{
    public class Juego
    {
        private static Tablero tablero = new Tablero();
        private static Jugador jugador1 = new Jugador("Jugador 1");
        private static Jugador jugador2 = new Jugador("Jugador 2");
        private static List<Barco> totalBarcos = new List<Barco>(); //ESTA LISTA CONTIENE LOS BARCOS DEL JUGADOR 1 PARA QUE 
        //DESPUES EL JUGADOR 2 NO PUEDA METER UN BARCO EN LA MISMA CASILLA YA QUE SOLO HAY UN ÚNICO TABLERO
        static void Main(string[] args)
        {
            tablero.meterDatosTablero();

            Console.WriteLine("Jugador 1 crea tus barcos");
            crearBarcos(jugador1);
            Console.WriteLine("Jugador 2 crea tus barcos");
            crearBarcos(jugador2);

            string nombre_casilla;
            bool acabar = false;
            int vidas1 = 3;
            int vidas2 = 3;
            do
            {
                tablero.mostrarTablero();
                nombre_casilla = comprobarCasilla(jugador1);
                vidas2 = comprobarResultado(nombre_casilla,jugador2,vidas2);
                nombre_casilla = comprobarCasilla(jugador2);
                vidas1 = comprobarResultado(nombre_casilla,jugador1,vidas1);

                if(vidas1 == 0 || vidas2 == 0)
                {
                    if (vidas1 == 0) Console.WriteLine("HA GANADO EL JUGADOR 2");
                    else Console.WriteLine("HA GANADO EL JUGADOR 1");
                    break;
                }
            }
            while (acabar == false);
        }

        public static void crearBarcos(Jugador jugador)
        {
            int i = 0;
            string nombre = "";
            string casilla = "";
            bool correcto = false;
            Regex patron = new Regex("[A-J][0-9]");
            List<Barco> barcos = new List<Barco>();
            while(i!=3)
            {
                Console.WriteLine("Introduce el nombre del barco:");
                nombre = Console.ReadLine();
                do
                {
                    Console.WriteLine("Introduce la casilla del barco:");
                    try
                    {
                        casilla = Console.ReadLine();
                        if (!patron.IsMatch(casilla)) throw new Exception("Las casillas van de la A a la J y del 0 al 9");
                        for(int j=0; j<barcos.Count; j++)
                        {
                            if (barcos[j].Casilla == casilla) throw new Exception("Está casilla ya tiene un barco");
                        }
                        for(int j=0; j<totalBarcos.Count; j++)
                        {
                            if (totalBarcos[j].Casilla == casilla) throw new Exception("Casilla ocupada, introduzca otra");
                        }
                        correcto = true;
                        i++;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                while (correcto == false);
                Barco barco = new Barco(nombre, true, casilla);
                barcos.Add(barco);
            }
            totalBarcos = barcos; // SE LE ASIGNA LOS BARCOS DEL JUGADOR 1
            jugador.Barcos = barcos;
        }

        public static int disparo(Casilla casilla, Jugador jugador)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (tablero.Casillas[i, j].Nombre == casilla.Nombre)
                    {
                        tablero.Casillas[i, j].Sprite = " ";
                        for (int k = 0; k < jugador.Barcos.Count; k++)
                        {
                            if (jugador.Barcos[k].Casilla == casilla.Nombre &&
                                jugador.Barcos[k].Vivo == true)
                            {
                                jugador.Barcos[k].Vivo = false;
                                return 1;
                            }
                        } 
                    }                
                }
            }
            return 0;
        }

        public static int comprobarResultado(String nombre_casilla, Jugador jugador ,int vidas)
        {
            Casilla casilla = new Casilla(nombre_casilla, "*");
            int resultado_disparo = disparo(casilla, jugador);
            if (resultado_disparo == 1) { Console.WriteLine("HAS DADO A UN BARCO"); vidas--; }
            else Console.WriteLine("NO HAS DADO HA NINGÚN BARCO");
            return vidas;
        }

        public static string comprobarCasilla(Jugador jugador)
        {
            bool correcto = false;
            string nombre_casilla = "";
            Regex patron = new Regex("[A-J][0-9]");
            do
            {
                Console.WriteLine(jugador.Nombre + " selecciona una casilla:");
                try
                {
                    nombre_casilla = Console.ReadLine();
                    if (!patron.IsMatch(nombre_casilla)) throw new Exception("Las casillas van de la A a la J y del 0 al 9");
                    correcto = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (correcto == false);
            return nombre_casilla;
        }
    }
}