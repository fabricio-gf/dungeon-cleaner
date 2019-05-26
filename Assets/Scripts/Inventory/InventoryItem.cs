using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public int thisIndex = 0;
    public InventoryManager inventoryManager = null;
    Image mRender;

    private void Start() {
        if (inventoryManager == null) {
            inventoryManager = FindObjectOfType<InventoryManager>();
        }
    }

    public void Interact()
    {
        inventoryManager.SelectObject(thisIndex);
    }

    public void UpdateSprite(int index)
    {
        thisIndex = index;
        if (mRender == null) mRender = transform.GetChild(0).GetComponent<Image>();
        if (inventoryManager == null) inventoryManager = FindObjectOfType<InventoryManager>();
        mRender.sprite = inventoryManager.objectPrefabs[index].GetComponent<Image>().sprite;
    }
}
