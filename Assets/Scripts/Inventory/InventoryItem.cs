using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public int thisIndex = 0;
    public InventoryManager manager = null;

    private void Start() {
        if (manager == null) {
            manager = FindObjectOfType<InventoryManager>();
        }
    }

    public void Interact()
    {
        manager.SelectObject(thisIndex);
    }
}
