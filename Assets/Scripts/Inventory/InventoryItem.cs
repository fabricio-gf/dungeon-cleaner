using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public int thisIndex = 0;
    public InventoryManager inventoryManager = null;

    private void Start() {
        if (inventoryManager == null) {
            inventoryManager = FindObjectOfType<InventoryManager>();
        }
    }

    public void Interact()
    {
        inventoryManager.SelectObject(thisIndex);
    }
}
