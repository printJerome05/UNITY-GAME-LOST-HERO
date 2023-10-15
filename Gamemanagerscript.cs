using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanagerscript : MonoBehaviour
{
    public GameObject gameOverUI;
   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOver()
    {
        // showing the canvas pannel in unit "GameOver"
        
        gameOverUI.SetActive(true);
    }
    public void Restart()
    {
        //for future use SceneManager.LoadScene("SampleScene");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   

    

    public void mainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
