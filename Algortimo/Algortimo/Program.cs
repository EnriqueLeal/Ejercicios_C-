using Algortimo.Clases;
using Lucene.Net.Support;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static Algortimo.Clases.Clases_1;

namespace Algortimo
{
   public class ConteoArray
    {
        public static int Counter { get; set; }
        public static string _Resultado { get; set; }
    }
    class Program
    {
        public string sequence = "";
        private static string _Resultado;

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
            Random rnd = new Random();
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
            E.Add(new Ejercicios() { Id = 3, Nombre = "En mantenimiento", Estatus = 0 });
            E.Add(new Ejercicios() { Id = 4, Nombre = "<-- Contiene número Pares -->", Estatus = 1 });
            E.Add(new Ejercicios() { Id = 5, Nombre = "*** BUSCAMINAS ***", Estatus = 1 });

            Console.WriteLine("*********MENU DE APLICACIONES A EJECUTAR*********");
            foreach (var item in E)
                Console.WriteLine(" ~~~~~~~~~~~~~~~~~~~~~~~~~~ \n Nombre: {0} \n Aplicación: {1} \n Estatus: {2} \n ~~~~~~~~~~~~~~~~~~~~~~~~~~", item.Nombre, item.Id, item.Estatus);

            Console.WriteLine("Selecciona la aplicación a ejecutar: ");
            int Into = Convert.ToInt32(Console.ReadLine());

            switch(Into)
            {
                case 1:
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
                    Console.WriteLine(repeatedLogicalShift(1, 10));

                    //Ejecutar.Ejercicio3();
                    break;
                case 4:
                    Console.WriteLine("Introducir cantidad a buscar: ");
                    V1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(PrimeNaive(V1));
                    Console.WriteLine(PrimeSlightlyBetter(V1));
                    break;

                case 5:
                    Console.WriteLine("BUSCAMINAS");
                    string Caracter = "[]";
                    string Mina = "*";
                    Console.WriteLine(Caracter+ Caracter+ Caracter + "\n" + Caracter + Caracter + Caracter + "\n" + Caracter  + Caracter + Caracter);

                  
                    int Horizontal = rnd.Next(3);
                    int Vertical = rnd.Next(3);

                    var Buscaminas = new List<Clases_1.Buscaminas_Table>();

                    Buscaminas.Add(new Clases_1.Buscaminas_Table() 
                    {
                        Id = 1,
                        Horizontal = Horizontal,
                        Vertical = Vertical,
                        EsMina = 1,
                        Valor = Mina

                    });

                    foreach (object item in Buscaminas)
                    {


                        foreach (var fieldInfo in item.GetType().GetProperties())
                        {

                            var Key = fieldInfo.GetMethod.Name.Replace("get_", "");
                            var Value = fieldInfo.GetValue(item);


                            _Resultado += Value + "|";
                        }

                    }

                    string[] parts = _Resultado.Split('|');
                    int Numero = parts.GetLength(0);
                    int y = 0;
                    int R = Numero % 5;
                    int Id = 0;
                    int EsMina = 0;
                    int Valor = 0;
                    for (int i = 0; i < R; i++)
                    {
                        Id = Convert.ToInt32(parts[i * 5]);
                        Horizontal = Convert.ToInt32(parts[i + 1 * 5]);
                        Vertical = Convert.ToInt32(parts[i + 2 * 5]);
                        EsMina = Convert.ToInt32(parts[i + 3 * 5]);
                        Valor = Convert.ToInt32(parts[i + 4 * 5]);
                    }
                    foreach (string part in parts)
                    {
                        y++;
                    }

                        break;
                default:

                    break;
            }
            #endregion

            //Console.WriteLine("Cantidad total de cambios {0}", ConteoArray.counter);
            Console.ReadKey();

        }
        

            public static int repeatedLogicalShift(int x, int count)
        {
            for (int i = 0; i < count; i++)
            {
                x >>= 1; // Logical shift by 1
            }
            return x;

        }
        #region Ejercicio 4  - 
        public static bool PrimeNaive(int n)
        {

            if (n < 2)
                return false;

            for (int i = 2; i < n; i++)
                   if (n % i == 0)
                        return false;


        //----------------------------------//
                return true;
        }
        public static bool PrimeSlightlyBetter(int n)
        {
            if (n < 2)
                return false;

            int sqrt = (int)Math.Sqrt(n);

            for (int i = 2; i <= sqrt; i++)
                if (n % i == 0) 
                    return false;

            return true;
        }
            #endregion
    }
}
