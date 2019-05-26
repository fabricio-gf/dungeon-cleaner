using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public InventoryItem myInventoryItem;

    public void Interact()
    {
        if (inventoryManager == null) {
            inventoryManager = FindObjectOfType<InventoryManager>();
        }
        if (inventoryManager.removing){
            if (myInventoryItem != null) {
                myInventoryItem.EnableItem();
                myInventoryItem = null;
            }
            inventoryManager.RemoveObject(transform);
        } else if (inventoryManager.selectedItem != null) {
            inventoryManager.PlaceObject(transform);
        }
    }
}
