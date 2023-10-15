using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}


public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D rigidbody;
    private Vector3 change;
    private Animator animator;
    public FloatValue currentHealth;
    public Signals playerHealthSignal;
    public VectorValue startingPosition;
    public Inventory playerInventory;
    public SpriteRenderer receivedItemSprite;
    public Signals playerHit;

    //bullet
    public Signals reducebullet;


    public GameObject projectile;

    [Header("Projectile")]
    public Item gun;


    


    // Start is called before the first frame update
    void Start()

    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        // to dont trigger animation of all attack lef,right, down and up
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
       


    }

    // Update is called once per frame
    void Update()
    {
        // is the player in an iteraction
        if(currentState == PlayerState.interact)
        {
            return;
        }
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        else if (Input.GetButtonDown("Second Weapon") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            if (playerInventory.CheckForItem(gun))
            {
                StartCoroutine(SecondAttackCo());
            }
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationandMove();
        }
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        SoundManager.PlaySound("swordhit");
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }



    private IEnumerator SecondAttackCo()
    {
        //animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        if (playerInventory.currentBullet > 0)
        {
            SoundManager.PlaySound("gunHit");
        }
        
        else
        {
            SoundManager.PlaySound("magazine");
        }
        yield return null;
        MakeBullet();
        //animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }

    private void MakeBullet()
    {
        if (playerInventory.currentBullet > 0)
        {
            Vector2 temp = new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
            Bullet bullet = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Bullet>();
            bullet.Setup(temp, ChooseBulletDirection());
            
            reducebullet.Raise();
        }
    }

    Vector3 ChooseBulletDirection()
    {
        float temp = Mathf.Atan2(animator.GetFloat("moveY"), animator.GetFloat("moveX")) * Mathf.Rad2Deg;
        return new Vector3(0, 0, temp);

    }


    public void RaiseItem()
    {
        if (playerInventory.currentItem != null)
        {
            if (currentState != PlayerState.interact)
            {
                animator.SetBool("item receive", true);
                currentState = PlayerState.interact;
                receivedItemSprite.sprite = playerInventory.currentItem.itemSprite;
            }
            else
            {
                animator.SetBool("item receive", false);
                currentState = PlayerState.idle;
                receivedItemSprite.sprite = null;
                playerInventory.currentItem = null;
            }
        }
    }

    void UpdateAnimationandMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            change.x = Mathf.Round(change.x);
            change.y = Mathf.Round(change.y);

            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);

        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        change.Normalize();
        rigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
    public void Knock (float knockTime, float damage)
    {
        currentHealth.RuntimeValue -= damage;
        playerHealthSignal.Raise();
        if (currentHealth.RuntimeValue > 0)
        {
          
            StartCoroutine(KnockCo(knockTime));
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    private IEnumerator KnockCo(float knockTime)
    {
        playerHit.Raise();
        if (rigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            rigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            rigidbody.velocity = Vector2.zero;

        }
    }
}
