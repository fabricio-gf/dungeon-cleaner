using System.Collections;
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
    [Header("References")]
    public MapManager mapManager = null;
    public InventoryManager inventoryManager = null;
    public GameObject inventory = null;
    public BlackScreen blackScreen = null;
    public Countdown countdown = null;
    public GameObject Janitor = null;

    [Header("Ending Window")]
    public GameObject EndingObject = null;
    public Text RecordText1 = null;
    public Text RecordText2 = null;
    public GameObject RestartButton = null;
    public GameObject EndingWindow = null;

    [Header("Colors")]
    public Color[] EndingColors;

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

        if (numberOfRows * numberOfColumns >= 2 + round) numberOfObjects = 2 + round;
        else numberOfObjects = numberOfColumns * numberOfRows;
        
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

        //ShowRoomDelay();
    }

    public void setCurrentMatriz(int matrixIndex, int value)
    {
        int row = Mathf.FloorToInt(matrixIndex / numberOfColumns);
        int col = matrixIndex % numberOfColumns;

        currentMatrix[row, col] = value;
    }

    public void EndRound()
    {
        int grade = CheckGrade();
        print("grade " + grade);
        if(grade == 10)
        {
            RecordText1.text = "S";
            RecordText1.color = EndingColors[0];
            RecordText2.text = "PERFECT SCORE! GOOD JOB!";
        }
        else if(grade >= 8 && grade<= 9)
        {
            RecordText1.text = "A";
            RecordText1.color = EndingColors[1];
            RecordText2.text = "You made it before the next adventuring group. Nice!";
        }
        else if(grade >= 5 && grade< 8)
        {
            RecordText1.text = "B";
            RecordText1.color = EndingColors[2];
            RecordText2.text = "You fixed barely enough things so no one notices. That was close...";
        }
        else if(grade >= 0 && grade < 5)
        {
            RecordText1.text = "F";
            RecordText1.color = EndingColors[3];
            RecordText2.text = "Oh no! The next group came and everything was a mess. The dungeon boss fired you for your incompetence.";
            RestartButton.SetActive(true);
        }
        EndingObject.SetActive(true);
    }

    private IEnumerator ShowRoomDelay()
    {
        yield return new WaitForSeconds(firstDelay);
        blackScreen.duringFade += CleanRoom;
        blackScreen.afterFade += JanitorCutscene;
        blackScreen.StartFade();
    }

    public void CleanRoom()
    {
        blackScreen.duringFade -= CleanRoom;
        List<int> objects = mapManager.RemoveObjects();
        inventory.SetActive(true);
        inventoryManager.InitializeInventory(objects);
    }

    public void JanitorCutscene()
    {
        blackScreen.afterFade -= JanitorCutscene;
        Janitor.SetActive(true);
        StartCoroutine(JanitorCoroutine());
    }

    IEnumerator JanitorCoroutine()
    {
        yield return new WaitForSeconds(2.4f);
        blackScreen.duringFade += DeleteJanitor;
        blackScreen.afterFade += StartCountdown;
        blackScreen.StartFade();
    }

    public void DeleteJanitor()
    {
        blackScreen.duringFade -= DeleteJanitor;
        Janitor.SetActive(false);
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
                    if (currentMatrix[i,j] != gridMatrix[i, j])
                    {
                        finalGrade--;
                    }
                }
                else
                {
                    if (currentMatrix[i,j] != -1)
                    {
                        finalGrade--;
                    }
                }
            }
        }
        return finalGrade;
    }

    public void ToggleHideEndingWindow()
    {
        EndingWindow.SetActive(!EndingWindow.activeSelf);
    }
}
