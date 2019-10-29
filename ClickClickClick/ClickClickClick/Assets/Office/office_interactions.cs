using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class office_interactions : MonoBehaviour
{
    public PopUp popup; //the text popup object in the scene (drag in the editor)
    public ChoiceMenu choicemenu; //the choicemenu object in the scene
    public InventoryManager inventory; //Inventory object in scene
    // scene variables
    public int ComputerIsOn = 0;

    public void Start()
    {
        if (PlayerPrefs.GetInt("Office_ComputerIsOn")==1)
        {
            TurnOnComputer();
            
        }

    }


    public void GotoWindow()
    {
        SaveVars();
        SceneManager.LoadScene("Window");
    }

    public void TurnOnComputer()
    {
        Debug.Log("click computer");
        //This is how you can check if the player currently has an item selected
        if (inventory.CurrentItem == "matches")
        {
            popup.ShowPopUp("I'm not burning my computer");
        }
        else
        {
            if (ComputerIsOn == 1)
            {
                GameObject.Find("screen").GetComponent<Image>().color = new Color(1, 1, 1, 0);
                ComputerIsOn = 0;
            }
            else
            {
                GameObject.Find("screen").GetComponent<Image>().color = new Color(1, 1, 1, 1);
                ComputerIsOn = 1;
            }
        }


        
    }
    public void LookAtDrawings()
    {
        Debug.Log("look at drawing");
        //To allow for waiting for user, we need to call a coroutine for the choice menu
        StartCoroutine(LookAtDrawingsChoices());

    }
    IEnumerator LookAtDrawingsChoices()
    {
        //this is how you prepare a choice menu
        //create a list of strings, then add the items
        List<string> choices = new List<string>();
        choices.Add("lookat");
        choices.Add("remove");

        //then call the showchoice functino from choicemenu
        choicemenu.ShowChoices(choices);
        
        //Waiting for somethig to be clicked
        while (choicemenu.clicked == "")
        {
            yield return new WaitForSeconds(0.1f);
        }
        Debug.Log(choicemenu.clicked);

        //control what was clicked this way, use the same labels you used earlier
        if (choicemenu.clicked == "lookat")
        {
            popup.ShowPopUp("des beaux dessins");
        }
        if (choicemenu.clicked == "remove")
        {
            popup.ShowPopUp("Je les enlève pas, calvaire.");
        }
    }

    public void ClickOnBags()
    {
        //how to remove an inventory item

        if (inventory.CurrentItem == "matches")
        {
            popup.ShowPopUp("I'll put the matches in the bag");
            inventory.RemoveItem("matches");
        }
    }
    void SaveVars()
    {
        PlayerPrefs.SetInt("Office_ComputerIsOn", ComputerIsOn);
    }

}
