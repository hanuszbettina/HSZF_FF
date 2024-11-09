using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace Feleves_Feladat
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }

        }

        //alap menü
        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Válassz egy menüpontot:");
            Console.WriteLine("1) AdatImportXML");
            Console.WriteLine("2) AdatImportJSON");
            Console.WriteLine("3) AdatExport");
            Console.WriteLine("4) CRUD");
            Console.WriteLine("5) Grafikon");
            Console.WriteLine("6) Lekérdezések");
            Console.WriteLine("7) Kilépés");
            Console.Write("\r\nVálasztott menüpont: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AdatImportXML();
                    return true;
                case "2":
                    AdatImportJSON();
                    return true;
                case "3":
                    AdatExport();
                    return true;
                case "4":
                    CRUD();
                    return true;
                case "5":
                    Grafikon();
                    return true;
                case "6":
                    Lekérdezések();
                    return true;
                case "7":
                    return false;
                default:
                    return true;
            }
        }

        private static void AdatImportXML()
        {
            Console.WriteLine("Adatimport XML");
        }
        private static void AdatImportJSON()
        {
            Console.WriteLine("Adatimport JSON");
        }
        private static void AdatExport()
        {
            Console.WriteLine("Adatexport");
        }
        private static void CRUD()
        {
            Console.WriteLine("CRUD");
        }
        private static void Grafikon()
        {
            Console.WriteLine("Grafikon");
        }
        private static void Lekérdezések()
        {
            Console.WriteLine("Válassz egy lekérdezést:");

        }
    }
}

