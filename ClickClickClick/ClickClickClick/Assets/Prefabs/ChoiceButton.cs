using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
    

    // Start is called before the first frame update
    private void Start()
    {
        
        GetComponent<Button>().onClick.AddListener(clicked);
    }
    void clicked()
    {
        string ClickedButton = this.GetComponentInChildren<Text>().text;
        Debug.Log("clicked: "+ClickedButton); ;
        GetComponentInParent<ChoiceMenu>().clicked = ClickedButton;
        GetComponentInParent<ChoiceMenu>().ClearMenu();
    }
}
