using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] objectPrefabs;

    public Transform[] gridSpaces;

    public Transform[] solutionGridSpaces;

    private List<GameObject> objReferences = new List<GameObject>();

    private List<int> objectIndexes = new List<int>();

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

        objectIndexes.Clear();
        int randomRow = 0;
        int randomColumn = 0;
        for (int i = 0; i < numberOfObjects; i++)
        {
            do
            {
                randomRow = Random.Range(0, rows);
                randomColumn = Random.Range(0, columns);
            } while (gridMatrix[randomRow, randomColumn] != -1);

            gridMatrix[randomRow, randomColumn] = RandomizeObject();
            objectIndexes.Add(gridMatrix[randomRow, randomColumn]);

            InstantiateObject(gridMatrix[randomRow, randomColumn], randomRow, randomColumn);
        }

        return gridMatrix;
    }

    private void InstantiateObject(int objIndex, int row, int column)
    {
        GameObject obj = Instantiate(objectPrefabs[objIndex], gridSpaces[row * columns + column]);
        objReferences.Add(obj);
        Instantiate(objectPrefabs[objIndex], solutionGridSpaces[row * columns + column]);
    }

    public List<int> RemoveObjects()
    {
        for(int i = 0; i < objReferences.Count; i++)
        {
            Destroy(objReferences[i]);
        }
        objReferences.Clear();

        return objectIndexes;
    }

    private int RandomizeObject()
    {
        return Random.Range(0, objectPrefabs.Length); ;
    }
}
