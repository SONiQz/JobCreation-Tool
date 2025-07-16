using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static List<string> DirectoriesToCreate()
{
    string filePath = "Directories.txt"; // Change to full path if needed

    if (!File.Exists(filePath))
        throw new FileNotFoundException($"Could not find the file: {filePath}");

    // Read lines and filter out comments and empty entries
    var directories = File.ReadLines(filePath)
                          .Where(line => !string.IsNullOrWhiteSpace(line))     // Remove blank lines
                          .Where(line => !line.TrimStart().StartsWith("#"))    // Skip lines starting with '#'
                          .Where(line => !line.TrimStart().StartsWith("//"))   // Skip lines starting with '//'
                          .ToList();

    return directories;
}
