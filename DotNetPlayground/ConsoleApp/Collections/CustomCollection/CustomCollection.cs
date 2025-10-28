using System.Collections;

namespace ConsoleApp.Collections.CustomCollection
{
    public class CustomCollection : IEnumerable
    {
        private readonly string[] words;

        public CustomCollection(string[] words)
        {
            this.words = words;
        }

        public IEnumerator GetEnumerator()
        {
            return new CustomEnumerator(words);
        }
    }
}