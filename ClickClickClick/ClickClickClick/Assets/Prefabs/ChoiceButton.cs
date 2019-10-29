using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
   

    private void Start()
    {
        //This is to know when this button is clicked.
        GetComponent<Button>().onClick.AddListener(clicked);
    }
    void clicked()
    {
        //getting the text of the clicked button
        string ClickedButton = this.GetComponentInChildren<Text>().text;
        Debug.Log("clicked: "+ClickedButton); ;
        //notify choicemnu of what was clicked and clear the menu
        GetComponentInParent<ChoiceMenu>().clicked = ClickedButton;
        GetComponentInParent<ChoiceMenu>().ClearMenu();
    }
}
