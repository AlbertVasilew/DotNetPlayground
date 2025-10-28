using ConsoleApp.Collections.CustomCollection;
using ConsoleApp.Collections.CustomCollectionWithInitializer;
using ConsoleApp.Collections.Indexers;

var customEnumerableCollection = new CustomCollection(["aaa", "bbb", "ccc"]);
var customEnumerableCollectionInitializer = new CustomCollectionWithInitializer { "aaa", "bbb", "ccc" };

var enumerator = customEnumerableCollection.GetEnumerator();
var enumeratorInitializer = customEnumerableCollectionInitializer.GetEnumerator();

while (enumerator.MoveNext())
{
    Console.WriteLine(enumerator.Current);
}

while (enumeratorInitializer.MoveNext())
{
    Console.WriteLine(enumeratorInitializer.Current);
}

// Collections -> Indexers -> PairOfArrays

var ints = new int[] { 1, 2, 3 };
var strings = new string[] { "a", "b", "c" };

var valueTuples = new PairOfArrays<int, string>(ints, strings);

var result = valueTuples[2, 1];

Console.WriteLine(result);

// Collections -> Indexers -> CustomIndexer

var customIndexer = new CustomIndexer(["a", "b", "c"]);
var firstString = customIndexer[1];

Console.WriteLine(firstString);

// Ref

var number = 1;
void AddToNumber(ref int number) => number++;
AddToNumber(ref number);

Console.WriteLine(number);

// Out

void ProduceText(out string text) => text = "Some text";
ProduceText(out var produced);
Console.WriteLine(produced);