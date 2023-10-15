using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationWindow : MonoBehaviour
{
    public GameObject Confirmpanel;
    public GameObject CreditsPanel;
    public void openpanel()
    {
       Confirmpanel.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("clicked");
    }
    public void closepanel()
    {
        Confirmpanel.SetActive(false);
        Time.timeScale = 0f;
        Debug.Log("returned");

    }


    public void opencreds()
    {
        CreditsPanel.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("clicked");
    }
    public void closecreds()
    {
        CreditsPanel.SetActive(false);
        Time.timeScale = 0f;
        Debug.Log("closed");
    }
}