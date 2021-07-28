using System;

namespace Journal
{
    public class Children : Person
    {
        public int ball { get; set; }

        public override void PrintInfo()
        {
            Console.WriteLine($"#{Id} {FullName} {GetYearsOld(Age)} {ball} баллов");
        }
    }
}
