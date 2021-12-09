using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BingoBoard
{
    private Vector2Int gridDimensions = new Vector2Int(5, 5);
    private List<BingoNumber> numberGrid = new List<BingoNumber>();
    private List<List<int>> winningIndices = new List<List<int>>()
    {
        new List<int>() {0, 1, 2, 3, 4 },
        new List<int>() {5, 6, 7, 8, 9 },
        new List<int>() {10, 11, 12, 13, 14 },
        new List<int>() {15, 16, 17, 18, 19 },
        new List<int>() {20, 21, 22, 23, 24 },
        new List<int>() {0, 5, 10, 15, 20 },
        new List<int>() {1, 6, 11, 16, 21 },
        new List<int>() {2, 7, 12, 17, 22 },
        new List<int>() {3, 8, 13, 18, 23 },
        new List<int>() {4, 9, 14, 19, 24 }
    };

    public BingoBoard(List<string> numbers)
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            List<string> numbersSplit = numbers[i].Split(' ').ToList();
            while (numbersSplit.Contains(""))
            {
                numbersSplit.Remove("");
            }

            for (int j = 0; j < numbersSplit.Count; j++)
            {
                numberGrid.Add(new BingoNumber(numbersSplit[j]));
            }
        }
    }

    public bool CrossNumber(string number)
    {
        BingoNumber hit = numberGrid.FirstOrDefault(x => x.GetNumber() == number);
        if (hit != null)
        {
            hit.CrossNumber();

            return CheckWin();
        }

        return false;
    }

    public int GetUncrossedTotal()
    {
        int total = 0;
        for (int i = 0; i < numberGrid.Count; i++)
        {
            if (!numberGrid[i].GetCrossed())
            {
                total += int.Parse(numberGrid[i].GetNumber());
            }
        }
        return total;
    }

    private bool CheckWin()
    {
        for (int i = 0; i < winningIndices.Count; i++)
        {
            if (CheckWinningIndices(winningIndices[i]))
            {
                return true;
            }
        }
        return false;
    }

    private bool CheckWinningIndices(List<int> indices)
    {
        for (int i = 0; i < indices.Count; i++)
        {
            if (!numberGrid[indices[i]].GetCrossed())
            {
                return false;
            }
        }
        return true;
    }
}
