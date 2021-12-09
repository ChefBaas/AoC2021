using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentScanner : MonoBehaviour
{
    private List<string> input;
    private List<List<int>> ventGrid = new List<List<int>>();
    private List<LineSegment> ventLines = new List<LineSegment>();
    private int overlappingPoints = 0;
    
    void Start()
    {
        input = InputHandler.GetRealInput("InputDay5.txt");
        CreateVentLines();
        DetermineVentGrid();
        Debug.LogFormat("There are {0} overlapping points", overlappingPoints);
        // PrintGrid();
    }

    private void CreateVentLines()
    {
        for (int i = 0; i < input.Count; i++)
        {
            string[] coordinates = input[i].Split(new string[] { " -> " }, StringSplitOptions.None);
            int x1 = int.Parse(coordinates[0].Split(',')[0]);
            int y1 = int.Parse(coordinates[0].Split(',')[1]);
            int x2 = int.Parse(coordinates[1].Split(',')[0]);
            int y2 = int.Parse(coordinates[1].Split(',')[1]);
            ventLines.Add(new LineSegment(new Vector2Int(x1, y1), new Vector2Int(x2, y2)));
        }
    }

    private void DetermineVentGrid()
    {
        for (int i = 0; i < ventLines.Count; i++)
        {
            // if (ventLines[i].IsOrthogonal())
            {
                List<Vector2Int> ventPositions = ventLines[i].GetPointsOnLine();
                for (int j = 0; j < ventPositions.Count; j++)
                {
                    Vector2Int coordinate = ventPositions[j];
                    int tries = 0;
                    while (ventGrid.Count <= coordinate.y)
                    {
                        ventGrid.Add(new List<int>());
                        tries++;
                        if (tries > 1000)
                        {
                            Debug.Log("SOM TING WONG");
                            break;
                        }
                    }
                    if (ventGrid[coordinate.y] == null)
                    {
                        ventGrid[coordinate.y] = new List<int>();
                    }
                    tries = 0;
                    while (ventGrid[coordinate.y].Count <= coordinate.x)
                    {
                        ventGrid[coordinate.y].Add(0);
                        if (tries > 1000)
                        {
                            Debug.Log("SOM TING WONG");
                            break;
                        }
                    }
                    ventGrid[coordinate.y][coordinate.x]++;
                    if (ventGrid[coordinate.y][coordinate.x] == 2)
                    {
                        overlappingPoints++;
                    }
                }
            }
        }
    }

    private void PrintGrid()
    {
        string result = "";
        for (int i = 0; i < ventGrid.Count; i++)
        {
            for (int j = 0; j < ventGrid[i].Count; j++)
            {
                if (j != ventGrid[i].Count - 1)
                {
                    result += string.Format("{0} ", ventGrid[i][j]);
                }
                else
                {
                    result += ventGrid[i][j];
                }
            }
            result += "\n\n";
        }

        Debug.Log(result);
    }
}