/**
 * Este programa utiliza LINQ para consultar, agregar, actualizar y eliminar
 * datos en el archivo XML. La función ShowData utiliza LINQ para obtener los
 * datos del archivo XML y mostrarlos en la consola. Las funciones AddData,
 * UpdateData y DeleteData también utilizan LINQ para realizar las operaciones
 * correspondientes en el archivo XML.
 */

using ChatGPTxmlCRUD.CRUD;

using System;
using System.Linq;
using System.Xml.Linq;

namespace ChatGPTxmlCRUD
{
    class Program
    {
        static void Main()
        {
            // Ruta del archivo XML
            string ubicacion = "Data.xml";

            // Crear un archivo XML vacío si no existe
            if (!System.IO.File.Exists(ubicacion))
            {
                XDocument xmlDoc = new XDocument(new XElement("Data"));
                xmlDoc.Save(ubicacion);
            }

            while (true)
            {
                Console.WriteLine("Bienvenido al CRUD de archivos XML");
                Console.WriteLine("1. Mostrar datos");
                Console.WriteLine("2. Agregar dato");
                Console.WriteLine("3. Actualizar dato");
                Console.WriteLine("4. Eliminar dato");
                Console.WriteLine("5. Salir");
                Console.WriteLine("Seleccione una opción:");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ReadXml.Muestra(ubicacion);
                        break;
                    case "2":
                        CreateXml.Agrega(ubicacion);
                        break;
                    case "3":
                        UpdateXml.Actualiza(ubicacion);
                        break;
                    case "4":
                        DeleteXml.Borra(ubicacion);
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
        }
    }
}
