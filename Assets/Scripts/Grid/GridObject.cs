using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    InventoryManager inventoryManager;

    private void Start() {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    public void Interact()
    {
        if (inventoryManager.removing){
            inventoryManager.RemoveObject(transform);
        } else if (inventoryManager.selectedIndex >= 0) {
            inventoryManager.PlaceObject(transform);
        }

    }
}
