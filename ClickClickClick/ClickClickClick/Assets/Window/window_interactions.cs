using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class window_interactions : MonoBehaviour
{
    public PopUp popup; 
    

    public void ExitToOffice()
    {
        SceneManager.LoadScene("Office");
    }
    public void LookAtWindow()
    {
        Debug.Log("click on window");
        popup.ShowPopUp("Hmm.... Y fait-tu frette? On est-tu ben dans un cotton ouatté?");

    }
}
