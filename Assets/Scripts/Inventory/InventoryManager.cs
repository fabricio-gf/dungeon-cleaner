using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int selectedIndex;

    public GameObject[] objectPrefabs;
    public GameObject[] inventoryObjectPrefabs;

    RoundManager roundManager;

    public Transform contentTransform = null;

    public bool removing = false;
    private void Start() {
        roundManager = FindObjectOfType<RoundManager>();
    }

    public void ToggleRemove() {
        removing = !removing;
    }
    
    public void SelectObject(int index)
    {
        selectedIndex = index;
    }

    public void DeselectObject()
    {
        selectedIndex = -1;
    }

    public void PlaceObject(Transform t){
        Debug.Log("Instanciando no "+t.name + " o " + objectPrefabs[selectedIndex].name);
        if (t.childCount == 0) {
            Instantiate(objectPrefabs[selectedIndex],t);
            roundManager.setCurrentMatriz(t.GetSiblingIndex(), selectedIndex);
            DeselectObject();
        } else {
            Debug.Log("Tentando inserir numa tile cheia");
        }
    }

    public void RemoveObject(Transform t) {
        if (t.childCount > 0) {
            Destroy(t.GetChild(0).gameObject);
            ToggleRemove();
        }
        roundManager.setCurrentMatriz(t.GetSiblingIndex(), -1);
    }

    public void InitializeInventory(List<int> objects)
    {
        int count = objects.Count;
        int randomIndex;

        print("INITIAL ORDER " + objects[0] + objects[1] + objects[2]);

        for (int i = 0; i < count; i++)
        {
            do
            {
                randomIndex = Random.Range(0, objects.Count);
            } while (objects[randomIndex] == -1);
            Instantiate(inventoryObjectPrefabs[objects[randomIndex]], contentTransform);
            objects[randomIndex] = -1;
        }
    }
}
