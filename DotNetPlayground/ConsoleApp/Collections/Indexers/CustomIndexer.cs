namespace ConsoleApp.Collections.Indexers
{
    public class CustomIndexer
    {
        private readonly string[] words;

        public CustomIndexer(string[] words)
        {
            this.words = words;
        }

        public string this[int index]
        {
            get { return words[index]; }
            set { words[index] = value; }
        }
    }
}