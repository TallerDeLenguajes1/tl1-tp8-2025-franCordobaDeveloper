using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraHistorial.models
{
    public class Calculadora
    {
        private double dato;
        public List<Operacion> Historial { get; }

        public Calculadora()
        {
            Historial = new List<Operacion>();
        }
        public double Resultado
        {
            get { return dato; }
        }

        public void Sumar(double termino)
        {
            Historial.Add(new Operacion(dato, termino, TipoOperacion.Suma));
            dato += termino;
        }

        public void Restar(double termino)
        {
            Historial.Add(new Operacion(dato, termino, TipoOperacion.Resta));
            dato -= termino;
        }

        public void Multiplicar(double termino)
        {
            Historial.Add(new Operacion(dato, termino, TipoOperacion.Multiplicacion));
            dato *= termino;
        }
        public void Dividir(double termino)
        {
            if (termino != 0)
            {
                Historial.Add(new Operacion(dato, termino, TipoOperacion.Division));
                dato /= termino;
            }

            Console.WriteLine("Error no se puede divir en 0");
        }

        public void Limpiar()
        {
            Historial.Add(new Operacion(dato, 0, TipoOperacion.Limpiar));
            dato = 0;
        }
    }
}