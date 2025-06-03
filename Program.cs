using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_3_P_2
{
    internal class Program
    {
       // Variables globales del programa
        static int cantidad_hora=0,cantidad_operarios = 0, cantidad_tecnicos = 0, cantidad_profesionales = 0, trabajador=0; 
        static float acumulado_operarios = 0, acumulado_tecnicos = 0, acumulado_profesionales = 0;
        static float promedio_operarios=0, promedio_tecnicos=0, promedio_profesionales = 0;
        static float valor_hora, salario_ordinario = 0,salario_neto=0, aumento = 0,salario_bruto = 0, deduccion=0;
        static string cedula, nombre;
        static void menu()              // menú a ejecutar
        {
            int opcion = 0; // variable local

            do      // menú  de consola principal
            {
                Console.WriteLine("1_Registrar datos");
                Console.WriteLine("2_Mostrar Estadísticas");
                Console.WriteLine("3_Salir");
                Console.WriteLine("Digite una opcion");
                int.TryParse(Console.ReadLine(), out opcion);// convierte la opción en un numero entero
                switch (opcion)
                {

                    case 1:
                        Solicitar();                                                      // función para solicitar datos a registar  al usuario
                        Console.Write("Digite: 1 Operario  2 Técnico  3 Profesional");    // Tipo de empleado
                        int trabajador = int.Parse(Console.ReadLine());
                        switch (trabajador) {                                             // Evaluó el tipo de empleado
                            case 1:                                                      // caso 1: Operario
                                Operario();                                                 // llamado a la función a realizar
                                Console.WriteLine($"Tipo de Empleado: Operario");           // Escribo el tipo de empleado en pantalla
                                cantidad_operarios += 1;                                       // Guardo cantidad de Operarios
                                acumulado_operarios = acumulado_operarios + salario_neto;       // Guardo el salario acumulado 
                                promedio_operarios = acumulado_operarios / cantidad_operarios;  // Guardo el promedio
                                     break;
                            case 2:                                                             // caso 2: Técnico
                                Tecnico();                                                      // llamado a la función a realizar
                                Console.WriteLine($"Tipo de Empleado: Tecnico");                // Escribo el tipo de empleado en pantalla
                                cantidad_tecnicos += 1;                                         // Guardo cantidad de Técnicos
                                acumulado_tecnicos = acumulado_tecnicos + salario_neto;         // Guardo salario acumulado
                                    promedio_tecnicos = acumulado_tecnicos/cantidad_tecnicos;   // Guardo el promedio
                                    break;
                            case 3:                                                                                 // Caso 3: Profesional
                                    Profesional();                                                                 // Llamado a la función
                                    Console.WriteLine($"Tipo de Empleado: Profesional");                        // Escribo en pantalla el tipo de empleado
                                    cantidad_profesionales += 1;                                                // Guardo la cantidad de profesionales
                                    acumulado_profesionales= acumulado_profesionales + salario_neto;            // Guardo el salario acumulado
                                    promedio_profesionales = acumulado_profesionales/cantidad_profesionales;   // Guardo el promedio salario
                                break;
                        }                       // Escribo los demás datos que deben aparecer en pantalla
                        Console.WriteLine($"Cédula: {cedula}");
                        Console.WriteLine($"Nombre Empleado: {nombre}");
                        Console.WriteLine($"Salario por Hora: {valor_hora}");
                        Console.WriteLine($"Cantidad de Horas: {cantidad_hora}");
                        Console.WriteLine($"Salario Ordinario: {salario_ordinario}");
                        Console.WriteLine($"Aumento: {aumento}");
                        Console.WriteLine($"Salario Bruto: {salario_bruto}");
                        Console.WriteLine($"Deducción CCSS: {deduccion}");
                        Console.WriteLine($"Salario Neto: {salario_neto}");
                        break;
                    case 2:
                        // Escribo en pantalla las estadísticas que se guardaron en el programa
                        Console.WriteLine($"Cantidad Empleados Tipo Operarios: {cantidad_operarios}");
                        Console.WriteLine($"Acumulado Salario Neto para Operarios: {acumulado_operarios}");
                        Console.WriteLine($"Promedio Salario Operarios: {promedio_operarios}");
                        Console.WriteLine($"Cantidad Empleados Tipo Técnicos: {cantidad_tecnicos}");
                        Console.WriteLine($"Acumulado Salario Neto para Técnicos: {acumulado_tecnicos}");
                        Console.WriteLine($"Promedio Salario Técnicos: {promedio_tecnicos}");
                        Console.WriteLine($"Cantidad Empleados Tipo Profesionales: {cantidad_profesionales}");
                        Console.WriteLine($"Acumulado Salario Neto para Profesionales: {acumulado_profesionales}");
                        Console.WriteLine($"Promedio Salario Profesionales: {promedio_profesionales}");
                        break;
                    case 3: break; // salgo del programa
                    default:
                        break;
                }

            } while (opcion!=3); // mantengo el menú mientras no se le dé la opción salir
            
        }
        static void Solicitar() //funcion para solicitar los datos al usuario del trabajador
        {
            Console.Write("Ingrese su cédula:");
            cedula = Console.ReadLine();
            Console.Write("Ingrese su nombre completo:");
            nombre = Console.ReadLine();
            Console.Write("Ingrese la cantidad de horas laboradas:");
            cantidad_hora = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el precio por hora laborada:");
            valor_hora = float.Parse(Console.ReadLine());
        }
        static void Operario() { 
            // función para calcular el salario operario
            salario_ordinario = cantidad_hora*valor_hora;
            aumento = salario_ordinario * 0.15f; // se le agrega una f para convertir el 0.15 a float sino me da error
            salario_bruto = salario_ordinario + aumento;
            deduccion = salario_bruto * 0.0917f; // se agrega la f para que el numero este en float
            salario_neto = salario_bruto-deduccion;
           
        }
        static void Tecnico() {
            //función para calcular el salario tecnico
            salario_ordinario = cantidad_hora * valor_hora;
            aumento = salario_ordinario * 0.1f; // se le agrega una f para convertir el 0.05 a float sino me da error
            salario_bruto = salario_ordinario + aumento;
            deduccion = salario_bruto * 0.0917f; // se agrega la f para que el numero este en float
            salario_neto = salario_bruto - deduccion;
        }
        static void Profesional() {
            //función para calcular el salario profesional
            salario_ordinario = cantidad_hora * valor_hora;
            aumento = salario_ordinario * 0.05f; // se le agrega una f para convertir el 0.05 a float sino me da error
            salario_bruto = salario_ordinario + aumento;
            deduccion = salario_bruto * 0.0917f; // se agrega la f para que el numero este en float
            salario_neto = salario_bruto - deduccion;
        }
        static void Main(string[] args)
        {
            menu();   // Ejecuto el menu
        }
    }
}
