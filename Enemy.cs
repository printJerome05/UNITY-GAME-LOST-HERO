using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}


public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public GameObject deathEffect;
    public LootTable thisLoot;
    // Start is called before the first frame update

   private void Awake()
    {
        health = maxHealth.initialValue;
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
          
            DeathEffect();
            MakeLoot();
            this.gameObject.SetActive(false);
        }
    }

    private void MakeLoot()
    {
        if(thisLoot != null)
        {
            PowerUp current = thisLoot.LootPowerup();
            if(current !=null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }

    private void DeathEffect()
    {
        if(deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }

    public void Knock(Rigidbody2D myrigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myrigidbody, knockTime));
        TakeDamage(damage);
    }


    private IEnumerator KnockCo(Rigidbody2D myrigidbody, float knockTime)
    {
        if (myrigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myrigidbody.velocity = Vector2.zero;
           currentState = EnemyState.idle;
            myrigidbody.velocity = Vector2.zero;

        }
    }
}
