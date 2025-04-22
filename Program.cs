class WordFormatter
{


    public List<string> ExtractWordsFromInput(List<char> allChars)
    {
        var words = new List<string>();
        var currentWord = new List<char>();

        foreach (char c in allChars)
        {
            if (Char.IsLetter(c))
            {
                currentWord.Add(Char.ToLower(c));
            }
            else
            {
                if (currentWord.Count > 0)
                {
                    words.Add(new string(currentWord.ToArray()));
                    currentWord.Clear();
                }
            }
        }
        if (currentWord.Count > 0)
        {
            words.Add(new string(currentWord.ToArray()));
        }

        return words;
    }

    public Dictionary<string, int> CountOccurrences(List<string> words)
    {
        var dict = new Dictionary<string, int>();
        foreach (var word in words)
        {
            if (dict.ContainsKey(word))
            {
                dict[word]++;
            }
            else
            {
                dict[word] = 1;
            }
        }
        return dict;
    }

    public void SortAlphabetically(string[] words)
    {
        for (int i = 1; i < words.Length; i++)
        {
            string key = words[i];
            int j = i - 1;
            while (j >= 0 && words[j].CompareTo(key) > 0)
            {
                words[j + 1] = words[j];
                j--;
            }
            words[j + 1] = key;
        }
    }
}

class CountYourWords
{
    static void Main()
    {
        try
        {
            StreamReader objReader = new StreamReader("input.txt");
            List<char> fileChars = new List<char>();
            int readChar;

            while ((readChar = objReader.Read()) != -1)
            {
                fileChars.Add((char)readChar);
            }

            objReader.Close();

            var processor = new WordFormatter();
            var words = processor.ExtractWordsFromInput(fileChars);
            var counts = processor.CountOccurrences(words);

            string[] uniqueWords = new string[counts.Count];
            counts.Keys.CopyTo(uniqueWords, 0);

            processor.SortAlphabetically(uniqueWords);

            Console.WriteLine($"Total words: {words.Count}");

            foreach (var word in uniqueWords)
            {
                Console.WriteLine($"{word} {counts[word]}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
