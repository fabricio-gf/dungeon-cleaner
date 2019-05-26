using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryManager : MonoBehaviour{
    public InventoryItem selectedItem;

    public GameObject[] objectPrefabs;
    public GameObject inventoryItem;

    RoundManager roundManager;

    public Transform myContentTransform = null;

    public bool removing = false;
    public Image removingEnableImage;

    private void Start() {
        roundManager = FindObjectOfType<RoundManager>();
    }

    public void ToggleRemove() {
        removing = !removing;
        removingEnableImage.enabled = removing;
        DeselectObject();
    }
    
    public void SelectObject(InventoryItem item){
        DeselectObject();
        if (removing) {
            ToggleRemove();
        }
        selectedItem = item;
    }

    public void DeselectObject(){
        if (selectedItem != null) selectedItem.DeselectItem();
        selectedItem = null;
    }

    public void PlaceObject(Transform t){
        Debug.Log("Instanciando no "+t.name + " o " + objectPrefabs[selectedItem.thisIndex].name);
        if (t.childCount == 0) {
            t.GetComponent<GridObject>().myInventoryItem = selectedItem;
            Instantiate(objectPrefabs[selectedItem.thisIndex], t);
            roundManager.setCurrentMatriz(t.GetSiblingIndex(), selectedItem.thisIndex);
            selectedItem.DisableItem();
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

        //procurar o proximo botão que possui index igual ao removido
    }

    public void InitializeInventory(List<int> objects)
    {
        int count = objects.Count;
        int randomIndex;
        GameObject obj;

        for (int i = 0; i < count; i++)
        {
            do
            {
                randomIndex = Random.Range(0, objects.Count);
            } while (objects[randomIndex] == -1);
            obj = Instantiate(inventoryItem, myContentTransform);
            obj.GetComponent<InventoryItem>().UpdateSprite(objects[randomIndex]);
            objects[randomIndex] = -1;
        }
    }
}
