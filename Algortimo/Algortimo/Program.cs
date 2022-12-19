using Algortimo.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Algortimo
{
    public class ConteoArray
    {
        public static int Counter { get; set; }
        public static string _Resultado { get; set; }
        public static int _Valor { get; set; }
        
    }
    class Program
    {
        public string sequence = "";
        private static string _Resultado;

        public static bool Ejecutor { get; set; }

        public static Random rnd = new Random();
        public static string _TodosBuscados { get; set; }

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
            int N_pregunta = 0;
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

            E.Add(new Ejercicios() { Id = 1, Nombre = "AppendToNew - copyArray", Estatus = 1 });
            E.Add(new Ejercicios() { Id = 2, Nombre = "Array - Intersection", Estatus = 1 });
            E.Add(new Ejercicios() { Id = 3, Nombre = "En mantenimiento", Estatus = 0 });
            E.Add(new Ejercicios() { Id = 4, Nombre = "<-- Contiene número Pares -->", Estatus = 1 });
            E.Add(new Ejercicios() { Id = 5, Nombre = "*** BUSCAMINAS ***", Estatus = 1 });

            Console.WriteLine("*********MENU DE APLICACIONES A EJECUTAR*********");
            foreach (var item in E)
                Console.WriteLine(" ~~~~~~~~~~~~~~~~~~~~~~~~~~ \n Nombre: {0} \n Aplicación: {1} \n Estatus: {2} \n ~~~~~~~~~~~~~~~~~~~~~~~~~~", item.Nombre, item.Id, item.Estatus);

            Console.WriteLine("Selecciona la aplicación a ejecutar: ");
            int Into = Convert.ToInt32(Console.ReadLine());

            switch (Into)
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
                    arreglo = Clases.Mensaje_arr(N_pregunta, arreglo);

                    if (arreglo > 0)
                    {
                        a = Ejecutar.EjecutaArray(arreglo);
                        b = Ejecutar.EjecutaArray(arreglo);
                    }

                    Ejecutar.Intersection(a, b);

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
                    Console.WriteLine("Cantidad de veces a ejecutarse");
                    int Cantidad = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < Cantidad; i++)
                    {
                        EjecutaBuscaminas();
                    }


                    break;
                default:

                    break;
            }
            #endregion


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

        #region Ejercicio 5 - Buscaminas
        public static void EjecutaBuscaminas()
        {
            #region ~~~~~~Clases a ejecutarse~~~~~~
            Conexion Prueba = new Conexion();
            Clases_1 Clases = new Clases_1();
            DemoAlgoritmo Ejecutar = new DemoAlgoritmo();
            #endregion

            #region Variables
            Console.WriteLine("BUSCAMINAS");
            string Caracter = "[ ]";
            string Mina = "[*]";
            const int _Valor = 6;
            int Cantidad_minas = 1;
            int Limite = 3;
            bool _Flag_Esquina = false;
            string Salto = "";
            #endregion


            int Horizontal = rnd.Next(_Valor);
            int Vertical = rnd.Next(_Valor);

            var Buscaminas = new List<Clases_1.Buscaminas_Table>();

            _Resultado = Ejecutar.GetMinas(Horizontal, Vertical, Buscaminas, Mina, _Resultado);
            string[,] arr2d = new string[_Valor, _Valor];

            arr2d = Ejecutar.GetGenerarTablero(_Valor, arr2d, Caracter);
            //

            //MUESTRA MENSAJE DONDE ESTA POSICIONADA LA MINA
            Console.WriteLine("¿Cantidad de minas?");
            Cantidad_minas = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= Cantidad_minas; i++)
            {
                Ejecutar.GetColocarMinas(arr2d, rnd, _Valor, Mina);
            }

        //Inicio:
            for (int m = 0; m <= _Valor - 1; m++)
            {
                for (int x = 0; x <= _Valor - 1; x++)
                {
                    if (arr2d[m, x] == "[*]")
                    {
                        //Thread.Sleep(2000);
                        #region Algoritmo
                        //--------------ALGORITMO------------------//
                        bool IncrementaXR = false;
                        bool IncrementaXL = false;

                        bool IncrementaYR = false;
                        bool IncrementaYL = false;

                        if (m + 1 <= _Valor - 1)
                            IncrementaXR = true;
                        if (m - 1 >= 0)
                            IncrementaXL = true;

                        if (x + 1 <= _Valor - 1)
                            IncrementaYR = true;
                        if (x - 1 >= 0)
                            IncrementaYL = true;

                        if (IncrementaXR == true)
                            Console.WriteLine("X Incrementa Right: {0}", m + 1);
                        if (IncrementaXL == true)
                            Console.WriteLine("X Incrementa Left: {0}", m - 1);
                        if (IncrementaYR == true)
                            Console.WriteLine("Y Incrementa Vertical Right: {0}", x + 1);
                        if (IncrementaYL == true)
                            Console.WriteLine("Y Incrementa Vertical Left: {0}", x - 1);


                        Ejecutar.Buscaminas(m, x, arr2d, IncrementaXR, IncrementaXL, IncrementaYR, IncrementaYL, Mina, _Valor, Limite, _Flag_Esquina, Salto);


                        int inc = 1;
                        foreach (string item in arr2d)
                        {
                            if (inc % _Valor == 0)
                                Salto = "\n";
                            else
                                Salto = "";

                            Console.Write("[?]" + Salto);
                            inc++;
                        }


                        #endregion
                    }
                }
            }

        Sigue:
            Console.WriteLine("Introduzca valor a buscar Ejemplo (0,0)");
            string ResultadoBusqueda = Console.ReadLine();

            try
            {
                if (Convert.ToInt32(ResultadoBusqueda.Split(',')[0]) >= _Valor || Convert.ToInt32(ResultadoBusqueda.Split(',')[1]) >= _Valor)
                {
                    Console.WriteLine("\nIntroduzca rango: 0,0 - {0},{1}", _Valor - 1, _Valor - 1);
                    goto Sigue;
                }

            }
            catch (Exception)
            {
                if (!ResultadoBusqueda.Contains(","))
                {
                    goto Sigue;
                }
                goto Sigue;
                throw;
            }


            _TodosBuscados += ResultadoBusqueda + "|";
            bool Bandera_win = false;

            if (arr2d[Convert.ToInt32(ResultadoBusqueda.Split(',')[0]), Convert.ToInt32(ResultadoBusqueda.Split(',')[1])] == "[*]")
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Fin del juego");
            }
            else
            {
                string[] parts = _TodosBuscados.Split('|');
                int Numero = parts.GetLength(0);
                Array.Sort(parts);
                int inc = 1;
                string[,] arr2d_Feik = new string[_Valor, _Valor];

                DesencadenadorFor(_Valor, parts, arr2d_Feik, arr2d);
                

                Console.Clear();

                foreach (string item in arr2d_Feik)
                {

                    if (inc % _Valor == 0)
                        Salto = "\n";
                    else
                        Salto = "";

                    Console.Write(item + Salto);
                    inc++;
                }


                int Contador = 0;
                foreach (string item in arr2d_Feik)
                    if (item == "[?]")
                        Contador++;

                if (Contador == 1)
                    Bandera_win = true;



                if (Bandera_win)
                    goto Winner;
                else
                    goto Sigue;
            }
        Winner:
            if (Bandera_win)
            {
                Console.WriteLine("FELICIDADES HAS GANADO EL MINI JUEGO:");
                Console.ReadKey();
            }


            #region *-Basura-*
            //for (int i = 0; i <= Horizontal - 1; i++)
            //{
            //    if (i == Vertical && Horizontal - 1 == (Horizontal - 2 + 1))
            //    {
            //        Console.WriteLine("Resultado X - R: {0},{1} - HAY UNA MINA\n ", Horizontal -1 , i);
            //        arr2d[Horizontal - 1, i] = Mina;
            //    }
            //    else
            //        arr2d[Horizontal - 1, i] = "[1]";


            //    if (Horizontal == i && IncrementaXL == true)
            //    {
            //        Console.WriteLine("Es el final");
            //    }
            //}





            //foreach (string item in arr2d)
            //    Console.WriteLine(arr2d[1, 2]);
            //Console.WriteLine("\n");

            //Console.WriteLine(Caracter + Caracter + Caracter + "\n" + Caracter + Caracter + Caracter + "\n" + Caracter + Caracter + Caracter);
            //for (int i = 0; i < _Valor; i++)
            //{
            //    for (int j = 0; j < _Valor; j++)
            //    {
            //        if (j == _Valor - 1)
            //            Salto = "\n";
            //        else
            //            Salto = "";

            //       // Console.Write(arr2d[i, j] + " " + Salto);
            //    }
            //        //if (_Flag_Esquina)
            //        //{
            //        //  Console.WriteLine(Mina + Caracter + Mina);
            //        //}
            //        //else
            //        //Console.WriteLine(Caracter + Mina + Caracter);
            //}
            //Console.WriteLine("Cantidad total de cambios {0}", ConteoArray.counter);
            #endregion
        }
        public static bool Get_SimilitudValor(int H, int V, string [] parts)
        {

            string Combine = ""+H+","+V+"";
            foreach (string part in parts)
            {
                if (Combine == part)
                {
                    return true;
                }
               
            }
            return false;
        }

        private static void DesencadenadorFor(int _Valor, string[] parts, string[,] arr2d_Feik, string[,] arr2d)
        {
            for (int i = 0; i < _Valor; i++)
            {
                for (int y = 0; y < _Valor; y++)
                {
                    bool Bandera = Get_SimilitudValor(i, y, parts);
                    if (Bandera)
                    {
                        arr2d_Feik[i, y] = arr2d[i, y];
                    }
                    else
                        arr2d_Feik[i, y] = "[?]";

                }
            }
        }
        #endregion
    }
}
