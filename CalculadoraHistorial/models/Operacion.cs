using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraHistorial.models
{
    public class Operacion
    {
        public double ResultadoAnterior; // almacena el resultado previo al calculo actual
        public double NuevoValor; // el valor con el que se opera sobre el resultado anterior
        public TipoOperacion OperacionTipo; // El tipo de operacion realizada

        public Operacion(double resultadoAnterior, double nuevoValor, TipoOperacion operacionTipo)
        {
            ResultadoAnterior = resultadoAnterior;
            NuevoValor = nuevoValor;
            OperacionTipo = operacionTipo;
        }
        public double Resultado
        {
            get
            {
                switch (OperacionTipo)
                {
                    case TipoOperacion.Suma:
                        return ResultadoAnterior + NuevoValor;

                    case TipoOperacion.Resta:
                        return ResultadoAnterior - NuevoValor;

                    case TipoOperacion.Multiplicacion:
                        return ResultadoAnterior * NuevoValor;

                    case TipoOperacion.Division:
                        return NuevoValor != 0 ? ResultadoAnterior / NuevoValor : throw new DivideByZeroException("No se puede dividir por cero.");

                    default:
                        throw new InvalidOperationException("Tipo de operación no válida.");
               }
            }
        }
    }
}