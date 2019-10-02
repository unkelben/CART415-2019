using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public Text PopUpText;

    public void ShowPopUp(string text)
    {
        gameObject.SetActive(true);
        PopUpText.text = text;

    }
    public void HidePopUp()
    {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
