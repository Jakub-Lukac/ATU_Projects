using System;
namespace June2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
           /* Property p = new Property("D06K3C2", 1500, 3);
            Console.WriteLine(p.ToString());
            CommercialProperty c = new CommercialProperty("D06K3C2", 1500, 3, "A");
            Console.WriteLine(c.ToString());*/

            List<Property> properties = new List<Property>();
            properties.Add(new Property("D06K32", 1500, 3));
            properties.Add(new Property("D06K67", 2500, 2));
            properties.Add(new Property("D06K88", 800, 1));
            properties.Add(new CommercialProperty("D06K55", 4000, 0, "A"));


            Table.InitTable();
            foreach (Property p in properties)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}
