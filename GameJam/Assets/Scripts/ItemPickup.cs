using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = item.icon;
    }
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        item.PickUp();
        Destroy(gameObject);
    }
    
}
