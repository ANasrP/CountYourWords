namespace MyUnitTestProject;

using System.Collections.Generic;
using Xunit;


public class WordProcessorTests
{
    [Fact]
    public void ExtractWordsTest()
    {
        var processor = new WordFormatter();
        var inputChars = new List<char>("why is that thing still there! why".ToCharArray());

        var words = processor.ExtractWordsFromInput(inputChars);

        var expected = new List<string> { "why", "is", "that", "thing", "still", "there", "why" };
        Assert.Equal(expected, words);
    }

    [Fact]
    public void CountTest()
    {
        var processor = new WordFormatter();
        var words = new List<string> { "house", "table", "fork", "spoon", "morocco", "fork", "table", "table"};

        var counts = processor.CountOccurrences(words);

        Assert.Equal(3, counts["table"]);
        Assert.Equal(1, counts["house"]);
        Assert.Equal(2, counts["fork"]);
        Assert.Equal(1, counts["spoon"]);
        Assert.Equal(1, counts["morocco"]);
    }

    [Fact]
    public void SortAlphaTest()
    {
        var processor = new WordFormatter();
        var words = new string[] { "cristiano", "ronaldo", "aveiro" };

        processor.SortAlphabetically(words);

        var expected = new string[] { "aveiro", "cristiano", "ronaldo" };
        Assert.Equal(expected, words);
    }
}
