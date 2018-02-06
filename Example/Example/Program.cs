using System;
using System.Diagnostics;
using System.Linq;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayCounters("Main");
            Console.WriteLine();

            var personDataService = new DataService();
            DisplayCounters("personDataService");
            Console.WriteLine($"There are {personDataService.PersonCollection.Count} people...");
            Console.WriteLine();

            var personDynamicCollection = new PersonDynamicCollection(personDataService.PersonCollection);
            DisplayCounters("personDynamicCollection");
            Console.WriteLine();

            var hourlyPeople = personDynamicCollection.FetchPeople(Duration.HOURLY);
            DisplayCounters("hourlyPeople");
            Console.WriteLine($"There are {hourlyPeople.Count()} hourly people...");
            Console.WriteLine();

            var dailyPeople = personDynamicCollection.FetchPeople(Duration.DAILY);
            DisplayCounters("dailyPeople");
            Console.WriteLine($"There are {dailyPeople.Count()} daily people...");
            Console.WriteLine();

            Console.WriteLine("Finished running experiment.");
            Console.ReadKey();
        }

        private static void DisplayCounters(string variableName)
        {
            var currentProcess = Process.GetCurrentProcess();
            Console.WriteLine($"After {variableName} is called: ");
            Console.WriteLine($"{currentProcess.WorkingSet64:0,000} WorkingSet64 bytes");
        }
    }
}
