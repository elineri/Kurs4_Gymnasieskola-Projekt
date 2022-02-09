using System;
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
                    "  [1] Personal\n" +
                    "  [2] Elever\n" +
                    "  [3] Elever i en viss klass\n" +
                    "  [4] Alla betyg från senaste månaden\n" +
                    "  [5] Kurser och snittbetyg\n" +
                    "  [6] Lägg till ny elev\n" +
                    "  [7] Lägg till ny personal\n");
                Console.Write("\n  Val: ");
                int menuOption = Int32.Parse(Console.ReadLine());

                switch (menuOption)
                {
                    case 1: // Show all staff
                        Console.Clear();
                        Console.WriteLine("  *** Personal ***\n");
                        Console.WriteLine("  Vill du se all personal eller bara lärare?\n" +
                            "  [1] All personal\n" +
                            "  [2] Bara lärare");
                        Console.Write("  Val: ");
                        int optionStaff = Int32.Parse(Console.ReadLine());

                        Console.Clear();
                        if (optionStaff == 1)
                        {
                            Console.WriteLine("  Se SQL query för att se personal");
                        }
                        else if (optionStaff == 2)
                        {
                            Console.WriteLine("  Se SQL query för att se lärare");
                        }
                        break;
                    case 2: // Show all students
                        Console.Clear();
                        GetStudents();
                        break;
                    case 3: // Show students in a specific class
                        Console.Clear();
                        GetStudentsClass();
                        break;
                    case 4: // Show all grades from last month
                        Console.Clear();
                        Console.WriteLine("  Se SQL query för att se betyg");
                        break;
                    case 5: // Show all courses and average grades
                        Console.Clear();
                        Console.WriteLine("  Se SQL query för att se betyg");
                        break;
                    case 6: // Add a new student
                        Console.Clear();
                        Console.WriteLine("  Se SQL query för att lägga till en ny elev");
                        break;
                    case 7: // Add new staff
                        Console.Clear();
                        AddNewStaff();
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
            Console.Write("  Val: ");
            int option1 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\n  Vill du se i stigande eller fallande ordning?");
            Console.WriteLine("  [1] Stigande\n" +
                "  [2] Fallande");
            Console.Write("  Val: ");
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

            Console.Write("\n  Välj klass:");
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
    }
}
