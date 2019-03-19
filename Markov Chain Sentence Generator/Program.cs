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
            //Add any text in this variable
            string speech = "I have a vivid memory of what happened, and it was not what I expected. I expected to be applauded for my cleverness and arithmetic skills.";
            //Split sentences into words
            WordsProbability[] words = new WordsProbability[Regex.Split(speech, "\\W").Length];
            Markov_chain.BuildDictionary(words, speech);
            

            string newSentence = Markov_chain.MakeSentence(words);
            Console.WriteLine(newSentence);
            Console.ReadKey();
        }
    }
}
