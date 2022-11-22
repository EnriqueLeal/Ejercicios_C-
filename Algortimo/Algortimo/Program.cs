using Algortimo.Clases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Algortimo
{
   public class ConteoArray
    {
        public static int Counter { get; set; }
    }
    class Program
    {
        public string sequence = "";
        public static bool Ejecutor { get; set; }

        public class Ejercicios
        {
            public int Id { get; set; }

            public string Nombre { get; set; }

            public int Estatus { get; set; }
        }

            static void Main(string[] args)
        {

            #region ~~~~~~Variables~~~~~~
            int V1 = 0;
            int arreglo = 0;
            Ejecutor = false;
            int N_pregunta =0;
            int[] a = { 1, 2, 3, 4 };
            int[] b = { 1, 2, 3, 4 };
            int[] array = { 1, 2, 3, 4 };
            #endregion

            #region ~~~~~~Clases a ejecutarse~~~~~~
            Conexion Prueba = new Conexion();
            Clases_1 Clases = new Clases_1();
            DemoAlgoritmo Ejecutar = new DemoAlgoritmo();
            #endregion

            #region ~~~~~~Colors~~~~~~
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = default;
            #endregion

            #region ~~~~~~ Codigo.. ~~~~~~
            //ARRAY ESTATICO SI NO SE SELECIONA LA CANTIDAD
            List<Ejercicios> E = new List<Ejercicios>();

            E.Add(new Ejercicios() { Id = 1, Nombre = "AppendToNew - copyArray", Estatus = 1});
            E.Add(new Ejercicios() { Id = 2, Nombre = "Array - Intersection", Estatus = 1 });

            Console.WriteLine("*********MENU DE APLICACIONES A EJECUTAR*********");
            foreach (var item in E)
                Console.WriteLine(" ~~~~~~~~~~~~~~~~~~~~~~~~~~ \n Nombre: {0} \n Aplicación: {1} \n Estatus: {2} \n ~~~~~~~~~~~~~~~~~~~~~~~~~~", item.Nombre, item.Id, item.Estatus);

            Console.WriteLine("Selecciona la aplicación a ejecutar: ");
            int Into = Convert.ToInt32(Console.ReadLine());

            switch(Into)
            {
                case 1:
                    
                    //P{0}
                    Console.WriteLine(Clases.Mensajes(N_pregunta++).ToString());

                    arreglo = Convert.ToInt32(Console.ReadLine());

                    if (arreglo > 0)
                    {
                        array = Ejecutar.EjecutaArray(arreglo);
                    }
                    var Resultado = Clases.copyArray(array);
                    Console.WriteLine(Clases.Mensajes(N_pregunta++).ToString());
                    V1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(Clases.Mensajes(N_pregunta++).ToString(), V1);
                    string _Search = Console.ReadLine();


                    Ejecutar.Ejecucion(Clases, N_pregunta, V1, array, _Search, Ejecutor);

                    Thread.Sleep(2000);
                    break;
                case 2:
                    //DEMO
                   

                    arreglo = Clases.Mensaje_arr(N_pregunta,arreglo);

                    if (arreglo > 0)
                    {
                        a = Ejecutar.EjecutaArray(arreglo);
                        b = Ejecutar.EjecutaArray(arreglo);
                    }
                  
                    Ejecutar.Intersection(a,b);
                    
                    break;
                   
                case 3:
                    Console.WriteLine("En mantenimiento");
                    //Ejecutar.Ejercicio3();
                    break;
                default:

                    break;
            }
            #endregion

            //Console.WriteLine("Cantidad total de cambios {0}", ConteoArray.counter);
            Console.ReadKey();

        }
 

    }

}
