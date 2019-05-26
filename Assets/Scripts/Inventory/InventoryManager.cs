using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int selectedIndex;

    public GameObject[] objectPrefabs;

    RoundManager roundManager;

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
        if (t.childCount ==0) {
            Instantiate(objectPrefabs[selectedIndex],t);
            roundManager.setCurrentMatriz(t.GetSiblingIndex(), selectedIndex);
        } else {
            Debug.Log("Tentando inserir numa tile cheia");
        }
    }

    public void RemoveObject(Transform t) {
        if (t.childCount > 0) {
            Destroy(t.GetChild(0).gameObject);
        }
        roundManager.setCurrentMatriz(t.GetSiblingIndex(), -1);
    }

    public void InitializeInventory()
    {
        print("initalize inventory");
    }
}
