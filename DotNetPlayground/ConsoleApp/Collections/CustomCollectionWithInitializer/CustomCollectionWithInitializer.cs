using System.Collections;
using ConsoleApp.Collections.CustomCollection;

namespace ConsoleApp.Collections.CustomCollectionWithInitializer
{
    public class CustomCollectionWithInitializer : IEnumerable
    {
        private readonly string[] words;
        private int currentPosition = -1;

        public CustomCollectionWithInitializer()
        {
            words = new string[10];
        }

        public void Add(string word)
        {
            currentPosition++;
            words[currentPosition] = word;
        }

        public IEnumerator GetEnumerator()
        {
            return new CustomEnumerator(words);
        }
    }
}