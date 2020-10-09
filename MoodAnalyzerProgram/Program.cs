using System;

namespace MoodAnalyzerProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mood Analyzer Program");
            Console.WriteLine("=================================");

            MoodAnalyser mood = new MoodAnalyser();
            Console.WriteLine(mood.AnalyseMood("I am Sad"));
            Console.WriteLine(mood.AnalyseMood("I am okay"));
        }
    }
}
