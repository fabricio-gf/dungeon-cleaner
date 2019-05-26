using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public int topGrade = 10;

    public int numberOfRows = 4;
    public int numberOfColumns = 5;

    public int numberOfObjects = 3;

    public int[,] gridMatrix;

    // REFERENCES
    public MapManager mapManager = null;

    private void Start()
    {
        InitializeRound();
    }

    public void InitializeRound()
    {
        gridMatrix = new int[numberOfRows, numberOfColumns];
        gridMatrix = mapManager.PlaceObjects(numberOfObjects, numberOfRows, numberOfColumns);

        print("INITIALIZED");
    }

    public void EndRound()
    {

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
