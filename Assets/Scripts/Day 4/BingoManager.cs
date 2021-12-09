using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BingoManager : MonoBehaviour
{
    private List<string> input;
    private List<string> numbers = new List<string>();
    private List<BingoBoard> boards = new List<BingoBoard>();

    // Start is called before the first frame update
    void Start()
    {
        input = InputHandler.GetRealInput("InputDay4.txt");
        FillNumbersList();
        BuildBoards();
        PlayGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FillNumbersList()
    {
        string[] numbersSplit = input[0].Split(',');
        for (int i = 0; i < numbersSplit.Length; i++)
        {
            numbers.Add(numbersSplit[i]);
        }
    }

    private void BuildBoards()
    {
        List<string> boardValues = new List<string>();
        for (int i = 1; i < input.Count; i++)
        {
            if (i % 6 == 1)
            {
                boardValues = new List<string>();
                continue;
            }

            boardValues.Add(input[i]);

            if (i % 6 == 0)
            {
                boards.Add(new BingoBoard(boardValues));   
            }
        }
    }

    private void PlayGame()
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            List<BingoBoard> boardsToRemove = new List<BingoBoard>();
            for (int j = 0; j < boards.Count; j++)
            {
                if (boards[j].CrossNumber(numbers[i]))
                {
                    boardsToRemove.Add(boards[j]);
                }
            }
            for (int j = 0; j < boardsToRemove.Count; j++)
            {
                boards.Remove(boardsToRemove[j]);
                if (boards.Count == 0)
                {
                    Debug.LogFormat("Board {0} finally finished after {1} was drawn. It took {2} draws", j, numbers[i], i);
                    HandleLastBoard(int.Parse(numbers[i]), boardsToRemove[0]);
                    return;
                }
            }
        }
    }

    private void HandleLastBoard(int lastNumber, BingoBoard lastBoard)
    {
        Debug.LogFormat("Score is {0}", lastNumber * lastBoard.GetUncrossedTotal());
    }
}
