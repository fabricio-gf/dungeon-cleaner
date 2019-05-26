using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public int thisIndex = 0;
    public InventoryManager manager = null;

    public void Interact()
    {
        manager.SelectObject(thisIndex);
    }
}
