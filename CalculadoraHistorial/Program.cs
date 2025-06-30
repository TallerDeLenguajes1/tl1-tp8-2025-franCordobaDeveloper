using CalculadoraHistorial.models;

class Program
{
    static void Main()
    {
        Calculadora calculadora = new();
        string opcion;

        do
        {
            Console.WriteLine($"\nResultado actual: {calculadora.Resultado}");
            Console.WriteLine("Elija operación: sumar, restar, multiplicar, dividir, limpiar, historial, salir");
            opcion = Console.ReadLine()?.ToLower();

            if (opcion == "salir") break;

            if (opcion == "limpiar")
            {
                calculadora.Limpiar();
                continue;
            }

            if (opcion == "historial")
            {
                Console.WriteLine("\n--- HISTORIAL ---");
                foreach (var op in calculadora.Historial)
                {
                    Console.WriteLine($"{op.OperacionTipo} | {op.ResultadoAnterior} y {op.NuevoValor} = {op.Resultado}");
                }
                continue;
            }

            Console.Write("Ingrese el número: ");
            if (!double.TryParse(Console.ReadLine(), out double numero))
            {
                Console.WriteLine("Número no válido.");
                continue;
            }

            switch (opcion)
            {
                case "sumar": calculadora.Sumar(numero); break;
                case "restar": calculadora.Restar(numero); break;
                case "multiplicar": calculadora.Multiplicar(numero); break;
                case "dividir": calculadora.Dividir(numero); break;
                default: Console.WriteLine("Operación no válida."); break;
            }

        } while (true);
    }
}
