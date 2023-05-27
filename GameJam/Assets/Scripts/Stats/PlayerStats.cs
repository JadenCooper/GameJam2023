using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerStats : CharacterStats
{
    public void ItemChanged (Item newItem)
    {
        if (newItem != null)
        {
            damage.AddModifier(newItem.damageModifier);
            speed.AddModifier(newItem.speedModifier);
            defence.AddModifier(newItem.defenceModifier);
            health.AddModifier(newItem.healthModifier);
            weight.AddModifier(newItem.weightModifier);
            magSize.AddModifier(newItem.magSizeModifier);
            spread.AddModifier(newItem.spreadModifier);
            bulletSpeed.AddModifier(newItem.bulletSpeedModifier);
            fireRate.AddModifier(newItem.fireRateModifier);
            reloadSpeed.AddModifier(newItem.reloadSpeedModifier);
            bulletWeight.AddModifier(newItem.bulletWeightModifier);
        }

        //if (newItem != null)
        //{
        //    damage.RemoveModifier(oldItem.damageModifier);
        //    speed.RemoveModifier(oldItem.speedModifier);
        //}
    }
}
