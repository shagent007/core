using Journal;
using System.Collections.Generic;
namespace ConsoleApp
{
    partial class Program
    {

        static void Main(string[] args)
        {
            Journal.Journal journal = new Journal.Journal();
            journal.Start();

        }

        private static void StartJournal()
        {
            List<Person> persons = new List<Person>();

            bool addPerson = true;
            do
            {

                addPerson = Ask.Confirm();
                if (!addPerson) break;

                Person person = new Person();

                person.FirstName = Ask.Question("Введите имя человека: ", "Введите корректное имя");
                person.LastName = Ask.Question("Введите фамилию человека: ", "Введите корректную фамилию");
                person.Patronimyc = Ask.Question("Введите отчество человека: ", "", false);
                person.Age = Ask.Age("Введите возраст человека", "Введите коррекный возраст");

                persons.Add(person);

            } while (addPerson);

            foreach (Person person in persons)
            {
                person.PrintInfo();
            }
        }
    }
}
