using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChatGPTxmlCRUD.CRUD
{
    public static  class CreateXml
    {
        public static void Agrega(string ubicacion)
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
    }
}
