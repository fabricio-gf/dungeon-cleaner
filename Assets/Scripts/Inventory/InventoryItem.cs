using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public int thisIndex = 0;
    public InventoryManager inventoryManager = null;

    public void Interact()
    {
        inventoryManager.SelectObject(thisIndex);
    }
}
