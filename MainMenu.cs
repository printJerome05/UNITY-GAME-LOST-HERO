using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NewGame()
    {
        PlayerPrefs.DeleteKey("p_x");
        PlayerPrefs.DeleteKey("p_y");
        PlayerPrefs.DeleteKey("TimeToLoad");
        PlayerPrefs.DeleteKey("Saved");
        SceneManager.LoadScene("Intro");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Forest");
    }

    public void QuitToDesktop()
    {
        Application.Quit();
    }
    public void loadsaveare()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void loadmainarea()
    {
        SceneManager.LoadScene("Main");
    }
    public void loadmainarea3()
    {
        SceneManager.LoadScene("Main3");
    }

    public void loadmainarea6()
    {
        SceneManager.LoadScene("Main6");
    }

    public void loadmainarea10()
    {
        SceneManager.LoadScene("Main10");
    }

    public void loadmainarea13()
    {
        SceneManager.LoadScene("Main13");
    }
    
    public void loadending1()
    {
        SceneManager.LoadScene("ENDING1");
    }

    public void tutorialGun()
    {
        SceneManager.LoadScene("TutorialGun");
    }



    public void loadFindbattle()
    {
        SceneManager.LoadScene("FINDBATTLE");
    }

}
