using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;

    public float damageModifier;
    public float speedModifier;
    public float defenceModifier;
    public float healthModifier;
    public float weightModifier;
           
    public float magSizeModifier;
    public float spreadModifier;
    public float bulletSpeedModifier;
    public float fireRateModifier;
    public float reloadSpeedModifier;
    public float bulletWeightModifier;
    public float rangeModifier;

    // Start is called before the first frame update
    public void PickUp()
    {
        ItemManager.instance.AddItem(this);
    }
}
