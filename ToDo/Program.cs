using ToDo;
using ToDo.Models;

class Program
{

    static void Main()
    {
        var gestorDeTareas = new TareaFuncionalidades(); // Instancia de la clase

        List<Tarea> tareasPendientes = gestorDeTareas.CrearTareasPendientes();
        List<Tarea> tareasRealizadas = new List<Tarea>();

        int opc;
        string numString;
        bool continuar = true;


        while (continuar)
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("Ingrese 1 para  Cargar las Tareas");

                Console.WriteLine("Ingrese 2 para  Listar Todas las Tareas");

                Console.WriteLine("Ingrese 3 para Mover tareas pendientes a lista de tareas realizadas.");

                Console.WriteLine("Ingrese 4 para Buscar tareas pendientes por descripcion.");

                Console.WriteLine("Ingrese 0 Para salir de la app de consola");



                numString = Console.ReadLine();

            } while (!int.TryParse(numString, out opc) || opc < 0 || opc > 5);

            if (opc == 0)
            {
                Console.WriteLine("Selecciono 0 esta saliendo de la app de consola.");
                continuar = false;
            }

            switch (opc)
            {
                case 1:
                    tareasPendientes = gestorDeTareas.CrearTareasPendientes();
                    break;

                case 2:
                    gestorDeTareas.MostrarTareas(tareasPendientes, tareasRealizadas);
                    break;
                case 3:
                    gestorDeTareas.MoverTareasDePendientesARealizadas(tareasPendientes, tareasRealizadas);
                    break;

                case 4:
                    gestorDeTareas.BuscarTareaPendientePorDescripcion(tareasPendientes);
                    break;


                default:
                    return;
            }

            Console.WriteLine("Desea Realizar otra Operacion? - Presione 0 para salir o 1 para relizar otra operacion");
            numString = Console.ReadLine();
            continuar = int.TryParse(numString, out opc);
            if (opc == 0)
            {
                continuar = false;
            }
            Console.Clear();
        }

    }

}