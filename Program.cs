using SeriesControl.DAO;
using SeriesControl.Entities;
using SeriesControl.Enums;
using System;

namespace SeriesControl
{
    class Program
    {
        static SeriesRepository repository = new SeriesRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X" || userOption.ToUpper() != "x")
            {
                switch (userOption)
                {
                    case "1":
                        SeriesList();
                        break;
                    case "2":
                        SeriesInsert();
                        break;
                    case "3":
                        UpdateSeries();
                        break;
                    case "4":
                        DeleteSeries();
                        break;
                    case "5":
                        SeriesDetail();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = GetUserOption();
            }

            Console.WriteLine("Thank you for using our services. Have a great day!");
            Console.ReadLine();
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Enter your option:");
            Console.WriteLine("-----------------");
            Console.WriteLine();

            Console.WriteLine("1 - List");
            Console.WriteLine("2 - Insert");
            Console.WriteLine("3 - Update");
            Console.WriteLine("4 - Delete");
            Console.WriteLine("5 - Detail");
            Console.WriteLine("C - Clear");
            Console.WriteLine("X - Esc");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return userOption;
        }

        private static void SeriesList()
        {
            Console.WriteLine();
            Console.WriteLine("Series List");
            Console.WriteLine("===========");
            Console.WriteLine();

            var list = repository.List();

            if (list.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("No items registered.");
                return;
            }

            foreach (var serie in list)
            {
                var deleted = serie.deletedReturn();
                Console.WriteLine();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.idReturn(), serie.titleReturn(), (deleted ? "*Deleted*" : ""));
            }
        }

        private static void SeriesInsert()
        {
            Console.WriteLine();
            Console.WriteLine("Insert new item");
            Console.WriteLine("===============");
            Console.WriteLine();

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine();
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }

            Console.WriteLine();
            Console.WriteLine("Enter the genre from the available options: ");
            Console.WriteLine("==========================================");
            Console.WriteLine();
            int genreId = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Enter series title: ");
            Console.WriteLine("==================");
            Console.WriteLine();
            string title = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Enter the series release year: ");
            Console.WriteLine("=============================");
            Console.WriteLine();
            int releaseYearId = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Enter series description: ");
            Console.WriteLine("========================");
            Console.WriteLine();
            string description = Console.ReadLine();

            Serie novaSerie = new Serie(id: repository.NextId(),
                                        genre: (Genre)genreId,
                                        title: title,
                                        releaseYear: releaseYearId,
                                        description: description);

            repository.Insert(novaSerie);
        }

        private static void UpdateSeries()
        {
            Console.WriteLine();
            Console.WriteLine("Enter the series ID: ");
            Console.WriteLine("===================");
            Console.WriteLine();
            int serieIndex = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine();
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }

            Console.WriteLine();
            Console.WriteLine("Enter the genre from the available options: ");
            Console.WriteLine("==========================================");
            Console.WriteLine();
            int genreId = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Enter series title: ");
            Console.WriteLine("==================");
            Console.WriteLine();
            string title = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Enter the series release year: ");
            Console.WriteLine("=============================");
            Console.WriteLine();
            int releaseYearId = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Enter series description: ");
            Console.WriteLine("========================");
            Console.WriteLine();
            string description = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: serieIndex,
                                        genre: (Genre)genreId,
                                        title: title,
                                        releaseYear: releaseYearId,
                                        description: description);

            repository.Update(serieIndex, atualizaSerie);
        }

        private static void DeleteSeries()
        {
            Console.WriteLine();
            Console.WriteLine("Enter the series ID: ");
            Console.WriteLine("===================");
            Console.WriteLine();
            int serieIndex = int.Parse(Console.ReadLine());

            repository.Delete(serieIndex);
        }

        private static void SeriesDetail()
        {
            Console.WriteLine();
            Console.Write("Enter the series ID: ");
            Console.WriteLine("===============");
            Console.WriteLine();
            int serieIndex = int.Parse(Console.ReadLine());

            Console.WriteLine();
            var serie = repository.ReturnById(serieIndex);
            Console.WriteLine(serie);
        }
    }
}

