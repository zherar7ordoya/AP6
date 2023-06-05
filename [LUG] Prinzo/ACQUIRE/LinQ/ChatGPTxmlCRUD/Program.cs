/**
 * Este programa utiliza LINQ para consultar, agregar, actualizar y eliminar
 * datos en el archivo XML. La función ShowData utiliza LINQ para obtener los
 * datos del archivo XML y mostrarlos en la consola. Las funciones AddData,
 * UpdateData y DeleteData también utilizan LINQ para realizar las operaciones
 * correspondientes en el archivo XML.
 */

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
                        Muestra(ubicacion);
                        break;
                    case "2":
                        Agrega(ubicacion);
                        break;
                    case "3":
                        Actualiza(ubicacion);
                        break;
                    case "4":
                        Borra(ubicacion);
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

        static void Muestra(string ubicacion)
        {
            XDocument archivo = XDocument.Load(ubicacion);

            Console.WriteLine("Datos:");

            var personas = from persona in archivo.Descendants("Persona")
                           select new
                           {
                               ID = persona.Attribute("id").Value,
                               Nombre = persona.Element("Nombre").Value,
                               Edad = persona.Element("Edad").Value
                           };
            
            foreach (var persona in personas)
            {
                Console.WriteLine("ID: " + persona.ID);
                Console.WriteLine("Nombre: " + persona.Nombre);
                Console.WriteLine("Edad: " + persona.Edad);
                Console.WriteLine("------------------------");
            }
        }

        static void Agrega(string ubicacion)
        {
            XDocument archivo = XDocument.Load(ubicacion);

            Console.WriteLine("Ingrese el ID:");
            string id = Console.ReadLine();

            Console.WriteLine("Ingrese el nombre:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese la edad:");
            string edad = Console.ReadLine();

            XElement elemento = new XElement("Persona",
                new XAttribute("id", id),
                new XElement("Nombre", nombre),
                new XElement("Edad", edad));

            archivo.Root.Add(elemento);
            archivo.Save(ubicacion);

            Console.WriteLine("Dato agregado exitosamente.");
        }

        static void Actualiza(string ubicacion)
        {
            XDocument archivo = XDocument.Load(ubicacion);

            Console.WriteLine("Ingrese el ID de la persona a actualizar:");
            string id = Console.ReadLine();

            XElement elemento = archivo.Root.Elements("Persona")
                .FirstOrDefault(e => e.Attribute("id").Value == id);

            if (elemento != null)
            {
                Console.WriteLine("Ingrese el nuevo nombre:");
                string nombre = Console.ReadLine();

                Console.WriteLine("Ingrese la nueva edad:");
                string edad = Console.ReadLine();

                elemento.Element("Nombre").Value = nombre;
                elemento.Element("Edad").Value = edad;

                archivo.Save(ubicacion);

                Console.WriteLine("Dato actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine("No se encontró la persona con el ID especificado.");
            }
        }

        static void Borra(string ubicacion)
        {
            XDocument archivo = XDocument.Load(ubicacion);

            Console.WriteLine("Ingrese el ID de la persona a eliminar:");
            string id = Console.ReadLine();

            XElement elemento = archivo.Root.Elements("Persona")
                .FirstOrDefault(e => e.Attribute("id").Value == id);

            if (elemento != null)
            {
                elemento.Remove();
                archivo.Save(ubicacion);

                Console.WriteLine("Dato eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("No se encontró la persona con el ID especificado.");
            }
        }
    }
}
