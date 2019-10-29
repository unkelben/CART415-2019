using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceMenu : MonoBehaviour
{
    public GameObject ButtonPrefab;
    public string clicked = "";
    public bool active = false;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && active )
        {
            StartCoroutine(DelayedClear());
        }
    }
    IEnumerator DelayedClear()
    {
        yield return new WaitForSeconds(0.1f);
        if (clicked == "")
        {
            clicked = "nothing";
            ClearMenu();
        }
    }


    public void ShowChoices(List<string> choices)
    {
        clicked = "";
        foreach (string choice in choices)
        {
            GameObject newchoice = Instantiate(ButtonPrefab,this.transform);
            newchoice.GetComponentInChildren<Text>().text = choice;
            
            //newchoice.transform.SetParent(this.transform);
        }
        active = true;
    }

    public void ClearMenu()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        active = false;
    }


}
