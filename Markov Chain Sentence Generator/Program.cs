using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Markov_Chain_Sentence_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Split sentences into words
            int userChoice = 0;
            string chosenText = "";
            UI.Menu(ref userChoice);
            switch (userChoice)
            {
                case 1:
                    chosenText = UI.ChooseSentence();
                    break;
                case 2:
                    Console.WriteLine("Enter your text: ");
                    chosenText = Console.ReadLine();
                    break;
                default:
                    break;
            }
            if (!chosenText.Equals(""))
            {
                WordsProbability[] words = new WordsProbability[Regex.Split(chosenText, "\\W").Length];
                Markov_chain.BuildDictionary(words, chosenText);


                string newSentence = Markov_chain.MakeSentence(words);
                Console.WriteLine($"Result: {newSentence}");
            }
            Console.ReadKey();
        }
    }
}
