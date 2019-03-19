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
            string[] words = Regex.Split(sentence, "[., ?!:]");
            List<int> usedWords = new List<int>();
            for (int i = 0; i < words.Length; i++)
            {
                if (usedWords.Contains(i))
                {
                    wordsInChain[i] = new WordsProbability("");
                    continue;
                }
                wordsInChain[i] = new WordsProbability(words[i]);
                for (int j = i + 1; j < words.Length - 1; j++)
                {
                    if(j == i + 1)
                    {
                        wordsInChain[i].SetSequence(words[j]);
                    }
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
            //string lastWord = "";

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
                    else
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
