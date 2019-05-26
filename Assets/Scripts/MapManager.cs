using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] objectPrefabs;

    public Transform[] gridSpaces;

    private List<GameObject> objReferences = new List<GameObject>();

    int rows;
    int columns;

    public int[,] PlaceObjects(int numberOfObjects, int numberOfRows, int numberOfColumns)
    {
        rows = numberOfRows;
        columns = numberOfColumns;

        int[,] gridMatrix = new int[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                gridMatrix[i, j] = -1;
            }
        }

        int randomRow = 0;
        int randomColumn = 0;
        for (int i = 0; i < numberOfObjects; i++)
        {
            do
            {
                randomRow = Random.Range(0, rows - 1);
                randomColumn = Random.Range(0, columns - 1);
            } while (gridMatrix[randomRow, randomColumn] != -1);

            gridMatrix[randomRow, randomColumn] = RandomizeObject();

            InstantiateObject(gridMatrix[randomRow, randomColumn], randomRow, randomColumn);
        }

        return gridMatrix;
    }

    private void InstantiateObject(int objIndex, int row, int column)
    {
        GameObject obj = Instantiate(objectPrefabs[objIndex], gridSpaces[row * columns + column]);
        objReferences.Add(obj);
    }

    public void RemoveObjects()
    {
        for(int i = 0; i < objReferences.Count; i++)
        {
            Destroy(objReferences[i]);
        }
        objReferences.Clear();
    }

    private int RandomizeObject()
    {
        return Random.Range(0, objectPrefabs.Length-1);
    }
}
