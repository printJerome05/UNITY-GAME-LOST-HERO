using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public BoolValue storedOpen;
    public Signals raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    private Animator anim;
    // Start is called before the first frame update

    private void Awake()
    {
        playerInventory.numberOfKeys = 0;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
       
        if (isOpen)
        {
            isOpen = storedOpen.initialValue;
            anim.SetBool("opened", true);
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if(!isOpen)
            {
                //open the chest
                OpenChest();
            }
            else
            {
                //chest is already open
                ChestAlreadyOpen();
            }
        }
    }

    public void OpenChest()
    {
        // DIALOG WINDOW ON
        // DIALOG TEXT = CONTENTS TEXT
        dialogBox.SetActive(true);
        // add contents to the inventory
        dialogText.text = contents.itemDescription;

        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        // raise the signal to the player to animate
        // set the chest to opened
        raiseItem.Raise();
        // raise the context clue
   
        context.Raise();
        isOpen = true;
        anim.SetBool("opened", true);
        storedOpen.initialValue = isOpen;
    }
    public void ChestAlreadyOpen()
    {
      
            dialogBox.SetActive(false);
       
            raiseItem.Raise();
        
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = false;

        }
    }
}
