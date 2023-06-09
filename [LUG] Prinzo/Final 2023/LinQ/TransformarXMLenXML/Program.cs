/************************************************************
Nombre del archivo: Program.cs
Descripción: https://youtu.be/Sv8oFcEj0kM
Autor: Gerardo Tordoya
Fecha: 2023-06-04
************************************************************/


using System.Linq;
using System.Xml.Linq;

namespace TransformarXMLenXML
{
    class Program
    {
        static void Main()
        {
            XDocument xmlOrigen = XDocument.Load("Data.xml");

            XDocument xmlDestino = new XDocument(
                new XElement("Students",
                    new XElement("USA",
                        from elemento in xmlOrigen.Descendants("Student")
                        where elemento.Attribute("Country").Value == "USA"
                        select new XElement("Student",
                            new XElement("Name", elemento.Element("Name").Value),
                            new XElement("Gender", elemento.Element("Gender").Value),
                            new XElement("TotalMarks", elemento.Element("TotalMarks").Value))),
                    new XElement("India",
                        from elemento in xmlOrigen.Descendants("Student")
                        where elemento.Attribute("Country").Value == "India"
                        select new XElement("Student",
                            new XElement("Name", elemento.Element("Name").Value),
                            new XElement("Gender", elemento.Element("Gender").Value),
                            new XElement("TotalMarks", elemento.Element("TotalMarks").Value)))));

            xmlDestino.Save("Result.xml");
        }
    }
}
