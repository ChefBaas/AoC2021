using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternfishBreeder : MonoBehaviour
{
    [SerializeField] private List<long> lanternFish = new List<long>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    // Start is called before the first frame update
    void Start()
    { 
        string[] input = InputHandler.GetRealInput("InputDay6.txt")[0].Split(',');
        for (int i = 0; i < input.Length;i++)
        {
            lanternFish[int.Parse(input[i])]++;
        }

        StartCoroutine(SimulateDays(256));
    }

    private IEnumerator SimulateDays(int days)
    {
        Debug.Log("Start");

        int daysStart = days;
        int speed = 1;

        while (days > 0)
        {
            List<long> newFish = new List<long>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < lanternFish.Count; i++)
            {
                if (i == 0)
                {
                    newFish[6] += lanternFish[i];
                    newFish[8] += lanternFish[i];
                }
                else
                {
                    newFish[i - 1] += lanternFish[i];
                }
            }
            
            lanternFish = newFish;

            days -= speed;

            yield return new WaitForEndOfFrame();
        }

        long total = 0;
        for (int i = 0; i < lanternFish.Count; i++)
        {
            total += lanternFish[i];
        }
        Debug.LogFormat("After {0} days there are {1} lantern fish", daysStart, total);
    }
}
