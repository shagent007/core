using System;

namespace ConsoleApp
{
    public class Person
    {
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
        public void PrintInfo()
        {
            Console.WriteLine($"{FullName} {GetYearsOld(Age)}");
        }

        private string GetYearsOld(int age) 
        {
            int lastNumber = age % 10;

            if (lastNumber == 1)
            {
                return $"{age} год";
            }

            if (lastNumber == 2  || lastNumber == 3)
            {
                return $"{age} года";
            }

            return $"{age} лет";
        }
    }

}
