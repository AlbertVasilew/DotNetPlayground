namespace ConsoleApp.Collections.Indexers
{
    public class PairOfArrays<TLeft, TRight>
    {
        private readonly TLeft[] _left;
        private readonly TRight[] _right;

        public PairOfArrays(TLeft[] left, TRight[] right)
        {
            _left = left;
            _right = right;
        }

        public (TLeft, TRight) this[int index1, int index2]
        {
            get
            {
                return (_left[index1], _right[index2]);
            }
            set
            {
                _left[index1] = value.Item1;
                _right[index2] = value.Item2;
            }
        }
    }
}