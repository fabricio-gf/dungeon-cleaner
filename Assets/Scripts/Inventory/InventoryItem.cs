using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public int thisIndex = 0;
    public InventoryManager inventoryManager = null;
    [SerializeField] Image disableImage;
    [SerializeField] Image selectImage;
    Image mRender;

    private void Start() {
        if (inventoryManager == null) {
            inventoryManager = FindObjectOfType<InventoryManager>();
        }
    }

    public void Interact()
    {
        if (disableImage.enabled) {
            return;
        }
        inventoryManager.SelectObject(this);
        SelectItem();
    }

    public void UpdateSprite(int index)
    {
        thisIndex = index;
        if (mRender == null) mRender = transform.GetChild(0).GetComponent<Image>();
        if (inventoryManager == null) inventoryManager = FindObjectOfType<InventoryManager>();
        mRender.sprite = inventoryManager.objectPrefabs[index].GetComponent<Image>().sprite;
    }

    public void SelectItem() {
        selectImage.enabled = true; 
    }

    public void DeselectItem() {
        selectImage.enabled = false;
    }

    public void DisableItem() {
        disableImage.enabled = true;
        selectImage.enabled = false;
    }

    public void EnableItem() {
        disableImage.enabled = false;
        selectImage.enabled = false;
    }
}
