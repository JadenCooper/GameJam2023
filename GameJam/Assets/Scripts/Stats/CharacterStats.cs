using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat speed;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        foreach (Item item in ItemManager.Instance.items)
        {
            damage.AddModifier(item.damageModifier);
            speed.AddModifier(item.speedModifier);
        }
    }

    public void Update()
    {
        Debug.Log(damage.GetValue());
        if (Input.GetKeyDown("t"))
        {
            TakeDamage(damage.GetValue());
        }
    }

    public void TakeDamage(int damage)
    {
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log(transform.name + " has died");
    }
}
