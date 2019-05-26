﻿using System.Collections;
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
    public int[,] currentMatrix;

    public float firstDelay = 5;

    // REFERENCES
    public MapManager mapManager = null;
    public InventoryManager inventoryManager = null;
    public BlackScreen blackScreen = null;
    public Countdown countdown = null;

    private void Start()
    {
        InitializeRound(currentRound);
        blackScreen.EndFade();
        StartCoroutine(ShowRoomDelay());
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
        currentMatrix = new int[numberOfRows, numberOfColumns];
        for (int i = 0; i < numberOfRows; i++) {
            for (int j = 0; j < numberOfColumns; j++) {
                currentMatrix[i, j] = -1;
            }
        }
        gridMatrix = mapManager.PlaceObjects(numberOfObjects, numberOfRows, numberOfColumns);

        ShowRoomDelay();
    }

    public void setCurrentMatriz(int matrixIndex, int value) {
        int row = matrixIndex / numberOfRows;
        int col = matrixIndex % numberOfColumns;

        currentMatrix[row, col] = value;
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
        blackScreen.duringFade += CleanRoom;
        blackScreen.afterFade += StartCountdown;
        blackScreen.StartFade();
    }

    public void CleanRoom()
    {
        blackScreen.duringFade -= CleanRoom;
        mapManager.RemoveObjects();
        inventoryManager.InitializeInventory();
    }

    public void StartCountdown()
    {
        blackScreen.afterFade -= StartCountdown;
        countdown.StartCountdown();
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
