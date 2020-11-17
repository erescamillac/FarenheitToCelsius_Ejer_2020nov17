using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FuncionesCase
{
    /*
     * Funciones - case
     */

    // Menú
    /*
     1. Celsius a Farenheit
     2. Farenheit a Celsius
     3. Salir
     */

    // Celsius to Farenheit


    // Farenheit to Celsius
    public class InputReader {
        public InputReader() {
        }

        // ReadOption [0 a 255]
        public byte ReadOption(string inputMsg, string errorMsg) {
            byte opt = 0;
            string strFromKeyboard;
            bool conversExitosa, error = false;

            do {
                if (error) {
                    Console.Error.WriteLine(errorMsg);
                }
                Console.WriteLine(inputMsg);
                strFromKeyboard = Console.ReadLine();
                conversExitosa = Byte.TryParse(strFromKeyboard, out opt);
                if (!conversExitosa)
                {
                    error = true;
                }
                else {
                    error = false;
                }
            } while (error);

            return opt;
        } //-- ReadOption()

        public double ReadTemperature(string inputMsg, string errorMsg) {
            double temperature = 0.0;
            bool conversionExitosa, error = false;
            string strFromKeyboard;
            do {
                if (error) {
                    Console.Error.WriteLine(errorMsg);
                }
                Console.WriteLine(inputMsg);
                strFromKeyboard = Console.ReadLine();
                conversionExitosa = Double.TryParse(strFromKeyboard, out temperature);
                if (!conversionExitosa)
                {
                    error = true;
                }
                else {
                    error = false;
                }
            } while (error);
            return temperature;
        }//-- ReadTemperature
    } //-- class InputReader

    class Program
    {
        // Celsius to Farenheit
        static double CelsiusToFarenheit(double celsiusTemperature) {
            double farenheitEquiv = 0.0;
            farenheitEquiv = (celsiusTemperature * (9.0/5.0)) + 32.0;
            return farenheitEquiv;
        }

        // Farenheit to Celsius
        static double FarenheitToCelsius(double farenheitTemperature) {
            double celsiusEquiv = 0.0;
            celsiusEquiv = (farenheitTemperature - 32.0) * (5.0/9.0);
            return celsiusEquiv;
        }
        static void Main(string[] args)
        {
            InputReader iReader = new InputReader();
            double celsiusT, farenheitT;
            byte option = 0;
            do {
                Console.Clear();

                Console.WriteLine("##--Menú--##");
                Console.WriteLine("1. Conversión de °C a °F");
                Console.WriteLine("2. Conversión de °F a °C");
                Console.WriteLine("3. SALIR");

                option = iReader.ReadOption("\tSeleccione una opción: ", "ENTRADA INVÁLIDA, debe ingresar un ENTERO entre 0 y 255.");

                switch(option){
                    case 1:
                        Console.Clear();
                        Console.WriteLine("1. Conversión de °C a °F.");
                        celsiusT = iReader.ReadTemperature("Ingrese la temperatura en Grados Celsius (°C): ", $"ENTRADA INVÁLIDA, debe ingresar un número decimal entre {Double.MinValue} y {Double.MaxValue}");
                        farenheitT = CelsiusToFarenheit(celsiusT);
                        Console.WriteLine("{0}°C EQUIVALEN a {1}°F", celsiusT, farenheitT);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("2. Conversión de °F a °C.");
                        farenheitT = iReader.ReadTemperature("Ingrese la temperatura en Grados Farenheit (°F): ", $"ENTRADA INVÁLIDA, debe ingresar un número decimal entre {Double.MinValue} y {Double.MaxValue}");
                        celsiusT = FarenheitToCelsius(farenheitT);
                        Console.WriteLine("{0}°F EQUIVALEN a {1}°C", farenheitT, celsiusT);
                        break;
                    case 3:
                        Console.WriteLine("\tHasta la próxima, vuelva pronto. Gracias por utilizar SuperHeatConverter v1.0");
                        break;
                    default:
                        Console.WriteLine("Opción NO VÁLIDA, seleccione 1, 2 o 3.");
                        Thread.Sleep(1200);
                        break;
                }

                if (option != 3) {
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
                
            } while (option != 3);
            Thread.Sleep(1600);
        }
    }
}
