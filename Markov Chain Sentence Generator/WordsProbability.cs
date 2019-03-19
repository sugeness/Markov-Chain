using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markov_Chain_Sentence_Generator
{
    struct WordsProbability
    {
        public string _Word
        {
            get;
        }

        public Dictionary<string, int> _Sequence
        {
            get;
        }
        public void SetSequence(string word)
        {
            if (!_Sequence.ContainsKey(word))
                _Sequence.Add(word, 1);
            else
                AddRepeats(word);
        }

        private void AddRepeats(string word)
        {
            _Sequence[word]++;
        }
       
        public WordsProbability(string word)
        {
            _Word = word;
            _Sequence = new Dictionary<string, int>();
        }
    }
}
