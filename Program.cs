using System.Numerics;
using System.Text;
using System.Xml;


namespace LR2 {
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.Unicode;

            // Создаем структуру данных.
            var Catalog = new Catalog() // Корневой элемент
            {
                Phones = new List<Phone>() // Коллекция номеров телефонов.
        {
 new Phone() {Model = "14", brend = "iphone", specs = "123", price = 800},
 new Phone() {Model = "13", brend = "idibil", specs = "423", price = 700},
 new Phone() {Model = "12", brend = "idroid", specs = "654645645", price = 200}
 }
            };

            WriteXmlFile("result.xml", Catalog);
            ReadXmlFile("result.xml");

           
            Console.ReadLine();
        }
        static void ReadXmlFile(string filename)
        {
            var doc = new XmlDocument();
            doc.Load(filename);
            var root = doc.DocumentElement;
            PrintItem(root);
        }

        static void PrintItem(XmlElement item, int indent = 0)
        {
            Console.Write($"{new string('\t', indent)}{item.LocalName} ");
            foreach (XmlAttribute attr in item.Attributes)
            {
                Console.Write($"[{attr.InnerText}]");
            }
            foreach (var child in item.ChildNodes)
            {
                if (child is XmlElement node)
                {

                    Console.WriteLine();
                    PrintItem(node, indent + 1);
                }
                if (child is XmlText text)
                {

                    Console.Write($"- {text.InnerText}");
                }
            }
        }
        static void WriteXmlFile(string filename, Catalog catalog)
        {

            var doc = new XmlDocument();
            var xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(xmlDeclaration);
            // Создаем Корневой элемент
            var root = doc.CreateElement("catalog");

            foreach (var phone in catalog.Phones)
            {
                // Создаем элемент записи телефонной книги.
                var phoneNode = doc.CreateElement("phone");
                AddChildNode("Model", phone.Model, phoneNode, doc);
                AddChildNode("Brend", phone.brend, phoneNode, doc);
                AddChildNode("SPEcs", phone.specs, phoneNode, doc);
                AddChildNode("Price", phone.price.ToString(), phoneNode, doc);

                root.AppendChild(phoneNode);
            }
            // Добавляем новый корневой элемент в документ.
            doc.AppendChild(root);
            // Сохраняем документ.
            doc.Save(filename);
        }

        static void AddChildNode(string childName, string childText, XmlElement parentNode,
        XmlDocument doc)
        {
            var child = doc.CreateElement(childName);
            child.InnerText = childText;
            parentNode.AppendChild(child);
        }
    }
}