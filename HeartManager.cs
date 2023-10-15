using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfheart;
    public Sprite emptyheart;
    public FloatValue heartContainers;
    public FloatValue playerCurrentHealth;

    public Inventory inv;
  


    //for game over >>
    public Gamemanagerscript gameManager;
  
    private bool isDead;



    // Start is called before the first frame update

    void Start()
    {
        InitHearts();
    }
    void Update()
    {
      if(playerCurrentHealth.RuntimeValue > 6)
        {
            playerCurrentHealth.RuntimeValue = 6;
        }
    }
    private void Awake()
    {
        playerCurrentHealth.RuntimeValue = 6;
       


    }
    



    public void InitHearts()
    {
        for(int i = 0; i < heartContainers.RuntimeValue; i++ )
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }
    public void UpdateHearts()
    {
        InitHearts();
        float tempHealth = playerCurrentHealth.RuntimeValue / 2;
        for (int i = 0; i < heartContainers.RuntimeValue; i ++)
        {
           
            if (i <= tempHealth -1)
            {
                // full heart
                hearts[i].sprite = fullHeart;
            }else if( i >= tempHealth)
            {
                //halfheart
                hearts[i].sprite = halfheart;

            }
            else
            {
                //emptyheart
                hearts[i].sprite = emptyheart;
              
            }

        }

        //gameover mechanics temp health for the actual healtbar
        if (tempHealth <= 0 && !isDead)
        {
            
            isDead = true;
            InitHearts();
            gameManager.gameOver();
            SoundManager.PlaySound("gameOver");
            Debug.Log("dead");
           

        }
       
    }
    }

