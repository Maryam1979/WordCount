using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{

    static void Main()
    {
        string[] defaultFiles = { "file1.txt", "file2.txt" };

        Dictionary<string, int> wordCounts = new Dictionary<string, int>();

        foreach (string filePath in defaultFiles)
        {
            if (filePath is not null)
            {
                
               string text = File.ReadAllText(filePath);
               string[] words = text.Split(new char[] { ' ', '\t', '\n', '\r', '.', ',', '!', '?' },
                                            StringSplitOptions.RemoveEmptyEntries);

               foreach (string word in words)
                {
                    string cleanedWord = word.ToLower(); 
                    if (wordCounts.ContainsKey(cleanedWord))
                    {
                        wordCounts[cleanedWord]++;
                    }
                    else
                    {
                        wordCounts[cleanedWord] = 1;
                    }
                }
            }
            else
            {
                Console.WriteLine($"File not found: {filePath}");
            }
        }

              foreach (var entryword in wordCounts)
        {
            Console.WriteLine($"{entryword.Value}: {entryword.Key}");
        }
    }
}
