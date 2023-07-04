using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitName : MonoBehaviour
{
    public string playerName;
    public InputField nameInput;
    public Text nameText;



   public void submit()
    {
        playerName = nameInput.text;
        PlayerPrefs.SetString("name", playerName);
        
        
    }
    void Update()
    {
        nameText.text = PlayerPrefs.GetString("name");
    }
}
