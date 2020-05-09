using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Naive_Bayes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("/\\/\\/\\/\\/ NAIVE BAYES \\/\\/\\/\\/\\");
                Console.WriteLine(@"Read base base_en.txt");
                string[] stringToParse = null;
                try
                {
                    stringToParse = File.ReadAllLines(@"base_en.txt");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (stringToParse != null)
                {
                    var trainCorpus = ParseTrainCorpus(stringToParse);
                    var bayes = new Classifier(trainCorpus);
                    var text = "";

                    Console.Write("\nInput text to check: ");
                    text = Console.ReadLine().ToLower();

                    while (text != "exit")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("*********RESULT*********");
                        var resSpam = bayes.IsInClassProbability("spam", text);
                        var resHam = bayes.IsInClassProbability("ham", text);
                        Console.WriteLine("result\nspam: {0}\nham: {1}", resSpam, resHam);

                        if (resSpam > resHam)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("I suppose it is spam");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Maybe you received message from your best friend");
                        }

                        Console.ResetColor();
                        Console.Write("\nInput text to check: ");
                        text = Console.ReadLine().ToLower();
                    }
                }
                Console.ReadKey();
            }
        }

        static List<Document> ParseTrainCorpus(string[] textToParse)
        {
            var resultList = new List<Document>();
            foreach(var line in textToParse)
            {
                var trimPos = line.IndexOf(";");
                var @class = line.Substring(0, trimPos).ToLower();
                var text = line.Substring(trimPos+1, line.Length-trimPos-1).ToLower();
                resultList.Add(new Document(@class, text));
            }

            return resultList;
        }
    }
}