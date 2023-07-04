using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OnlineCanvas : MonoBehaviour
{
    public InputField nameinput;
    public GameObject panel;

    public void connectandstart()
    {
      
        PlayerPrefs.SetString("name", nameinput.text);


        panel.SetActive(false);

    }

}
