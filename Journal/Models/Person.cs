using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal
{
    public abstract class Person
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronimyc { get; set; }
        public string FullName
        {
            get
            {
                return $"{LastName} {FirstName} {Patronimyc}";
            }
        }
        public int Age { get; set; }

        public abstract void PrintInfo();

        public string GetYearsOld(int age)
        {
            int lastNumber = age % 10;

            if (lastNumber == 1)
            {
                return $"{age} год";
            }

            if (lastNumber == 2 || lastNumber == 3)
            {
                return $"{age} года";
            }

            return $"{age} лет";
        }
    }
}
