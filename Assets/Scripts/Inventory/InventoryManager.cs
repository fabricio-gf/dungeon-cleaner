using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    GameObject selectedObject;

    public GameObject[] objectPrefabs;

    public void SelectObject(int index)
    {
        selectedObject = objectPrefabs[index];
    }

    public void DeselectObject()
    {
        selectedObject = null;
    }

    public void PlaceObject(int index)
    {

    }

    public void InitializeInventory()
    {
        print("initalize inventory");
    }
}
