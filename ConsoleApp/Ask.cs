using System;

namespace ConsoleApp
{
    public static class Ask
    {
        public static bool Confirm()
        {
            bool isValidAnswer;
            string answer;
            do
            {
                Console.Write("Добавить нового человека? (y/n)");

                answer = Console.ReadLine();
                isValidAnswer = answer == "y" || answer == "n";
                if (!isValidAnswer)
                {
                    Console.WriteLine($"{answer} не является вариантом ответа");
                }
            } while (!isValidAnswer);

            return answer == "y";
        }

        public static string Question(string question, string errorMessage, bool validate = true)
        {
            string answer;
            bool isValidAnswer;
            do
            {
                Console.Write(question);
                answer = Console.ReadLine();
                isValidAnswer = answer != "" && answer != null;
                if (!isValidAnswer && validate)
                {
                    Console.WriteLine(errorMessage);
                }
            } while (!isValidAnswer && validate);


            return answer;
        }

        public static int Age(string question, string errorMessage)
        {
            int age;
            bool isValidAge;
            do
            {
                Console.Write(question);
                isValidAge = int.TryParse(Console.ReadLine(), out age);

                if (!isValidAge)
                {
                    Console.WriteLine(errorMessage);
                }
            } while (!isValidAge);


            return age;
        }
    }
}
