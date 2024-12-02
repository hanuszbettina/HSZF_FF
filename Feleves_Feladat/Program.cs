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
            EmployeeDbContext ctx = new EmployeeDbContext();
            Repository repo = new Repository(ctx);
            switch (Console.ReadLine())
            {
                case "1":
                    //lekérdezés megvalósítása
                    Console.Clear();
                    var count = repo.ReadAllManager().Count(m => m.Name.StartsWith("Dr"));
                    Console.WriteLine($"Doktori címmel rendelkező vezetők száma: {count}");
                    Console.ReadKey();
                    return true;
                case "2":
                    //lekérdezés megvalósítása
                    Console.Clear();
                    var manager = repo.ReadAllEmployee()
                        .FirstOrDefault(m => repo.ReadAllDepartment().Any(d => d.HeadOfDepartment == m.Name));
                    if (manager != null)
                    {
                        Console.WriteLine($"Van olyan vezető, aki egyben részlegvezető is: {manager.Name}");
                    }
                    else
                    {
                        Console.WriteLine("Nincs ilyen vezető.");
                    }
                    Console.ReadKey();
                    return true;
                case "3":
                    //lekérdezés megvalósítása
                    Console.Clear();
                    var man3 = repo.ReadAllManager()
                    .OrderBy(m => m.StartOfEmployment)
                    .FirstOrDefault();

                    if (man3 != null)
                    {
                        Console.WriteLine($"Legrégebb óta munkában lévő vezető: {man3.Name} ({man3.StartOfEmployment:yyyy-MM-dd})");
                    }
                    else
                    {
                        Console.WriteLine("Nincsenek vezetők az adatbázisban.");
                    }
                    Console.ReadKey();
                    return true;
                case "4":
                    //lekérdezés megvalósítása
                    Console.Clear();

                    Console.ReadKey();
                    return true;
                case "5":
                    //lekérdezés megvalósítása
                    var total = repo.ReadAllManager().Count();
                    var withMBA = repo.ReadAllManager().Count(m => m.HasMBA);

                    if (total > 0)
                    {
                        var ratio = (double)withMBA / total * 100;
                        Console.WriteLine($"MBA végzettséggel rendelkező vezetők aránya: {ratio:F2}%");
                    }
                    else
                    {
                        Console.WriteLine("Nincsenek vezetők az adatbázisban.");
                    }
                    Console.ReadKey();
                    return true;
                case "6":
                    //lekérdezés megvalósítása
                    Console.Clear();
                    var emp6 = repo.ReadAllEmployee()
                    .Count(e => e.BirthYear >= 1980 && e.BirthYear < 1990);
                    Console.WriteLine($"80-as években született alkalmazottak száma: {emp6}");
                    Console.ReadKey();
                    return true;
                case "7":
                    //lekérdezés megvalósítása
                    Console.Clear();
                    var emp7 = repo.ReadAllEmployee()
                    .Where(e => e.Departments.Count > 1)
                    .ToList();
                    Console.WriteLine($"Két vagy több részlegen dolgozó alkalmazottak száma: {emp7.Count}");
                    Console.ReadKey();
                    return true;
                case "8":
                    //lekérdezés megvalósítása
                    Console.Clear();
                    var emp8 = repo.ReadAllEmployee()
                    .Where(e => e.Retired && e.Active)
                    .Select(e => e.Name)
                    .ToList();
                    if (emp8.Any())
                    {
                        Console.WriteLine("Jelenleg nyugdíjban lévő, de dolgozó alkalmazottak:");
                        emp8.ForEach(Console.WriteLine);
                    }
                    else
                    {
                        Console.WriteLine("Nincs ilyen alkalmazott.");
                    }
                    Console.ReadKey();
                    return true;
                case "9":
                    //lekérdezés megvalósítása
                    Console.Clear();
                    var count9 = repo.ReadAllEmployee()
                    .Count(e => e.Retired && !e.Active);
                    Console.WriteLine($"Nyugdíjba ment alkalmazottak száma: {count9}");
                    Console.ReadKey();
                    return true;
                case "10":
                    //lekérdezés megvalósítása
                    Console.Clear();
                    var emp10 = repo.ReadAllEmployee()
                    .Where(e => e.Retired)
                    .Select(e => e.Salary)
                    .DefaultIfEmpty(0)
                    .Average();
                    Console.WriteLine($"Nyugdíjba ment alkalmazottak átlagos keresete (ha van ilyen, ha nincs akkor 0): {emp10:C}");
                    Console.ReadKey();
                    return true;
                case "11":
                    //lekérdezés megvalósítása
                    Console.Clear();
                    var emp11 = repo.ReadAllEmployee()
                    .OrderByDescending(e => e.Salary + e.Commission)
                    .ToList();
                    Console.WriteLine("Kereset alapján csökkenő sorrend:");
                    emp11.ForEach(e => Console.WriteLine($"- {e.Name}"));
                    Console.ReadKey();
                    return true;
                case "12":
                    //lekérdezés megvalósítása
                    Console.Clear();
                    var juniors = repo.ReadAllEmployee().Count(e => e.Level == "Junior");
                    var mediors = repo.ReadAllEmployee().Count(e => e.Level == "Medior");
                    var seniors = repo.ReadAllEmployee().Count(e => e.Level == "Senior");
                    Console.WriteLine($"Junior: {juniors}, Medior: {mediors}, Senior: {seniors}");
                    Console.ReadKey();
                    return true;
                case "13":
                    //lekérdezés megvalósítása
                    Console.Clear();
                    var emp13 = repo.ReadAllEmployee()
                    .Where(e => e.Departments.Any(d => d.HeadOfDepartment.StartsWith("Dr")))
                    .ToList();
                    Console.WriteLine($"Doktori címmel rendelkező vezetői alá tartozó alkalmazottak száma: {emp13.Count}");
                    Console.ReadKey();
                    return true;
                case "14":
                    //lekérdezés megvalósítása
                    Console.Clear();
                    var avg = repo.ReadAllEmployee().Average(e => e.Salary);
                    var felett = repo.ReadAllEmployee().Count(e => e.Salary > avg);
                    var alatt = repo.ReadAllEmployee().Count(e => e.Salary < avg);
                    Console.WriteLine($"Átlagfizetés felett: {felett}, alatt: {alatt}");
                    Console.ReadKey();
                    return true;
                case "15":
                    //lekérdezés megvalósítása
                    Console.Clear();
                    var levels = repo.ReadAllEmployee()
                    .GroupBy(e => e.Level)
                    .Select(g => new
                    {
                        Level = g.Key,
                        Average = g.Average(e => e.Salary)
                    })
                    .ToList();
                    levels.ForEach(l => Console.WriteLine($"{l.Level}: {l.Average:C0}"));
                    Console.ReadKey();
                    return true;
                case "16":
                    //lekérdezés megvalósítása
                    Console.Clear();
                    var mediorAvg = repo.ReadAllEmployee()
                    .Where(e => e.Level == "Medior")
                    .Average(e => e.Salary);
                    var juniorMax = repo.ReadAllEmployee()
                        .Where(e => e.Level == "Junior")
                        .Max(e => e.Salary);
                    Console.WriteLine($"Medior átlagfizetés: {mediorAvg:C0}, legmagasabb junior fizetés: {juniorMax:C0}");
                    Console.ReadKey();
                    return true;
                case "17":
                    //lekérdezés megvalósítása
                    Console.Clear();
                    var commissions = repo.ReadAllEmployee()
                    .GroupBy(e => e.Level)
                    .Select(g => new
                    {
                        Level = g.Key,
                        TotalCommission = g.Sum(e => e.Commission)
                    })
                    .ToList();
                    commissions.ForEach(c => Console.WriteLine($"{c.Level}: {c.TotalCommission:C0}"));
                    Console.ReadKey();
                    return true;
                case "18":
                    //lekérdezés megvalósítása
                    Console.Clear();
                    var emp18 = repo.ReadAllEmployee()
                   .Where(e => e.StartYear > 0) // Csak azok az alkalmazottak, akik dolgoztak a cégnél
                   .Select(e => new
                   {
                       Employee = e.Name,
                       ProjectsPerYear = (double)e.CompletedProjects / (DateTime.Now.Year - e.StartYear)
                   })
                   .OrderBy(x => x.ProjectsPerYear)
                   .FirstOrDefault();

                    if (emp18 != null)
                    {
                        Console.WriteLine($"Az alkalmazott, aki az itt töltött éveihez képest a legkevesebb projekten dolgozott: {emp18.Employee}, " +
                                          $"projektek/év arány: {emp18.ProjectsPerYear:F2}");
                    }
                    else
                    {
                        Console.WriteLine("Nincs adat megfelelő alkalmazottról.");
                    }
                    Console.ReadKey();
                    return true;
                case "19":
                    //lekérdezés megvalósítása
                    Console.Clear();
                    var emp19 = repo.ReadAllEmployee()
                    .OrderBy(e => e.BirthYear)
                    .Select(e => new
                    {
                        Employee = e.Name,
                        Salaryy = e.Salary
                    })
                    .ToList();
                    Console.WriteLine("Születési sorrend szerinti kereset:");
                    emp19.ForEach(e => Console.WriteLine($"- {e.Employee}: {e.Salaryy:C0}"));
                    Console.ReadKey();
                    return true;
                case "20":
                    //lekérdezés megvalósítása
                    Console.Clear();
                        var emp20 = repo.ReadAllEmployee()
                        .Where(e => e.Active)
                        .OrderBy(e => e.CompletedProjects)
                        .FirstOrDefault();
                        if (emp20 != null)
                        {
                            Console.WriteLine($"A legkevesebb projekten dolgozó aktív alkalmazott: {emp20.Name}, projektek száma: {emp20.CompletedProjects}");
                        }
                        else
                        {
                            Console.WriteLine("Nincs adat megfelelő alkalmazottról.");
                        }
                        Console.ReadKey();
                        return true;
                case "21":
                    //lekérdezés megvalósítása
                    Console.Clear();
                    var emp21 = repo.ReadAllEmployee()
                    .Where(e => e.Commission > e.Salary)
                    .ToList();
                    if (emp21.Any())
                    {
                        Console.WriteLine("Jutalék nagyobb, mint az alapfizetés:");
                        emp21.ForEach(e => Console.WriteLine($"- {e.Name}"));
                    }
                    else
                    {
                        Console.WriteLine("Nincs ilyen alkalmazott.");
                    }
                    Console.ReadKey();
                    return true;
                case "22":
                    //lekérdezés megvalósítása
                    Console.Clear();
                    var emp22 = repo.ReadAllEmployee()
                    .Select(e => new
                    {
                        Employee = e.Name,
                        StartYear = e.StartYear
                    })
                    .Concat(repo.ReadAllManager()
                        .Select(m => new
                        {
                            Employee = m.Name,
                            StartYear = m.StartOfEmployment.Year
                        }))
                    .OrderBy(x => x.StartYear)
                    .FirstOrDefault();
                    if (emp22 != null)
                    {
                        Console.WriteLine($"A legrégebb óta a cégnél dolgozó személy: {emp22.Employee}, kezdési év: {emp22.StartYear}");
                    }
                    else
                    {
                        Console.WriteLine("Nincs ilyen alkalmazott vagy vezető.");
                    }
                    Console.ReadKey();
                    return true;
                case "23":
                    //lekérdezés megvalósítása
                    Console.Clear();
                    var man23 = repo.ReadAllManager()
                    .FirstOrDefault(m => repo.ReadAllDepartment().Any(d => d.HeadOfDepartment == m.Name));
                    if (man23 != null)
                    {
                        Console.WriteLine($"Van olyan vezető, aki egyben részlegvezető is: {man23.Name}");
                    }
                    else
                    {
                        Console.WriteLine("Nincs ilyen vezető.");
                    }
                    Console.ReadKey();
                    return true;
                case "24":
                    //lekérdezés megvalósítása
                    Console.Clear();
                    var emp24 = repo.ReadAllEmployee()
                    .Where(e => e.Departments.Count == 0)
                    .Select(e => e.Name)
                    .Concat(repo.ReadAllManager()
                        .Where(m => !repo.ReadAllDepartment().Any(d => d.HeadOfDepartment == m.Name))
                        .Select(m => m.Name))
                    .ToList();
                    if (emp24.Any())
                    {
                        Console.WriteLine("Csak részlegvezetők vagy csak vezetők:");
                        emp24.ForEach(Console.WriteLine);
                    }
                    else
                    {
                        Console.WriteLine("Nincs ilyen alkalmazott vagy vezető.");
                    }
                    Console.ReadKey();

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
            EmployeeDbContext ctx = new EmployeeDbContext();
            Repository repo = new Repository(ctx);
            ImportXmlToDatabase(repo.ReadAllEmployee(), repo.ReadAllDepartment(), "employees-departments.xml");
            Console.WriteLine("0, Visszalépés a menübe");
            VisszaLepesAFoMenube();
        }
        public static void ImportXmlToDatabase(IEnumerable<Employee> empdata, IEnumerable<Department> depdata, string xmlFilePath)
        {
            EmployeeDbContext ctx = new EmployeeDbContext();
            Repository repo = new Repository(ctx);
            Console.WriteLine("XML import kezdése..");
            List<Employee> employees = CreateEmployeeListFromXml(xmlFilePath);
            var depCache = new Dictionary<string, Department>();
            foreach (var emp in employees)
            {
                var depAdd = new List<Department>();
                foreach (var department in emp.Departments)
                {
                    if (!depCache.TryGetValue(department.DepartmentCode, out var Dep))
                    {
                        Dep = depdata.FirstOrDefault(d => d.DepartmentCode == department.DepartmentCode);
                        if (Dep == null)
                        {
                            Dep = department;
                            depCache[department.DepartmentCode] = Dep;
                        }

                    }
                    depAdd.Add(Dep);
                }
                emp.Departments = depAdd;
                repo.CreateEmployee(emp);
            }
            if (empdata != null && depdata != null)
            {
                Console.WriteLine("Sikeres Import");
                Console.ReadKey();
            }
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
                                Console.Clear();
                                Console.WriteLine("Employee adatok\n");
                                repo.CreateEmployee(EmpPeldanyCreate());
                                Console.WriteLine("Az új Employeet hozzáadtuk az adatbázishoz!");
                                Console.WriteLine("\n0, Visszalépés a menübe");
                                VisszaLepesAFoMenube();
                                return false;
                                break;
                            case "Department":
                                Console.Clear();
                                Console.WriteLine("Department adatok\n");
                                repo.CreateDepartment(DepPeldanyCreate());
                                Console.WriteLine("Az új Department hozzáadtuk az adatbázishoz!");
                                Console.WriteLine("\n0, Visszalépés a menübe");
                                VisszaLepesAFoMenube();
                                return false;
                                break;
                            case "Manager":
                                Console.Clear();
                                Console.WriteLine("Manager adatok\n");
                                repo.CreateManager(ManPeldanyCreate());
                                Console.WriteLine("Az új Managert hozzáadtuk az adatbázishoz!");
                                Console.WriteLine("\n0, Visszalépés a menübe");
                                VisszaLepesAFoMenube();
                                return false;
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
                                Console.WriteLine("Az adatbázisban található Employeek: \n");
                                var emps = repo.ReadAllEmployee();
                                foreach (var item in emps)
                                {
                                    if (item.Active && item.Retired)
                                    {
                                        Console.WriteLine($"Azonosító: {item.Id}\nNév: {item.Name}\nSzületési év: {item.BirthYear}\nKezdés éve: {item.StartYear}\nTeljesített projektek száma: {item.CompletedProjects}\nAktív-e: Aktív\nNyugdíjas-e: Nyugdíjas\nEmail: {item.Email}\nTelefonszám: {item.Phone}\nMunkakör: {item.Job}\nSzint: {item.Level}\nFizetés: {item.Salary}\nJuttatás: {item.Commission}\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Azonosító: {item.Id}\nNév: {item.Name}\nSzületési év: {item.BirthYear}\nKezdés éve: {item.StartYear}\nTeljesített projektek száma: {item.CompletedProjects}\nAktív-e: Nem aktív\nNyugdíjas-e: Nem nyugdíjas\nEmail: {item.Email}\nTelefonszám: {item.Phone}\nMunkakör: {item.Job}\nSzint: {item.Level}\nFizetés: {item.Salary}\nJuttatás: {item.Commission}\n");
                                    }
                                }
                                Console.WriteLine("\n0, Visszalépés a menübe");
                                VisszaLepesAFoMenube();
                                return false;
                                break;
                            case "Department":
                                Console.Clear();
                                Console.WriteLine("Az adatbázisban található Employeek: \n");
                                var deps = repo.ReadAllDepartment();
                                foreach (var item in deps)
                                {
                                  Console.WriteLine($"Név: {item.Name}\nAzonosító: {item.DepartmentCode}\nVezető: {item.HeadOfDepartment}\n");
                                    
                                }
                                Console.WriteLine("\n0, Visszalépés a menübe");
                                VisszaLepesAFoMenube();
                                return false;
                                break;
                            case "Manager":
                                Console.Clear();
                                Console.WriteLine("Az adatbázisban található Managerek: \n");
                                var mans = repo.ReadAllManager();
                                foreach (var item in mans)
                                {
                                    if (item.HasMBA)
                                    {
                                        Console.WriteLine($"Név: {item.Name}\nAzonosító: {item.ManagerId}\nSzületési év: {item.BirthYear}\nKezdés éve: {item.StartOfEmployment}\nMBA: Van\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Név: {item.Name}\nAzonosító: {item.ManagerId}\nSzületési év: {item.BirthYear}\nKezdés éve: {item.StartOfEmployment.Year}\nMBA: Nincs\n");
                                    }
                                }
                                Console.WriteLine("\n0, Visszalépés a menübe");
                                VisszaLepesAFoMenube();
                                return false;
                                break;
                        }
                    }
                    return true;
                case "3":
                    Console.Clear();
                    showMenu = true;
                    while (showMenu)
                    {
                        string id;
                        switch (OsztalyBekeres())
                        {
                            case "Employee":
                                Console.Clear();
                                Console.WriteLine("Kérem a frisíteni kívánt elem id-ját:\n");
                                id = Console.ReadLine();
                                repo.EmployeeUpdate(id,EmpPeldanyCreate());
                                Console.WriteLine("\nSikeres frissítés");
                                Console.WriteLine("\n0, Visszalépés a menübe");
                                VisszaLepesAFoMenube();
                                return false;
                                break;
                            case "Department":
                                Console.Clear();
                                Console.WriteLine("Kérem a frisíteni kívánt elem id-ját:\n");
                                id = Console.ReadLine();
                                repo.DepartmentUpdate(id, DepPeldanyCreate());
                                Console.WriteLine("\nSikeres frissítés");
                                Console.WriteLine("\n0, Visszalépés a menübe");
                                VisszaLepesAFoMenube();
                                return false;
                                break;
                            case "Manager":
                                Console.Clear();
                                Console.WriteLine("Kérem a frisíteni kívánt elem id-ját:\n");
                                id = Console.ReadLine();
                                repo.ManagerUpdate(id, ManPeldanyCreate());
                                Console.WriteLine("\nSikeres frissítés");
                                Console.WriteLine("\n0, Visszalépés a menübe");
                                VisszaLepesAFoMenube();
                                return false;
                                break;
                        }
                    }
                    return true;
                case "4":
                    Console.Clear();
                    showMenu = true;
                    while (showMenu)
                    {
                        string azon;
                        switch (OsztalyBekeres())
                        {
                            case "Employee":
                                Console.Clear();
                                Console.WriteLine("Kérem adja meg a törölni kívánt azonosítót: ");
                                azon = Console.ReadLine();
                                repo.EmployeeDeleteById(azon);
                                Console.WriteLine("\nSikeres törlés");
                                Console.WriteLine("\n0, Visszalépés a menübe");
                                VisszaLepesAFoMenube();
                                return false;
                                break;
                            case "Department":
                                Console.Clear();
                                Console.WriteLine("Kérem adja meg a törölni kívánt azonosítót: ");
                                azon = Console.ReadLine(); 
                                repo.DepartmentDeleteById(azon);
                                Console.WriteLine("\nSikeres törlés");
                                Console.WriteLine("\n0, Visszalépés a menübe");
                                VisszaLepesAFoMenube();
                                return false;
                                break;
                            case "Manager":
                                Console.Clear();
                                Console.WriteLine("Kérem adja meg a törölni kívánt azonosítót: ");
                                azon = Console.ReadLine();
                                repo.ManagerDeleteById(azon);
                                Console.WriteLine("\nSikeres törlés");
                                Console.WriteLine("\n0, Visszalépés a menübe");
                                VisszaLepesAFoMenube();
                                return false;
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
        private static string OsztalyBekeres()
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
            Console.Clear();
            Console.WriteLine("Grafikon\n");
            GrafikonMegjelenites(CreateEmployeeListFromXml("employees-departments.xml"));
            Console.WriteLine("\n0, Visszalépés a menübe");
            VisszaLepesAFoMenube();
        }
        public static void GrafikonMegjelenites(List<Employee> employees)
        {
            Console.Clear();
            Console.WriteLine("Alkalmazottak fizetése:\n");

            int maxSalary = employees.Max(e => e.Salary);
            int maxNameLength = employees.Max(e => e.Name.Length);

            foreach (var employee in employees)
            {
                string name = employee.Name.PadRight(maxNameLength);
                int barLength = (int)Math.Round((double)employee.Salary / maxSalary * 20); // 20 a max oszlophossz
                string bar = new string('█', barLength);
                Console.WriteLine($"{name} {bar} {employee.Salary:N0} HUF");
            }
        }
        public static List<Employee> CreateEmployeeListFromXml(string filePath)
        {
            XDocument doc = XDocument.Load(filePath);

            return doc.Descendants("Employee").Select(emp => new Employee
            {
                Id = emp.Attribute("employeeid")?.Value,
                Name = emp.Element("Name")?.Value,
                BirthYear = Convert.ToInt32(emp.Element("BirthYear")?.Value ?? "0"),
                StartYear = Convert.ToInt32(emp.Element("StartYear")?.Value ?? "0"),
                CompletedProjects = Convert.ToInt32(emp.Element("CompletedProjects")?.Value ?? "0"),
                Active = bool.Parse(emp.Element("Active")?.Value ?? "false"),
                Retired = bool.Parse(emp.Element("Retired")?.Value ?? "false"),
                Email = emp.Element("Email")?.Value,
                Phone = emp.Element("Phone")?.Value,
                Job = emp.Element("Job")?.Value,
                Level = emp.Element("Level")?.Value,
                Salary = Convert.ToInt32(emp.Element("Salary")?.Value ?? "0"),
                Commission = Convert.ToInt32(emp.Element("Commission")?.Value ?? "0"),
                Departments = emp.Element("Departments")!.Elements("Department").Select(dept => new Department
                {
                    Name = dept.Element("Name")!.Value,
                    DepartmentCode = dept.Element("DepartmentCode")!.Value,
                    HeadOfDepartment = dept.Element("HeadOfDepartment")!.Value
                }).ToList()
            }).ToList();
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

