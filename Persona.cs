public class Persona {

    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Dirección { get; set; }

    public void MostrarDatos() {
        Console.WriteLine("Nombre: {0}", Nombre);
        Console.WriteLine("Edad: {0}", Edad);
        Console.WriteLine("Dirección: {0}", Dirección);
    }

    public float CalcularIMC() {
        int peso = 75;
        int altura = 180;
        float imc = peso / (altura * altura);
	return imc;
    }

    public string[] ActualizarDatos() {
        // Obtiene los datos del usuario
        Console.WriteLine("Introduce tu nombre:");
        Nombre = Console.ReadLine();
        Console.WriteLine("Introduce tu edad:");
        Edad = int.Parse(Console.ReadLine());
        Console.WriteLine("Introduce tu dirección:");
        Dirección = Console.ReadLine();
	string[] info = {Nombre,Edad.ToString(),Direccion};
	return info;
    }
}
