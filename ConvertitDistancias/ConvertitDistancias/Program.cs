using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertitDistancias
{
    using System;
    using System.Globalization;

    namespace ConvertitDistancias
    {
        public class Kilometros
        {
            public double Distancia { get; set; }

            public Kilometros(double distancia)
            {
                Distancia = distancia;
            }

            public static implicit operator Millas(Kilometros km)
            {
                double millas = km.Distancia / 1.60934;
                double rounded = Math.Round(millas, 4);
                return new Millas(rounded);
            }

            public override string ToString()
            {
                return Distancia % 1 == 0 ? $"{Distancia:0} km" : $"{Distancia} km";
            }
        }

        public class Millas
        {
            public double Distancia { get; set; }

            public Millas(double distancia)
            {
                Distancia = distancia;
            }

            public static implicit operator Kilometros(Millas mi)
            {
                double kilometros = mi.Distancia * 1.60934;
                double rounded = Math.Round(kilometros, 4);
                return new Kilometros(rounded);
            }

            public override string ToString()
            {
                return Distancia % 1 == 0 ? $"{Distancia:0} mi" : $"{Distancia} mi";
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                bool continuar = true;

                while (continuar)
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("CONVERSOR DE DISTANCIAS");
                        Console.WriteLine("1. Kilómetros a Millas");
                        Console.WriteLine("2. Millas a Kilómetros");
                        Console.WriteLine("3. Salir");
                        Console.Write("Seleccione una opción: ");

                        string opcion = Console.ReadLine();

                        switch (opcion)
                        {
                            case "1":
                                ConvertirKilometrosAMillas();
                                break;
                            case "2":
                                ConvertirMillasAKilometros();
                                break;
                            case "3":
                                continuar = false;
                                break;
                            default:
                                Console.WriteLine("Opción no válida. Intente nuevamente.");
                                Console.ReadKey();
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        Console.WriteLine("El programa continuará funcionando...");
                        Console.ReadKey();
                    }
                }
            }

            static void ConvertirKilometrosAMillas()
            {
                try
                {
                    Console.Clear();
                    Console.Write("Ingrese distancia en kilómetros: ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                        throw new ArgumentException("Debe ingresar un valor");

                    if (!double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double kilometros))
                        throw new FormatException("Debe ingresar un número válido");

                    Kilometros km = new Kilometros(kilometros);
                    Millas mi = km;

                    Console.WriteLine($"\n{km} equivale a {mi}");
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nError en conversión: {ex.Message}");
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }

            static void ConvertirMillasAKilometros()
            {
                try
                {
                    Console.Clear();
                    Console.Write("Ingrese distancia en millas: ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                        throw new ArgumentException("Debe ingresar un valor");

                    if (!double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double millas))
                        throw new FormatException("Debe ingresar un número válido");

                    Millas mi = new Millas(millas);
                    Kilometros km = mi;

                    Console.WriteLine($"\n{mi} equivale a {km}");
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nError en conversión: {ex.Message}");
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}
