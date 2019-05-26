using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public int currentRound = 1;
    //public int numberOfRoundsUntilDificultyRaise = 3;

    public int topGrade = 10;

    public int numberOfRows = 4;
    public int numberOfColumns = 5;

    public int numberOfObjects = 3;

    public int[,] gridMatrix;

    public float firstDelay = 5;

    // REFERENCES
    public MapManager mapManager = null;

    private void Start()
    {
        InitializeRound(currentRound);
    }

    public void InitializeRound(int round)
    {
        /*int sizeRaise = Mathf.FloorToInt((float)currentRound / (float)numberOfRoundsUntilDificultyRaise);
        numberOfRows = 4 + sizeRaise;
        numberOfColumns = 5 + sizeRaise;
        */
        //initialize grid on GUI
        //CHANGE SIZE OF GRID

        gridMatrix = new int[numberOfRows, numberOfColumns];
        gridMatrix = mapManager.PlaceObjects(numberOfObjects, numberOfRows, numberOfColumns);

        ShowRoomDelay();
    }

    public void EndRound()
    {
        int grade = CheckGrade();
        if(grade == 10)
        {
            // S GRADE
        }
        else if(grade >= 8 || grade<= 9)
        {
            // A GRADE
        }
        else if(grade >= 5 || grade< 8)
        {
            // B GRADE
        }
        else if(grade >= 0 || grade < 5)
        {
            // F GRADE
        }
    }

    private IEnumerator ShowRoomDelay()
    {
        yield return new WaitForSeconds(firstDelay);
        
    }

    private int CheckGrade()
    {
        int finalGrade = topGrade;
        //check distance
        //if not 0, reduce grade
        //if final grade less than X, lose
        //else, win
        return finalGrade;
    }
}
