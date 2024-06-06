using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;

namespace Simulacion_6_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Entrada de datos
            Console.Write("Ingrese la media: ");
            double media = Convert.ToDouble(Console.ReadLine());
            Console.Write("Ingrese el valor superior del intervalo para el 99% de los individuos: ");
            double VSuperior = Convert.ToDouble(Console.ReadLine());
            Console.Write("Ingrese el valor inferior del intervalo para el 99% de los individuos: ");
            double VInferior = Convert.ToDouble(Console.ReadLine());


            double DEstandar = (VSuperior - media) / 2.575;
            double K = 1.036;
            double limiteInferiorIntervalo = media - DEstandar * K;
            double limiteSuperiorIntervalo = media + DEstandar * K;

            //a
            double porcentajeSuperior135 = 1 - Normal.CDF(media, DEstandar, VSuperior);
            //b
            double porcentajeInferior95 = Normal.CDF(media, DEstandar, 95);
            //c
            double porcentajeEntre90y125 = Normal.CDF(media, DEstandar, 125) - Normal.CDF(media, DEstandar, 90);
            //d
            double porcentajeEntre85y100 = Normal.CDF(media, DEstandar, 100) - Normal.CDF(media, DEstandar, 85);


            Console.WriteLine("\nDesviación estándar: " + DEstandar);
            Console.WriteLine("\nIntervalo que contiene al 70% de los valores: [" + limiteInferiorIntervalo + ", " + limiteSuperiorIntervalo + "]\n");
            Console.WriteLine("a) Porcentaje de población con concentración superior a 135: " + porcentajeSuperior135 * 100 + "%");
            Console.WriteLine("b) Porcentaje de población con concentración inferior a 95: " + porcentajeInferior95 * 100 + "%");
            Console.WriteLine("c) Porcentaje de población con concentración entre 90 y 125: " + porcentajeEntre90y125 * 100 + "%");
            Console.WriteLine("d) Porcentaje de población con concentración entre 85 y 100: " + porcentajeEntre85y100 * 100 + "%");
        }
    }
}
