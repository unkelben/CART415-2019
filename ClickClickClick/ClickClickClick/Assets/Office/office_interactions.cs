using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class office_interactions : MonoBehaviour
{
    public PopUp popup;
    public ChoiceMenu choicemenu;
    public InventoryManager inventory;
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
        StartCoroutine(LookAtDrawingsChoices());

    }
    IEnumerator LookAtDrawingsChoices()
    {
        List<string> choices = new List<string>();
        choices.Add("lookat");
        choices.Add("remove");
        choicemenu.ShowChoices(choices);
        Debug.Log("waiting for choices");
        while (choicemenu.clicked == "")
        {
            yield return new WaitForSeconds(0.1f);
        }
        Debug.Log(choicemenu.clicked);
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
