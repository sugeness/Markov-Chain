using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Markov_Chain_Sentence_Generator
{
    class Markov_chain
    {
        public static void BuildDictionary(WordsProbability[] wordsInChain, string sentence)
        {
            string[] words = Regex.Split(sentence, "\\W");
            //If programm encounters same word, it adds it number in this list
            List<int> usedWords = new List<int>();
            for (int i = 0; i < words.Length; i++)
            {
                //If this word is already in array, then current i is empty string and loop moves onto next i
                if (usedWords.Contains(i))
                {
                    wordsInChain[i] = new WordsProbability("");
                    continue;
                }

                wordsInChain[i] = new WordsProbability(words[i]);

                //Adds word after current into dictionary
                for (int j = i + 1; j < words.Length - 1; j++)
                {
                    if(j == i + 1)
                    {
                        wordsInChain[i].SetSequence(words[j]);
                    }
                    //if next word is already present add j into list
                    if (words[j].Equals(wordsInChain[i]._Word))
                    {
                        usedWords.Add(j);
                        wordsInChain[i].SetSequence(words[j + 1]);
                    }
                }             
                    
            }
        }

        public static string MakeSentence(WordsProbability[] words)
        {
            Random random = new Random();
            WordsProbability previousWord = new WordsProbability();
            bool end = false;
            int value = 0;
            int wordsInSentence = 0;
            string sentence = "";
            
            //First word is picked at random
            while (!end)
            {
                value = random.Next(words.Length);
                if (!words[value]._Word.Equals(""))
                {
                    sentence += words[value]._Word + " ";
                    previousWord = words[value];
                    wordsInSentence++;
                    end = true;
                }
            }

            for (int i = 0; i < words.Length; i++)
            {
                //In case the sentence is too big
                if (wordsInSentence >= words.Length / 2)
                    break;
                if (!previousWord._Word.Equals(words[i]._Word) & !words[i]._Word.Equals(""))
                {
                    Dictionary<string, int> previousWordDictonary = previousWord._Sequence;
                    if (!previousWordDictonary.Equals(null))
                    {
                        if (previousWordDictonary.Keys.Contains(words[i]._Word))
                        {
                            sentence += words[i]._Word + " ";
                            previousWord = words[i];
                            i = 0;                             
                            wordsInSentence++;
                        }
                    }
                    else //If dictionary is null then no word will come after current
                    {
                        break;
                    }
                }
            }
            return sentence;
        }

        private static bool EndSentece()
        {
            Random random = new Random();
            return random.Next() == 1;
        }
    }
}
