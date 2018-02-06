using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Example
{
    public class PersonDynamicCollection
    {
        readonly IEnumerable<Person> personCollection;

        public PersonDynamicCollection(ObservableCollection<Person> personCollection)
        {
            this.personCollection = personCollection.OrderBy(p => p.BirthDate);
        }

        public IEnumerable<Person> FetchPeople(Duration duration)
        {
            var previousPerson = personCollection.First();
            foreach (var person in personCollection)
            {
                var previousDate = previousPerson.BirthDate;
                var nextDate = previousDate.AddHours(1);
                switch (duration)
                {
                    case Duration.HOURLY:
                        if (person.BirthDate > previousDate.AddHours(1))
                        {
                            yield return person;
                        }
                        break;

                    case Duration.DAILY:
                        if (person.BirthDate > previousDate.AddDays(1))
                        {
                            yield return person;
                        }
                        break;

                    case Duration.MONTHLY:
                        if (person.BirthDate > previousDate.AddMonths(1))
                        {
                            yield return person;
                        }
                        break;

                    default:
                        break;
                };

                yield return previousPerson;
                previousPerson = person;
            }
        }
    }
}
