using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPowerup : PowerUp
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            powerupSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
