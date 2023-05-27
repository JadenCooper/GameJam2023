using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;

    public int damageModifier;
    public int speedModifier;

    // Start is called before the first frame update
    public void OnPickup()
    {
        ItemManager.Instance.AddItem(this);
    }
}
