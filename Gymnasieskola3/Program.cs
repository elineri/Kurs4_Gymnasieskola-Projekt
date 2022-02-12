using System;
using System.Collections.Generic;
using System.Linq;
using Gymnasieskola3.Models;

namespace Gymnasieskola3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool run = true;

            while (run)
            {
                Console.WriteLine("  Välj vad du vill göra\n");
                Console.Write("" +
                    "  [1] Elever\n" +
                    "  [2] Elever i en viss klass\n" +
                    "  [3] Lägg till ny personal\n" +
                    "  [4] Avdelningar och personal\n" +
                    "  [5] Antal personer per avdelning\n" +
                    "  [6] Elevinformation\n" +
                    "  [7] Lista på aktiva kurser\n");
                Console.Write("\n  Val: ");
                int menuOption = Int32.Parse(Console.ReadLine());

                switch (menuOption)
                {
                    case 1: // Show all students
                        Console.Clear();
                        GetStudents();
                        break;
                    case 2: // Show students in a specific class
                        Console.Clear();
                        GetStudentsClass();
                        break;
                    case 3: // Add new staff
                        Console.Clear();
                        AddNewStaff();
                        break;
                    case 4: // Show teachers in a department
                        Console.Clear();
                        StaffDep();
                        break;
                    case 5: // Show amount of teachers in a department
                        Console.Clear();
                        AmountStaffDep();
                        break;
                    case 6: // Student information
                        Console.Clear();
                        StudentInfo();
                        break;
                    case 7: // Active courses
                        Console.Clear();
                        ActiveCourses();
                        break;
                    default:
                        break;
                }
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n  Klicka Enter för att återgå till menyn");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void GetStudents() // Show all students
        {
            Console.WriteLine("  Vill du se elever sorterade på förnamn eller efternamn?");
            Console.WriteLine("  [1] Förnamn\n" +
                "  [2] Efternamn");
            Console.Write("\n  Val: ");
            int option1 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\n  Vill du se i stigande eller fallande ordning?");
            Console.WriteLine("  [1] Stigande\n" +
                "  [2] Fallande");
            Console.Write("\n  Val: ");
            int option2 = Int32.Parse(Console.ReadLine());

            Console.Clear();
            if (option1 == 1 && option2 == 1) // First name and ascending
            {
                using GymnasieskolaDbContext Context = new GymnasieskolaDbContext();

                var students = from TblElever in Context.TblElever
                               orderby TblElever.Eförnamn ascending
                               select TblElever;

                foreach (var item in students)
                {
                    Console.WriteLine($"  {item.Eförnamn} {item.Eefternamn}");
                    Console.WriteLine();
                }

            }
            else if (option1 == 1 && option2 == 2) // First name and descending
            {
                using GymnasieskolaDbContext Context = new GymnasieskolaDbContext();

                var students = from TblElever in Context.TblElever
                               orderby TblElever.Eförnamn descending
                               select TblElever;

                foreach (var item in students)
                {
                    Console.WriteLine($"  {item.Eförnamn} {item.Eefternamn}");
                    Console.WriteLine();
                }
            }
            else if (option1 == 2 && option2 == 1) // Last name and ascending
            {
                using GymnasieskolaDbContext Context = new GymnasieskolaDbContext();

                var students = from TblElever in Context.TblElever
                               orderby TblElever.Eefternamn ascending
                               select TblElever;

                foreach (var item in students)
                {
                    Console.WriteLine($"  {item.Eefternamn}, {item.Eförnamn}");
                    Console.WriteLine();
                }
            }
            else if (option1 == 2 && option2 == 2) // Last name and descending
            {
                using GymnasieskolaDbContext Context = new GymnasieskolaDbContext();

                var students = from TblElever in Context.TblElever
                               orderby TblElever.Eefternamn descending
                               select TblElever;

                foreach (var item in students)
                {
                    Console.WriteLine($"  {item.Eefternamn}, {item.Eförnamn}");
                    Console.WriteLine();
                }
            }
        }

        static void GetStudentsClass()
        {
            using GymnasieskolaDbContext Context = new GymnasieskolaDbContext();

            var classes = from TblKlasser in Context.TblKlasser
                          orderby TblKlasser.Klassnamn ascending
                          select TblKlasser;

            Console.WriteLine("  *** Klasser ***\n");

            int number = 1;

            foreach (var item in classes)
            {
                Console.Write($"  [{number}]");
                number++;
                Console.WriteLine("  " + item.Klassnamn);
            }

            Console.Write("\n  Välj klass: ");
            int option = Int32.Parse(Console.ReadLine());

            var students = from TblElever in Context.TblElever
                           where TblElever.FklassId == option
                           orderby TblElever.Eförnamn ascending
                           select TblElever;

            Console.Clear();
            Console.WriteLine($"\n  Elever\n" +
                $"  ----------------------\n");

            foreach (var item in students)
            {
                Console.WriteLine($"  {item.Eförnamn} {item.Eefternamn}");
            }
        }

        static void AddNewStaff()
        {
            Console.WriteLine("  *** Lägg till ny personal ***\n");
            Console.Write("  Ange förnamn:\t\t");
            string fName = Console.ReadLine();

            Console.Write("  Ange efternamn:\t");
            string lName = Console.ReadLine();

            Console.Write("  Ange befattning:\t");
            string role = Console.ReadLine();

            using GymnasieskolaDbContext Context = new GymnasieskolaDbContext();

            TblPersonal personal = new TblPersonal()
            {
                Pförnamn = fName,
                Pefternamn = lName,
                Befattning = role
            };

            Context.TblPersonal.Add(personal);
            Context.SaveChanges();

            Console.Clear();
            Console.WriteLine($"  Ny personal har lagts till:\n" +
                $"  Namn:\t\t {fName} {lName}\n" +
                $"  Befattning:\t {role}");
        }
        
        static void StaffDep()
        {
            using GymnasieskolaDbContext Context = new GymnasieskolaDbContext();

            Console.WriteLine("  *** Avdelningar ***\n");
            Console.Write("" +
            "  [1] Stab\n" +
            "  [2] Elevstöd\n" +
            "  [3] Lärare grundämnen\n" +
            "  [4] Lärare praktiska/estetiska ämnen\n" +
            "  [5] Underhåll och service\n");
            Console.Write("\n  Val: ");
            int option = Int32.Parse(Console.ReadLine());

            var staff = from TblAvdelningPersonal in Context.TblAvdelningPersonal
                        join TblPersonal in Context.TblPersonal
                        on TblAvdelningPersonal.FpersonalId equals TblPersonal.PersonalId
                        join TblAvdelningar in Context.TblAvdelningar
                        on TblAvdelningPersonal.FavdelningId equals TblAvdelningar.AvdelningId
                        where TblAvdelningPersonal.FavdelningId == option
                        orderby TblPersonal.Pförnamn
                        select new { TblPersonal.Pförnamn, TblPersonal.Pefternamn, TblPersonal.Befattning };

            foreach (var item in staff)
            {
                Console.WriteLine($"  Namn:\t\t {item.Pförnamn} {item.Pefternamn}\n" +
                    $"  Befattning:\t {item.Befattning}");
                Console.WriteLine();
            }
        }

        static void StudentInfo()
        {
            using GymnasieskolaDbContext Context = new GymnasieskolaDbContext();

            Console.WriteLine("  *** Elevinformation ***\n");

            var students = from TblElever in Context.TblElever
                           join TblKlasser in Context.TblKlasser
                           on TblElever.FklassId equals TblKlasser.KlassId
                           orderby TblElever.Eförnamn
                           select new { TblElever.Eförnamn, TblElever.Eefternamn, TblKlasser.Klassnamn, TblElever.Personnummer};

            foreach (var item in students)
            {
                Console.WriteLine($"  Namn:\t\t {item.Eförnamn} {item.Eefternamn}\n" +
                    $"  Personnummer:\t {item.Personnummer.ToString("00000000-0000")}\n" +
                    $"  Klass:\t {item.Klassnamn}");
                Console.WriteLine();
            }
        }

        static void ActiveCourses()
        {
            using GymnasieskolaDbContext Context = new GymnasieskolaDbContext();

            Console.WriteLine("  *** Aktiva kurser ***\n");

            var courses = from TblKursSchema in Context.TblKursSchema
                          join TblKurser in Context.TblKurser
                          on TblKursSchema.FkursId equals TblKurser.KursId
                          where TblKursSchema.KursSlutdatum >= DateTime.Now
                          where TblKursSchema.KursStartdatum <= DateTime.Now
                          orderby TblKurser.Kursnamn
                          select new { TblKurser.Kursnamn, TblKursSchema.KursStartdatum, TblKursSchema.KursSlutdatum };

            foreach (var item in courses)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"  {item.Kursnamn}");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"  Startdatum:\t {item.KursStartdatum.ToString().Substring(0, 10)}\n" +
                    $"  Slutdatum:\t {item.KursSlutdatum.ToString().Substring(0,10)}");
                Console.WriteLine();
            }
        }

        static void AmountStaffDep()
        {
            using GymnasieskolaDbContext Context = new GymnasieskolaDbContext();

            var staff = from TblAvdelningPersonal in Context.TblAvdelningPersonal
                        group TblAvdelningPersonal by TblAvdelningPersonal.FavdelningId into grp
                        select new { key = grp.Key, cnt = grp.Count() };

            List<string> depList = new List<string>();
            depList.Add("Stab");
            depList.Add("Elevstöd");
            depList.Add("Lärare grundämnen");
            depList.Add("Lärare estetiska/praktiska ämnen");
            depList.Add("Underhåll och service");

            Console.WriteLine("  ***Antal personer per avdelning***");
            int i = 0;
            
            foreach (var pers in staff)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"\n  {depList[i]}");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"  {pers.cnt} personer");
                i++;
            }
        }
    }
}
