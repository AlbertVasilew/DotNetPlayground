using System.Collections;

namespace ConsoleApp.Collections.CustomCollection
{
    public class CustomEnumerator : IEnumerator
    {
        private const int initialPosition = -1;
        private readonly string[] words;
        private int currentPosition = initialPosition;

        public CustomEnumerator(string[] words)
        {
            this.words = words;
        }

        public object Current => words[currentPosition];

        public bool MoveNext()
        {
            currentPosition++;
            return currentPosition < words.Length;
        }

        public void Reset()
        {
            currentPosition = initialPosition;
        }
    }
}