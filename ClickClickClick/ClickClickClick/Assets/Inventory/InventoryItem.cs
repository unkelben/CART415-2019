using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public string ItemName; //Type in the name of the item in the editor

    private void Start()
    {
        //Adding the event for when this item is cliecked
        GetComponent<Button>().onClick.AddListener(clicked);
    }
    void clicked()
    {
        //Calls the inventory manager "select item" function with the name of this item.
        GetComponentInParent<InventoryManager>().SelectItem(ItemName);

    }


}
