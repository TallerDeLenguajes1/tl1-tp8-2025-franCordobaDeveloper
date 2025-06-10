using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo
{
    public class TareaFuncionalidades
    {


        List<Tarea> tareasPendientes = new List<Tarea>();

        List<Tarea> tareasRealizada = new List<Tarea>();


        // Metodos
        public static List<Tarea> CrearTareasPendientes(int N)
        {
            List<Tarea> pendientes = new List<Tarea>();

            Random random = new();

            for (int i = 0; i < 6; i++)
            {
                Tarea tarea = new()
                {
                    TareaID = i + 1,
                    Descripcion = GenerarDescripcion(),
                    Duracion = random.Next(10, 101)


                };
                pendientes.Add(tarea);
            }

            return pendientes;
        }

        private static string GenerarDescripcion()
        {
            string[] descripciones = ["Descripcion Tarea 1", "Descripcion Tarea 2", "Descripcion Tarea 3", "Descripcion Tarea 4", "Descripcion Tarea 5"];
            Random random = new();
            int index = random.Next(0, descripciones.Length);
            return descripciones[index];
        }

        public static void MostrarTareas(List<Tarea> listaDeTodasLasTareas)
        {
            foreach (var tarea in listaDeTodasLasTareas)
            {
                Console.WriteLine("Lista de todas las Tareas pendientes o realizadas");

                Console.Write("TareaID: " + tarea.TareaID);

                Console.Write("Descripcion: " + tarea.Descripcion);

                Console.Write("Duracion: " + tarea.Duracion);

            }
        }

        static void MoverTareasDePendientesARealizadas(List<Tarea> tareaPendiente, List<Tarea> tareaRealizada)
        {
            
        }

    }
    

}