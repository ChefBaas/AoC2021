using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class InputHandler
{
    public static List<string> GetRealInput(string fileName)
    {
        return File.ReadLines("C:\\Users\\rab_t\\OneDrive\\Documenten\\Personal Projects\\Advent of Code 2021\\Input\\" + fileName).ToList();
    }

    public static List<string> GetTestInput(string fileName)
    {
        return File.ReadLines("C:\\Users\\rab_t\\OneDrive\\Documenten\\Personal Projects\\Advent of Code 2021\\TestInput\\" + fileName).ToList();
    }
}
