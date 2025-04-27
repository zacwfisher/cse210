using System;

public class GradeCalculator
{
    public static void Main(string[] args)
    {
        Console.Write("Please enter your grade percentage: ");
        string gradePercentageStr = Console.ReadLine();
        if (double.TryParse(gradePercentageStr, out double gradePercentage))
        {
            string letter = "";
            string sign = "";

            if (gradePercentage >= 90)
            {
                letter = "A";
            }
            else if (gradePercentage >= 80)
            {
                letter = "B";
            }
            else if (gradePercentage >= 70)
            {
                letter = "C";
            }
            else if (gradePercentage >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }

            if (letter != "F")
            {
                int lastDigit = (int)gradePercentage % 10;
                if (lastDigit >= 7)
                {
                    sign = "+";
                }
                else if (lastDigit < 3)
                {
                    sign = "-";
                }
            }

            if (letter == "A")
            {
                sign = ""; // No A+
            }
            else if (letter == "F")
            {
                sign = ""; // No F+ or F-
            }

            Console.WriteLine($"Your final letter grade is: {letter}{sign}");

            if (gradePercentage >= 70)
            {
                Console.WriteLine("Congratulations! You passed the course.");
            }
            else
            {
                Console.WriteLine("Hang in there! Keep trying for the next time.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number for the grade percentage.");
        }
    }
}