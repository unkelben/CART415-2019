using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Transform MatchesItem;
    public Text ItemLabel;
    public string CurrentItem = "";
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("matches", 1);
        UpdateInventory();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SelectItem("none");
        }
    }

    public void SelectItem(string ItemName)
    {
        CurrentItem = ItemName;
        ItemLabel.text = ItemName;
    }
    public void RemoveItem(string ItemName)
    {
        PlayerPrefs.SetInt(ItemName, 0);
        SelectItem("none");
        UpdateInventory();
    }

    public void UpdateInventory()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        if (PlayerPrefs.GetInt("matches")==1)
        {
            Instantiate(MatchesItem, this.transform);
        }
    }

}
