using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSegment
{
    private Vector2Int start, end;

    public LineSegment(Vector2Int start, Vector2Int end)
    {
        this.start = start;
        this.end = end;
    }

    public List<Vector2Int> GetPointsOnLine()
    {
        List<Vector2Int> result = new List<Vector2Int>();
        int xIndex = start.x, yIndex = start.y;
        int tries = 0;
        while (yIndex != end.y || xIndex != end.x)
        {
            result.Add(new Vector2Int(xIndex, yIndex));
            if (end.x - start.x != 0)
            {
                xIndex += (end.x - start.x) / Mathf.Abs(end.x - start.x);
            }
            if (end.y - start.y != 0)
            {
                yIndex += (end.y - start.y) / Mathf.Abs(end.y - start.y);
            }
            tries++;
            if (tries == 1000)
            {
                Debug.Log("SOM TING WONG");
            }
        }
        result.Add(new Vector2Int(xIndex, yIndex));

        return result;
    }

    public bool IsOrthogonal()
    {
        return start.x == end.x || start.y == end.y;
    }
}
