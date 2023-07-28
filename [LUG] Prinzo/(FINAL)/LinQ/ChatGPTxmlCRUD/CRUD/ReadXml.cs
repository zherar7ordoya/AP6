using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChatGPTxmlCRUD.CRUD
{
    public static class ReadXml
    {
        public static void Muestra(string ubicacion)
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
    }
}
