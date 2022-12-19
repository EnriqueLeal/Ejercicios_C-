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

        public class Buscaminas_Table
        {
            public int Id { get; set; }

            public int Vertical { get; set; }

            public int Horizontal { get; set; }

            public int EsMina { get; set; }

            public string Valor { get; set; }
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

        #region Ejercicio 5 - Buscaminas
        //BUSCADOR DE MINAS y AGREGA
        public string GetMinas(int H, int V, List<Clases_1.Buscaminas_Table> Buscaminas, string Mina, string _Resultado)
        {
            return _Resultado;
        }

        public void GetColocarMinas(string[,] arr2d, Random rnd, int _Valor, string Mina)
        {
            int Horizontal = rnd.Next(_Valor);
            int Vertical = rnd.Next(_Valor);
     
            arr2d[Horizontal, Vertical] = Mina;
            //arr2d[10,11] = Mina;
        }

        public string[,] GetGenerarTablero(int _Valor, string[,] arr2d, string Caracter)
        {
            for (int i = 0; i < _Valor; i++)
            {
                for (int y = 0; y < _Valor; y++)
                {
                    arr2d[i, y] = Caracter;
                }
            }
            return arr2d;
        }

        public void Buscaminas(int Horizontal, int Vertical,string[,] arr2d ,bool IncrementaXR, bool IncrementaXL, bool IncrementaYR, bool IncrementaYL, string Mina, int _Valor,int Limite,bool _Flag_Esquina, string Salto)
        {
            for (int i = 0; i <= Horizontal; i++)
            {

                if (i == Vertical && Horizontal == (Horizontal - 1 + 1))
                    Console.WriteLine("Resultado X - R: {0},{1} - HAY UNA MINA\n ", Horizontal, i);


                if (IncrementaXL && IncrementaYL)
                {
                    if (Horizontal + 1 < _Valor)
                        arr2d[Horizontal + 1, Vertical - 1] = TieneValor(arr2d, Convert.ToInt32(Horizontal + 1 ), Convert.ToInt32(Vertical - 1), _Valor);

                    if (Horizontal > 0)
                        arr2d[Horizontal - 1, Vertical - 1] = TieneValor( arr2d,Convert.ToInt32(Horizontal - 1), Convert.ToInt32(Vertical - 1), _Valor);

                }
                if (IncrementaXL)
                    arr2d[Horizontal - 1, Vertical] = TieneValor(arr2d, Convert.ToInt32(Horizontal - 1), Convert.ToInt32(Vertical), _Valor);

                if (IncrementaXR)
                {
                    if (Horizontal > 0)
                        arr2d[Horizontal - 1, Vertical] = TieneValor(arr2d, Convert.ToInt32(Horizontal - 1), Convert.ToInt32(Vertical), _Valor);

                    arr2d[Horizontal + 1, Vertical] = TieneValor(arr2d, Convert.ToInt32(Horizontal + 1), Convert.ToInt32(Vertical), _Valor);

                }
                if (IncrementaXR && IncrementaYR)
                {
                    arr2d[Horizontal + 1, Vertical + 1] = TieneValor(arr2d, Convert.ToInt32(Horizontal + 1), Convert.ToInt32(Vertical + 1), _Valor);

                    if (Horizontal >= 1)
                        arr2d[Horizontal - 1, Vertical + 1] = TieneValor(arr2d, Convert.ToInt32(Horizontal - 1), Convert.ToInt32(Vertical + 1), _Valor);

                    else
                    {
                        if (Vertical>=1)
                            arr2d[Horizontal + 1, Vertical - 1] = TieneValor(arr2d, Convert.ToInt32(Horizontal + 1), Convert.ToInt32(Vertical - 1), _Valor);

                        else
                            arr2d[Horizontal + 1, Vertical] = TieneValor(arr2d, Convert.ToInt32(Horizontal + 1), Convert.ToInt32(Vertical), _Valor);
                    }
                        
                }
                if (IncrementaXR && IncrementaYL)
                    arr2d[Horizontal + 1, Vertical - 1] = TieneValor(arr2d, Convert.ToInt32(Horizontal + 1), Convert.ToInt32(Vertical - 1), _Valor);

                if (IncrementaXL && IncrementaYR)
                    arr2d[Horizontal - 1, Vertical + 1] = TieneValor(arr2d, Convert.ToInt32(Horizontal- 1), Convert.ToInt32(Vertical + 1), _Valor);


                if (IncrementaYL)
                    arr2d[Horizontal, Vertical - 1] = TieneValor(arr2d, Convert.ToInt32(Horizontal), Convert.ToInt32(Vertical -1), _Valor);
    
                if (IncrementaYR)
                    arr2d[Horizontal, Vertical + 1] = TieneValor(arr2d, Convert.ToInt32(Horizontal), Convert.ToInt32(Vertical+ 1), _Valor);

            }


            if ((Horizontal + Vertical) % Limite == 0)
                _Flag_Esquina = true;

            int inc = 1;
            
        }
        #endregion

        public string TieneValor(string [,] arr2d,int H,int V,int Limite)
        {
            string Result = string.Empty;
            int countMinas = 0;
            bool LEFT_MenosMenos = false;
            bool LEFT_MenosMas = false;

            bool RIGHT_MenosMenos = false;
            bool RIGHT_MasMenos = false;
            bool RIGHT_MasMas = false;
            bool RIGHT_MenosMas = false;
            string CaracterMina = "*";
            bool ExisteUnaMina = false;

            try
            {
                if (arr2d[H,V].Contains(CaracterMina))
                {
                    ExisteUnaMina = true;
                }
                if (ExisteUnaMina == false)
                {
                    //Posicion Izquierda superior
                    if (H > 0 && V > 0 && H < Limite && V < Limite)
                    {
                        if ((H - 1) >= 0 && (V - 1) >= 0)
                        {
                            if (arr2d[H - 1, V - 1].Contains(CaracterMina))
                            {
                                countMinas++;
                                LEFT_MenosMenos = true;
                            }

                        }
                    }


                    if (H > 0 && V < Limite && H < Limite)
                    {
                        if ((H - 1) >= 0 && (V + 1) < Limite)
                        {
                            if (arr2d[H - 1, V + 1].Contains(CaracterMina))
                            {
                                countMinas++;
                                LEFT_MenosMas = true;
                            }

                        }
                    }

                    //Posicion izquierda inferior
                    if (H > 0 && H < Limite)
                    {

                            if (arr2d[H - 1, V].Contains(CaracterMina))
                            {
                                countMinas++;
                            }
                    }


                    //Posicion Derecha superior
                    if (H < Limite && V > 0 && V < Limite)
                    {
                        if ((H + 1) < Limite && (V - 1) >= 0)
                        {
                            if (arr2d[H + 1, V - 1].Contains(CaracterMina))
                            {
                                countMinas++;
                                RIGHT_MasMenos = true;
                            }

                        }
                    }

                    //Posicion Derecha Inferior
                    if (H < Limite && V < Limite)
                    {
                        if ((H + 1) < Limite && (V + 1) < Limite)
                        {
                            if (arr2d[H + 1, V + 1].Contains(CaracterMina))
                            {
                                countMinas++;
                                RIGHT_MasMas = true;
                            }

                        }
                    }

                    if (H < Limite - 1)
                    {
                            if (arr2d[H + 1, V].Contains(CaracterMina))
                            {
                                countMinas++;
                            }
                    }


                    if (V > 0 && V < Limite)
                    {
                        if (arr2d[H, V - 1].Contains(CaracterMina))
                        {
                            countMinas++;
                        }

                    }

                    if (V < Limite - 1)
                    {
                        if (arr2d[H, V + 1].Contains(CaracterMina))
                        {
                            countMinas++;
                        }
                    }

                    if (H < Limite - 1 && V < Limite - 1 || H > 0 && V < Limite  - 1 || H < Limite  - 1&& V > 0)
                    {

                    }
                    else
                    {
                            if (arr2d[H + 1, V + 1].Contains(CaracterMina))
                            {
                                countMinas++;
                            }
                    }
                }
                else
                    Result = "*";




                //if (countMinas == 0)
                //{
                //    countMinas++;
                //}
                Result = (Convert.ToInt32(countMinas)).ToString();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Encontro un bug: {0}",ex);
            }
            finally
            {
                
            }
            return "[" + Result + "]";
        }


    }
}
