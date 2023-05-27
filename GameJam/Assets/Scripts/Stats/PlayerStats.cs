using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public void ItemChanged (Item newItem, Item oldItem = null)
    {
        if (newItem != null)
        {
            damage.AddModifier(newItem.damageModifier);
            speed.AddModifier(newItem.speedModifier);
        }

        //if (newItem != null)
        //{
        //    damage.RemoveModifier(oldItem.damageModifier);
        //    speed.RemoveModifier(oldItem.speedModifier);
        //}
    }
}
