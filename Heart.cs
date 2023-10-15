using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : PowerUp
{
    public FloatValue playerHealth;
    public FloatValue heartContainers;
    public HeartManager heartmanager;
    public float amountToIncrease;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      
           

    }
    private void Awake()
    {
        if (heartmanager.playerCurrentHealth.RuntimeValue == 6)
        {
            Heart heart = this;
            Destroy(this.gameObject);
        }
        this.gameObject.SetActive(true);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {

            playerHealth.RuntimeValue += amountToIncrease;
            if(playerHealth.initialValue > heartContainers.RuntimeValue * 2f)
            {
                playerHealth.initialValue = heartContainers.RuntimeValue * 2f;
            }
            powerupSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
