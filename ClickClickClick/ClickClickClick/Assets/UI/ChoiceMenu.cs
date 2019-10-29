using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceMenu : MonoBehaviour
{
    public GameObject ButtonPrefab; //the buttonn prefab from whicih choices will be created
    public string clicked = ""; //the label of the button that was clicked
    public bool active = false;

    public void Update()
    {
        //This is stupid but it's there so the menu is cleared 
        // if you click anywhere in the screen
        // but we give a little time to see if we were actually clicking
        // on the the buttons
        if (Input.GetMouseButtonDown(0) && active )
        {
            StartCoroutine(DelayedClear());
        }
    }
    IEnumerator DelayedClear()
    {
        yield return new WaitForSeconds(0.1f);
        //if after .1 seconds no choice was registered we assume the user wanted to cancel
        //the choice
        if (clicked == "")
        {
            clicked = "nothing";
            ClearMenu();
        }
    }


    public void ShowChoices(List<string> choices)
    {
        clicked = "";
        //crawling through the list of choices and create a button for each
        foreach (string choice in choices)
        {
            GameObject newchoice = Instantiate(ButtonPrefab,this.transform);
            newchoice.GetComponentInChildren<Text>().text = choice;
            
        }
        active = true;
    }

    public void ClearMenu()
    {
        //clearing the menu is destroying all the children button
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        active = false;
    }


}
