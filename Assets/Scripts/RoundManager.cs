﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    public Progress progress = null;
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
    public GameObject inventory = null;
    public BlackScreen blackScreen = null;
    public Countdown countdown = null;

    public GameObject EndingWindow = null;
    public Text RecordText1 = null;
    public Text RecordText2 = null;
    public GameObject RestartButton = null;

    private void Start()
    {
        InitializeRound(progress.currentProgress);
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

        numberOfObjects = 2 + round;
        gridMatrix = new int[numberOfRows, numberOfColumns];
        currentMatrix = new int[numberOfRows, numberOfColumns];
        for (int i = 0; i < numberOfRows; i++)
        {
            for (int j = 0; j < numberOfColumns; j++)
            {
                currentMatrix[i, j] = -1;
            }
        }
        gridMatrix = mapManager.PlaceObjects(numberOfObjects, numberOfRows, numberOfColumns);

        ShowRoomDelay();
    }

    public void setCurrentMatriz(int matrixIndex, int value)
    {
        print("index " + matrixIndex + " columns " + numberOfColumns);
        int row = Mathf.FloorToInt(matrixIndex / numberOfColumns);
        int col = matrixIndex % numberOfColumns;

        print("row " + row + " col " + col);
        print("current matriz " + currentMatrix.GetLength(0) + " " + currentMatrix.GetLength(1));
        currentMatrix[row, col] = value;
    }

    public void EndRound()
    {
        int grade = CheckGrade();
        if(grade == 10)
        {
            RecordText1.text = "S";
            RecordText2.text = "PERFECT SCORE! GOOD JOB!";
        }
        else if(grade >= 8 || grade<= 9)
        {
            RecordText1.text = "A";
            RecordText2.text = "You made it before the next adventuring group. Nice!";
        }
        else if(grade >= 5 || grade< 8)
        {
            RecordText1.text = "B";
            RecordText2.text = "You fixed barely enough things so no one notices. That was close...";
        }
        else if(grade >= 0 || grade < 5)
        {
            RecordText1.text = "F";
            RecordText2.text = "Oh no! The next group came and everything was a mess. The dungeon boss fired you for your incompetence.";
            RestartButton.SetActive(true);
        }
        EndingWindow.SetActive(true);
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
        List<int> objects = mapManager.RemoveObjects();
        inventory.SetActive(true);
        inventoryManager.InitializeInventory(objects);
    }

    public void StartCountdown()
    {
        blackScreen.afterFade -= StartCountdown;
        countdown.StartCountdown();
    }

    private int CheckGrade()
    {
        int finalGrade = topGrade;
        for(int i = 0; i < gridMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < gridMatrix.GetLength(1); j++)
            {
                if(gridMatrix[i,j] != -1)
                {
                    if(currentMatrix[i,j] != gridMatrix[i, j])
                    {
                        finalGrade--;
                    }
                }
                else
                {
                    if(currentMatrix[i,j] != -1)
                    {
                        finalGrade--;
                    }
                }
            }
        }
        return finalGrade;
    }
}
