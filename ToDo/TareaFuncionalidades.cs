using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Formats.Tar;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo
{
    public class TareaFuncionalidades
    {

        // Metodos
        public List<Tarea> CrearTareasPendientes()
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

        public void MostrarTareas(List<Tarea> listaPendientes, List<Tarea> listaRealizas)
        {
            foreach (var tarea in listaPendientes)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Tareas pendientes");

                Console.WriteLine("TareaID: " + tarea.TareaID);

                Console.WriteLine("Descripcion: " + tarea.Descripcion);

                Console.WriteLine("Duracion: " + tarea.Duracion);
                Console.WriteLine("----------------------------------------------");

            }


            foreach (var tarea in listaRealizas)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("Tareas realizadas");

                Console.WriteLine("TareaID: " + tarea.TareaID);

                Console.WriteLine("Descripcion: " + tarea.Descripcion);

                Console.WriteLine("Duracion: " + tarea.Duracion);

                Console.WriteLine("----------------------------------------------");

            }



        }

        public void MoverTareasDePendientesARealizadas(List<Tarea> listaTareaPendiente, List<Tarea> listaTareaRealizada)
        {
            List<Tarea> tareasParaMover = new List<Tarea>();

            foreach (Tarea tareaPendiente in listaTareaPendiente)
            {
                Console.WriteLine($"ID: {tareaPendiente.TareaID}, Descripcion: {tareaPendiente.Descripcion}, Duracion: {tareaPendiente.Duracion}");
                Console.WriteLine("¿Esta tarea fue realizada? 1- SI 2- NO");

                int respuesta = int.Parse(Console.ReadLine());

                if (respuesta == 1)
                {
                    tareasParaMover.Add(tareaPendiente);
                }
            }


            listaTareaRealizada.AddRange(tareasParaMover);


            foreach (Tarea tarea in tareasParaMover)
            {
                listaTareaPendiente.Remove(tarea);
            }
        }

        public void BuscarTareaPendientePorDescripcion(List<Tarea> listaTareaPendientes)
        {
            Console.Write("Ingrese una palabra clave para buscar en las tareas pendientes: ");
            string palabraClave = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(palabraClave))
            {
                Console.WriteLine("No ingresó una palabra válida.");
                return;
            }

            var resultados = listaTareaPendientes
                .Where(t => t.Descripcion.Contains(palabraClave, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (resultados.Count == 0)
            {
                Console.WriteLine("No se encontraron tareas pendientes con esa descripción.");
            }
            else
            {
                Console.WriteLine($"\nSe encontraron {resultados.Count} tarea(s):\n");
                foreach (var tarea in resultados)
                {
                    Console.WriteLine($"ID: {tarea.TareaID} | Descripción: {tarea.Descripcion} | Duración: {tarea.Duracion} min");
                    Console.WriteLine("----------------------------------------------");
                }
            }
        }
    }
}