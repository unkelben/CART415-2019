using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class office_interactions : MonoBehaviour
{
    public PopUp popup;
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
        if (ComputerIsOn==1)
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
    public void LookAtDrawings()
    {
        popup.ShowPopUp("Des criss de beaux dessins");
    }

    void SaveVars()
    {
        PlayerPrefs.SetInt("Office_ComputerIsOn", ComputerIsOn);
    }

}
