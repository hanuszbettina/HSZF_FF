using Feleves_Feladat.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics.Metrics;
using System.Net;
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
        //lekérdekérdezés almenü
        private static bool LekerdezesekAlmenu()
        {
            Console.Clear();
            Console.WriteLine("Vezető lekérdezések");
            Console.WriteLine("1) Hány doktori címmel rendelkező vezető(manager) van?");
            Console.WriteLine("2) Van - e olyan(és ha igen ki / kik) akik doktori címmel rendelkeznek, de MBA(Master of Business Administration) végzettségük nincs?");
            Console.WriteLine("3) Ki a legrégebb óta munkában lévő vezető?");
            Console.WriteLine("4) Melyik az a vezető, aki az élt éveihez képest a legtöbb ideje dolgozik a cégnél?");
            Console.WriteLine("5) Mi a vezetők közötti arány, hány embernek van MBA végzettsége, szemben azokkal akiknek nincs?");
            Console.WriteLine("\nAlkalmazott lekérdezések");
            Console.WriteLine("6) Hány alkalmazott van, akik a 80 -as években születtek?");
            Console.WriteLine("7) Hány alkalmazott van, akik legalább két részlegen dolgoznak?");
            Console.WriteLine("8) Melyik alkalmazottak azok akik jelenleg nyugdíjba mentek de mégis dolgoznak?");
            Console.WriteLine("9) Hány alkalmazott van akik nyugdíjba mentek és ennek megfelelően nem dolgoznak?");
            Console.WriteLine("10) Mennyit keresnek átlagosan azok, akik már nyugdíjba mentek?");
            Console.WriteLine("11) Keresetük alapján(jutalékot is beleértve) csökkenő sorrendben kik dolgoznak itt?");
            Console.WriteLine("12) Tudásszintjük alapján(junior, medior, senior) a dolgozók milyen összetételben dolgoznak a cégnél(100 % az összes dolgozó) ?");
            Console.WriteLine("13) Melyek azok a dolgozók, akik olyan részleghez tartoznak ahol van doktori címmel rendelkező részlegvezető?");
            Console.WriteLine("14) Hány olyan dolgozó van, akiknek a fizetése meghaladja az átlagos fizetési szintet; illetve hány van akik ez alatt keresnek(a jutalékot nem számolva) ?");
            Console.WriteLine("15) Mi az átlagfizetés(jutalékot nem nézve) az egyes szintekben?");
            Console.WriteLine("16) Ki keres többet a jelenlegi dolgozók közül: aki medior szinten átlagfizetést kap vagy egy junior aki a legmagasabb fizetést kapja?");
            Console.WriteLine("17) Melyik kategóriában(junior, medior, senior) a legtöbb a jutalék mértéke?");
            Console.WriteLine("18) Melyik alkalmazott az, aki az itt töltött éveihez képest a legkevesebb projekten dolgozott?");
            Console.WriteLine("19) Születési sorrendben ki mennyit keres?");
            Console.WriteLine("20) A jelenleg aktív státuszban itt dolgozó alkalmazottak közül ki dolgozott a legkevesebb projekten?");
            Console.WriteLine("21) Van-e olyan eset, ahol egy dolgozónak a jutaléka nagyobb, mint egy másik dolgozó alap fizetése? Ha igen, melyik kié ?");
            Console.WriteLine("\nVegyes lekérdezések");
            Console.WriteLine("22) Ki dolgozik a legrégebb óta a cégnél? Vezetők és alkalmazottakat közösen nézve.");
            Console.WriteLine("23) Van-e olyan manager aki egyben részlegvezető is? Ha igen, ki az?");
            Console.WriteLine("24) Kik azok, akik vagy csak részlegvezetők, vagy csak manager-ek ?");
            Console.WriteLine("\n0) Visszalépés a menübe");
            Console.Write("\r\nVálasztott menüpont száma: ");

            switch (Console.ReadLine())
            {
                case "1":
                    //lekérdezés megvalósítása
                    return true;
                case "2":
                    //lekérdezés megvalósítása
                    return true;
                case "3":
                    //lekérdezés megvalósítása
                    return true;
                case "4":
                    //lekérdezés megvalósítása
                    return true;
                case "5":
                    //lekérdezés megvalósítása
                    return true;
                case "6":
                    //lekérdezés megvalósítása
                    return true;
                case "7":
                    //lekérdezés megvalósítása
                    return true;
                case "8":
                    //lekérdezés megvalósítása
                    return true;
                case "9":
                    //lekérdezés megvalósítása
                    return true;
                case "10":
                    //lekérdezés megvalósítása
                    return true;
                case "11":
                    //lekérdezés megvalósítása
                    return true;
                case "12":
                    //lekérdezés megvalósítása
                    return true;
                case "13":
                    //lekérdezés megvalósítása
                    return true;
                case "14":
                    //lekérdezés megvalósítása
                    return true;
                case "15":
                    //lekérdezés megvalósítása
                    return true;
                case "16":
                    //lekérdezés megvalósítása
                    return true;
                case "17":
                    //lekérdezés megvalósítása
                    return true;
                case "18":
                    //lekérdezés megvalósítása
                    return true;
                case "19":
                    //lekérdezés megvalósítása
                    return true;
                case "20":
                    //lekérdezés megvalósítása
                    return true;
                case "21":
                    //lekérdezés megvalósítása
                    return true;
                case "22":
                    //lekérdezés megvalósítása
                    return true;
                case "23":
                    //lekérdezés megvalósítása
                    return true;
                case "24":
                    //lekérdezés megvalósítása
                    return true;
                case "0":
                    return false;
                default:
                    return true;
            }
        }
        private static void AdatImportXML()
        {
            Console.Clear();
            Console.WriteLine("XML-ből importált adatok:\n");
            var xml = XDocument.Load("employees-departments.xml"); 
            foreach (var item in xml.Element("Employees")!.Elements("Employee")) //ha fix nincs null értékünk a hibaüzenetet !-tel feloldható
            {
                Console.WriteLine(item.Element("Name")?.Value);
            }
            Console.WriteLine("\n0, Visszalépés a menübe");
            VisszaLepesAFoMenube();
        }
        private static void AdatImportJSON()
        {
            //letölti a linken található doksit
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            WebClient webClient = new WebClient();
            webClient.DownloadFile("https://nik.siposm.hu/db/managers.json", @"C:\Users\User\Desktop\Féléves Feladat\Feleves_Feladat\Feleves_Feladat\bin\Debug\net8.0\managers.json");
            Console.Clear();
            Console.WriteLine("JSON-ből importált adatok:\n");
            var jsondata = File.ReadAllText("managers.json");
            var managers = JsonConvert
                .DeserializeObject<List<Manager>>(jsondata);

            foreach (var item in managers!) //ha fix nincs null értékünk a hibaüzenetet !-tel feloldható
            {
                Console.WriteLine(item.ToString() + "\n");
            }
            Console.WriteLine("\n0, Visszalépés a menübe");
            VisszaLepesAFoMenube();

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
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = LekerdezesekAlmenu();
            }
        }
        private static void VisszaLepesAFoMenube()
        {
            bool showMenu = true;
            while (showMenu)
            {
                if (Console.ReadLine() == "0")
                {
                    showMenu = false;
                }
                else
                {
                    Console.WriteLine("Nem megfelelő gombot nyomott!");
                }
            }
        }
    }
}

