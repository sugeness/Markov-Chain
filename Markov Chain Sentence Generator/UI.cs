using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markov_Chain_Sentence_Generator
{
    class UI
    {
        //Few sentences, that user can choose from
        private static string[] _speech =
                {
                "I have a vivid memory of what happened, and it was not what I expected. I expected to be applauded for my cleverness and arithmetic skills.",
                "I find beautiful language necessary but not sufficient. Few sentences below use prosaic language, but if they do, they acheive beauty by the complexity of their construction, the way the sentence unspools.",
                "Ambition isn’t just length, although it often appears that way. Ambitious sentences attempt new forms, rebel against syntax and grammar rules, and innovate with language. "
                };
        private string GetSpeech(int index)
        {
            return _speech[index];
        }
        public static void Menu(ref int userChoice)
        {
            Console.WriteLine("Welcome to Markov Chain Sentence Generator!\nYou can:\n1)Choose from few sentences\n2)Type your own\n3)Leave");
            while (userChoice < 1 || userChoice > 3)
            {
                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception)
                {
                    Console.WriteLine("You must enter one of this numbers: 1, 2, 3");
                }
            }
        }

        public static string ChooseSentence()
        {
            Console.WriteLine($"There are {_speech.Length} senteces. Choose sentences:");
            for(int i = 0; i < _speech.Length; i++)
            {
                Console.WriteLine($"Sentence {i}: {_speech[i]}");
            }
            int userChoice = -1;
            while(userChoice < 0 || userChoice >= _speech.Length)
            {
                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine($"Your number must not exceed limit: [0-{_speech.Length})");
                }
            }
            return _speech[userChoice];
        }
    }
}
