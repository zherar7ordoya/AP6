using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChatGPTxmlCRUD.CRUD
{
    public static class DeleteXml
    {
        public static void Borra(string ubicacion)
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
