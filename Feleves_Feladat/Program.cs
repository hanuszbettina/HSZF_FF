using Feleves_Feladat.Models;
using FelevesFeladatDomain;
using FelevesFeladatDomain.Attributes;
using FelevesFeladatInfrastructure;
using Newtonsoft.Json;
using System;
using System.Diagnostics.Metrics;
using System.Net;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            Console.WriteLine("0) Visszalépés a menübe");
            Console.WriteLine("\nVezető lekérdezések");
            Console.WriteLine("\t1) Hány doktori címmel rendelkező vezető(manager) van?");
            Console.WriteLine("\t2) Van - e olyan(és ha igen ki / kik) akik doktori címmel rendelkeznek, de MBA(Master of Business Administration) végzettségük nincs?");
            Console.WriteLine("\t3) Ki a legrégebb óta munkában lévő vezető?");
            Console.WriteLine("\t4) Melyik az a vezető, aki az élt éveihez képest a legtöbb ideje dolgozik a cégnél?");
            Console.WriteLine("\t5) Mi a vezetők közötti arány, hány embernek van MBA végzettsége, szemben azokkal akiknek nincs?");
            Console.WriteLine("\nAlkalmazott lekérdezések");
            Console.WriteLine("\t6) Hány alkalmazott van, akik a 80 -as években születtek?");
            Console.WriteLine("\t7) Hány alkalmazott van, akik legalább két részlegen dolgoznak?");
            Console.WriteLine("\t8) Melyik alkalmazottak azok akik jelenleg nyugdíjba mentek de mégis dolgoznak?");
            Console.WriteLine("\t9) Hány alkalmazott van akik nyugdíjba mentek és ennek megfelelően nem dolgoznak?");
            Console.WriteLine("\t10) Mennyit keresnek átlagosan azok, akik már nyugdíjba mentek?");
            Console.WriteLine("\t11) Keresetük alapján(jutalékot is beleértve) csökkenő sorrendben kik dolgoznak itt?");
            Console.WriteLine("\t12) Tudásszintjük alapján(junior, medior, senior) a dolgozók milyen összetételben dolgoznak a cégnél(100 % az összes dolgozó) ?");
            Console.WriteLine("\t13) Melyek azok a dolgozók, akik olyan részleghez tartoznak ahol van doktori címmel rendelkező részlegvezető?");
            Console.WriteLine("\t14) Hány olyan dolgozó van, akiknek a fizetése meghaladja az átlagos fizetési szintet; illetve hány van akik ez alatt keresnek(a jutalékot nem számolva) ?");
            Console.WriteLine("\t15) Mi az átlagfizetés(jutalékot nem nézve) az egyes szintekben?");
            Console.WriteLine("\t16) Ki keres többet a jelenlegi dolgozók közül: aki medior szinten átlagfizetést kap vagy egy junior aki a legmagasabb fizetést kapja?");
            Console.WriteLine("\t17) Melyik kategóriában(junior, medior, senior) a legtöbb a jutalék mértéke?");
            Console.WriteLine("\t18) Melyik alkalmazott az, aki az itt töltött éveihez képest a legkevesebb projekten dolgozott?");
            Console.WriteLine("\t19) Születési sorrendben ki mennyit keres?");
            Console.WriteLine("\t20) A jelenleg aktív státuszban itt dolgozó alkalmazottak közül ki dolgozott a legkevesebb projekten?");
            Console.WriteLine("\t21) Van-e olyan eset, ahol egy dolgozónak a jutaléka nagyobb, mint egy másik dolgozó alap fizetése? Ha igen, melyik kié ?");
            Console.WriteLine("\nVegyes lekérdezések");
            Console.WriteLine("\t22) Ki dolgozik a legrégebb óta a cégnél? Vezetők és alkalmazottakat közösen nézve.");
            Console.WriteLine("\t23) Van-e olyan manager aki egyben részlegvezető is? Ha igen, ki az?");
            Console.WriteLine("\t24) Kik azok, akik vagy csak részlegvezetők, vagy csak manager-ek ?");
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
            //eur to huf
            foreach (var elem in xml.Descendants("Commission"))
            {
                XAttribute currency = elem.Attribute("currency");
                if (currency != null)
                {
                    if (currency.Value == "eur")
                    {
                        //Euró az attributum
                        int ertekint = Convert.ToInt32(elem.Value) * 400;
                        elem.Value = Convert.ToString(ertekint);
                    }
                }
            }
            foreach (var item in xml.Element("Employees")!.Elements("Employee")) //ha fix nincs null értékünk a hibaüzenetet !-tel feloldható
            {
                Console.WriteLine($"Név: {item.Element("Name")?.Value}");
                Console.WriteLine($"Születési év: {item.Element("BirthYear")?.Value}");
                Console.WriteLine($"Kezdés éve: {item.Element("StartYear")?.Value}");
                Console.WriteLine($"Teljesített projektek: {item.Element("CompletedProjects")?.Value}");
                Console.WriteLine($"Aktív: {item.Element("Active")?.Value}");
                Console.WriteLine($"Nyugdíjas: {item.Element("Retired")?.Value}");
                Console.WriteLine($"Email: {item.Element("Email")?.Value}");
                Console.WriteLine($"Munka: {item.Element("Job")?.Value}");
                Console.WriteLine($"Szint: {item.Element("Level")?.Value}");
                Console.WriteLine($"Fizetés: {item.Element("Salary")?.Value}");
                Console.WriteLine($"Juttatás: {item.Element("Commission")?.Value}");
                Console.WriteLine($"Részlegek:");
                foreach (var dep in item.Elements("Departments").Elements("Department"))
                {
                    Console.WriteLine($"\n\tNév: {dep.Element("Name")?.Value}");
                    Console.WriteLine($"\tOsztály kód: {dep.Element("DepartmentCode")?.Value}");
                    Console.WriteLine($"\tVezető: {dep.Element("HeadOfDepartment")?.Value}");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("0, Visszalépés a menübe");
            VisszaLepesAFoMenube();
        }
        private static void AdatImportJSON()
        {
            EmployeeDbContext ctx = new EmployeeDbContext();
            Repository repo = new Repository(ctx);
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
                repo.AddManager(item);
                Console.WriteLine(item.ToString() + "\n");
            }
            Console.WriteLine("JSON adatok importálva az adatbázisba.");
            Console.WriteLine("\n0, Visszalépés a menübe");
            VisszaLepesAFoMenube();

        }
        private static void AdatExport()
        {
            Console.Clear();
            Console.WriteLine("Adatexport");
            Console.WriteLine("Az alábbi osztálytályok (Department, Employee, Manager) exportálása xml fájlba.");
            DataFetcher df = new DataFetcher();
            df.FetchDataFromProgram();
            Console.WriteLine("\n0, Visszalépés a menübe");
            VisszaLepesAFoMenube();
        }

        
        private static bool CRUD()
        {
            Console.Clear();
            Console.WriteLine("0) Visszalépés a menübe");
            Console.WriteLine("1) Create");
            Console.WriteLine("2) Read");
            Console.WriteLine("3) Update");
            Console.WriteLine("4) Delete");
            
            Console.Write("\r\nVálasztott menüpont száma: ");
            
            EmployeeDbContext ctx = new EmployeeDbContext();

            Repository repo = new Repository(ctx);
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    bool showMenu = true;
                    while (showMenu)
                    {
                        switch (OsztalyBekeres())
                        {
                            case "Employee":
                                Console.WriteLine("Employee adatok\n");
                                repo.CreateEmployee(EmpPeldanyCreate());
                                break;
                            case "Department":
                                
                                repo.CreateDepartment(DepPeldanyCreate());
                                break;
                            case "Manager":
                                repo.CreateManager(ManPeldanyCreate());
                                break;
                        }
                    }

                    return true;
                case "2":
                    Console.Clear();
                    showMenu = true;
                    while (showMenu)
                    {
                        switch (OsztalyBekeres())
                        {
                            case "Employee":
                                Console.Clear();
                                Console.WriteLine(repo.ReadAllEmployee()); 
                                break;
                            case "Department":
                                Console.Clear();
                                Console.WriteLine(repo.ReadAllDepartment());
                                break;
                            case "Manager":
                                Console.Clear();
                                var mans = repo.ReadAllManager();
                                foreach (var item in mans)
                                {
                                    if (item.HasMBA)
                                    {
                                        Console.WriteLine($"Név: {item.Name}\nAzonosító: {item.ManagerId}\nSzületési év: {item.BirthYear}\nKezdés éve: {item.StartOfEmployment}\nMBA: Van");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Név: {item.Name}\nAzonosító: {item.ManagerId}\nSzületési év: {item.BirthYear}\nKezdés éve: {item.StartOfEmployment.Year}\nMBA: Nincs");
                                    }
                                }
                                Console.WriteLine(repo.ReadAllManager());
                                break;
                        }
                    }
                    return true;
                case "3":
                    Console.Clear();
                    showMenu = true;
                    while (showMenu)
                    {
                        switch (OsztalyBekeres())
                        {
                            case "Employee":
                                Console.WriteLine("Employee adatok\n");

                                repo.EmployeeUpdate(EmpPeldanyCreate());
                                break;
                            case "Department":
                                Console.WriteLine("Deparment adatok\n");
                                repo.DepartmentUpdate(DepPeldanyCreate());
                                break;
                            case "Manager":
                                Console.WriteLine("Manager adatok\n");
                                repo.ManagerUpdate(ManPeldanyCreate());
                                break;
                        }
                    }
                    return true;
                case "4":
                    Console.Clear();
                    showMenu = true;
                    while (showMenu)
                    {
                        Console.WriteLine("Kérem adja meg a törölni kívánt azonosítót: ");
                        string azon = Console.ReadLine();
                        switch (OsztalyBekeres())
                        {
                            case "Employee":
                                repo.EmployeeDeleteById(azon);
                                break;
                            case "Department":
                                repo.DepartmentDeleteById(azon);
                                break;
                            case "Manager":
                                repo.ManagerDeleteById(azon);
                                break;
                        }
                    }
                    return true;
                case "0":
                    return false;
                default:
                    return true;
            }

        }
        //CRUD segéd metódusok
        private static Employee EmpPeldanyCreate()
        {
            Console.WriteLine("Kérem az Id-t (pl: EMP008 vagy EMP030): ");
            string empId = Console.ReadLine();
            Console.WriteLine("Neve: ");
            string empName = Console.ReadLine();
            Console.WriteLine("Létrejöttének éve: ");
            int empBirtYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Kezdetének éve: ");
            int empStartYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Teljesített projektek száma: ");
            int empCompletedProjects = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Aaktív-e (true/false): ");
            bool empActive = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Nyugdíjas-e (true/false): ");
            bool empRetired = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Email címe: ");
            string empEmail = Console.ReadLine();
            Console.WriteLine("Telefonszáma: ");
            string empPhone = Console.ReadLine();
            Console.WriteLine("Munkája: ");
            string empJob = Console.ReadLine();
            Console.WriteLine("Szintje (Junior/Senior/Medior): ");
            string empLevel = Console.ReadLine();
            Console.WriteLine("Fizetése: ");
            int empSalary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Juttatása: ");
            int empCommission = Convert.ToInt32(Console.ReadLine());
            Employee emp = new Employee(empId, empName, empBirtYear, empStartYear, empCompletedProjects, empActive, empRetired, empEmail, empPhone, empJob, empLevel, empSalary, empCommission);
            return emp;
        }
        private static Department DepPeldanyCreate()
        {
            Console.WriteLine("Deparment adatok\n");
            Console.WriteLine("Neve: ");
            string depName = Console.ReadLine();
            Console.WriteLine("Kérem az azonosítótt (pl: SW101 vagy DB102): ");
            string depCode = Console.ReadLine();
            Console.WriteLine("Főnök neve: ");
            string depHead = Console.ReadLine();
            Department dep = new Department(depName, depCode, depHead);
            return dep;
        }
        private static Manager ManPeldanyCreate()
        {
            Console.WriteLine("Manager adatok\n");
            Console.WriteLine("Neve: ");
            string manName = Console.ReadLine();
            Console.WriteLine("Kérem az azonosítótt (pl: MGR456 vagy MGR789): ");
            string manId = Console.ReadLine();
            Console.WriteLine("Születési éve: ");
            int manBirtYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Munkájának kezdeti dátuma (pl: 1998-05-10): ");
            DateTime manStartOfEmployment = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Vane MBA-ja (true/false): ");
            bool manHasMBA = Convert.ToBoolean(Console.ReadLine());
            Manager man = new Manager(manName, manId, manBirtYear, manStartOfEmployment, manHasMBA);
            return man;
        }
        private static string OsztalyBekeres() //EZ MÉG NEM JÓ :(
        {
            string type;
            do
            {
                Console.WriteLine("Kérem adja meg a szerkeszteni kívánt elemet (Employee/Department/Manager):\n");
                type = Console.ReadLine();

            } while (type != "Employee" && type != "Department" && type != "Manager");
            return type;
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

