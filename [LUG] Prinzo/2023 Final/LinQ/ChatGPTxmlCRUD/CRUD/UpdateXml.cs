using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChatGPTxmlCRUD.CRUD
{
    public static class UpdateXml
    {
        public static void Actualiza(string ubicacion)
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
    }
}
