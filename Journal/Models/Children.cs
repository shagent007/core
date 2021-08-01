using System;

namespace Journal
{
    public class Children : Person
    {
        public override void PrintInfo()
        {
            Console.WriteLine($"#{Id} {FullName} {GetYearsOld(Age)}");
        }
    }
}
