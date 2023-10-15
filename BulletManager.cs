using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletManager : MonoBehaviour
{
    public Slider bulletSlider;
    public Inventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        bulletSlider.maxValue = playerInventory.maxBullet;
        bulletSlider.value = playerInventory.maxBullet;
        playerInventory.currentBullet = playerInventory.maxBullet;
    }

    public void AddBullet()
    {
        bulletSlider.value += 1;
        playerInventory.currentBullet += 1;
        if (bulletSlider.value > bulletSlider.maxValue)
        {
            bulletSlider.value = bulletSlider.maxValue;
            playerInventory.currentBullet = playerInventory.maxBullet;
         
        }
    }

    public void DecreaseBullet()
    {
        bulletSlider.value -= 1;
        playerInventory.currentBullet -= 1;
        if(bulletSlider.value < 0)
        {
            bulletSlider.value = 0;
            playerInventory.currentBullet = 0;
        }



  }
}

         
    

