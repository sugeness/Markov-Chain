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
            string speech = "I have a vivid memory of what happened, and it was not what I expected. I expected to be applauded for my cleverness and arithmetic skills.";
            WordsProbability[] words = new WordsProbability[Regex.Split(speech, "[., ]").Length];
            Markov_chain.BuildDictionary(words, speech);
           /* foreach(WordsProbability word in words)
            {
                
                Console.WriteLine($"Main word: {word._Word}");
                Dictionary<string, int> dictonary = word._Sequence;
                Dictionary<string, int> dictonary2 = word._Sequence;
                
                if (dictonary != null)
                foreach(KeyValuePair<string, int> keyValuePair in dictonary)
                {
                            Console.WriteLine($"Key: {keyValuePair.Key}\tValue: {keyValuePair.Value}");
                }
            }*/

            string newSentence = Markov_chain.MakeSentence(words);
            Console.WriteLine(newSentence);
            Console.ReadKey();
        }
    }
}
