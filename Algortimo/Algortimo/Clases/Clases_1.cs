using Lucene.Net.Support;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Algortimo.Clases
{
    #region Clases a ejectuar Ej:1
    public class Clases_1
    {
        public int[] copyArray(int[] array)
        {
            int[] copy = new int[0];
            foreach (int value in array)
            {
                copy = array.ToArray();
            }
            return copy;
        }

        public int[] AppendToNew(int[] array, int value)
        {
            // copy all elements over to new array
            int[] bigger = new int[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                bigger[i] = array[i];
            }
            bigger[bigger.Length - 1] = value;
            return bigger;
        }

        public string Mensajes(int Pregunta)
        {
            switch (Pregunta)
            {
                case 0:
                    {
                        return "Crear array elige cantidad total: ";
                    }
                case 1:
                    {
                        return "Número a buscar: ";
                    }
                case 2:
                    {
                        return "Deseas buscar este número {0} Y/N ";
                    }
                case 3:
                    {
                        return "Número {0} se va cambiar número ingresado: ";
                    }

                default:
                    break;
            }
            return "";
        }

        public int Mensaje_arr(int Pregunta, int Cantidad)
        {
            Console.WriteLine(Mensajes(Pregunta).ToString());
            int arreglo = Convert.ToInt32(Console.ReadLine());

            return arreglo;
        }
    }
    public class Conexion
    {
        public string Conecta()
        {

            return "Siempre en conexion";
        }
    }


    public class DemoAlgoritmo
    {
        public void Ejecucion(Clases_1 Prueba2, int N_pregunta, int V1, int[] array, string _Search, bool Ejecutor)
        {
            if (_Search.ToUpper() == "Y")
            {
                Console.WriteLine(Prueba2.Mensajes(N_pregunta++).ToString(), V1);
                int _V2 = Convert.ToInt32(Console.ReadLine());
                var res = array.Where(dato => dato.Equals(V1));
                int[] array2 = Prueba2.copyArray(array);

                for (int i = 0; i <= array.Length - 1; i++)
                {
                    if (array[i] == V1)
                    {
                        ConteoArray.Counter++;
                        array.SetValue(_V2, i);
                        Ejecutor = true;

                    }
                }
                if (Ejecutor == true)
                {
                    foreach (int item in array)
                    {

                        if (item == _V2)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Número: {0} - Conteo: {1}", item, ConteoArray.Counter);
                        }
                        else
                        {
                            //Console.BackgroundColor = ConsoleColor.Red;
                            //Console.ForegroundColor = ConsoleColor.Black;
                            //Console.WriteLine("Número: {0}", item);
                        }


                    }
                }
            }
            else
                Console.WriteLine("Tenkiu!!");

        }

        public int[] EjecutaArray(int Top)
        {
            int[] _Res;
            _Res = new int[Top];
            Random rnd = new Random();

            for (int i = 0; i < Top; i++)
            {
                _Res[i] = rnd.Next(Top);
            }

            return _Res;
        }
        #endregion

        #region Ejercicio 2 - Obtener identico array
        public int Intersection(int[] a, int[] b)
        {
            int n = b.Length;
            Array.Sort(b);
            int intersect = 0;

            foreach (object x in a)
               FindMyObject(b, x);

            return intersect;
        }

        public static void FindMyObject(Array myArr, object myObject)
        {
            int myIndex = Array.BinarySearch(myArr, myObject);
            if (myIndex < 0)
                Console.WriteLine("The object to search for ({0}) is not found. The next larger object is at index {1}.", myObject, ~myIndex);
            else
            {
                //MOSTRAMOS RESULTADO BUSCADO Y EL NÚMERO INDEX EN LA POSICIÓN
                Console.WriteLine("The object to search for ({0}) is at index {1}.", myObject, myIndex);
                //GUARDAMOS RESULTADOS PARA VER CASO ESPERADO
                string Resultado = "The object to search for (" + myObject + ") is at index "+ myIndex + "";
                //MOSTRAMOS EL LOG PARA TENER NUESTRO REGISTROS Y PODER ANALIZAR INFORMACIÓN
                _EscribeTXT(Resultado);
                //SE EJECUTA ACTIVIDAD 3 PARA REALIZAR FLUJOS ALTERNOS EN LISTADOS Y TOPS
                Ejercicio3(myObject);
            }
        }
        #endregion

        #region Ejercicio 3 - 

        public static void Ejercicio3(object Valor)
        {
            bool Bandera_new = false;
            HashMap<string, int> tops = new HashMap<string, int>();
            try
            {
                if (tops.Count() < 1)
                    Bandera_new = true;

                if (Bandera_new == true)
                    tops.Add((string)Valor.ToString(), 1);
                else
                {
                    foreach (KeyValuePair<string, int> pair in tops)
                    {
                        if (tops.Equals(Valor.ToString()))
                        {
                            Console.WriteLine("Se encuentra este resultado");
                        }
                        Console.WriteLine("KEY: " + pair.Key);
                        Console.WriteLine("VALUE: " + pair.Value);
                    }
                }
               
                
            }
            catch(Exception ex)
            {

            }
           

          


        }
        #endregion

        #region Ejercicio 4 -

        public static void Ejercicio_4_arrayDetalle(Array array)
        {

        }
            #endregion

            #region Escribir en txt
            protected static void _EscribeTXT(string res)
        {
            string line;

            string path = "C:\\Users\\Usuario\\source\\repos\\Algortimo\\Algortimo\\bin\\Debug\\netcoreapp3.1\\Sample.txt";
            StreamWriter stream = null;
            try
            {
                stream = File.AppendText(path);
                stream.WriteLine(string.Format("{0} - {1}.", DateTime.Now, res));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                
                if (stream != null)
                    stream.Close();
            }


        }
        
        #endregion


    }
}
