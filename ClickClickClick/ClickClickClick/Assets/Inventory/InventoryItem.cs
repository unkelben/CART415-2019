using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public string ItemName;
    // Start is called before the first frame update
    private void Start()
    {

        GetComponent<Button>().onClick.AddListener(clicked);
    }
    void clicked()
    {
        GetComponentInParent<InventoryManager>().SelectItem(ItemName);

    }


}
