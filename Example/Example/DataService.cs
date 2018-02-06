using Bogus;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Example
{
    public class DataService
    {
        public DataService()
        {
            var people = new List<Person>();
            var randomParagraphs = new Randomizer().Int(1, 10);
            var countOfPeople = new Randomizer().Int(100, 1000);
            var peopleGenerator = new Faker<Person>()
                .RuleFor(p => p.FirstName, p => p.Person.FirstName)
                .RuleFor(p => p.LastName, p => p.Person.LastName)
                .RuleFor(p => p.BirthDate, p => p.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now.AddDays(-18)))
                .RuleFor(p => p.Biography, p => p.Lorem.Paragraphs(randomParagraphs))
                .Generate(countOfPeople);

            PersonCollection = new ObservableCollection<Person>(peopleGenerator);
        }

        public ObservableCollection<Person> PersonCollection { get; set; }
    }
}
