using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterStats : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth { get; private set; }

    public Stat damage;
    public Stat speed;
    public Stat defence;
    public Stat health;
    public Stat weight;

    public Stat magSize;
    public Stat spread;
    public Stat bulletSpeed;
    public Stat fireRate;
    public Stat reloadSpeed;
    public Stat bulletWeight;

    public UnityEvent<float> ChangeHealth, SetHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
        SetHealth?.Invoke(currentHealth);
        ChangeHealth?.Invoke(currentHealth);
    }

    private void Start()
    {
        foreach (Item item in ItemManager.Instance.items)
        {
            damage.AddModifier(item.damageModifier);
            speed.AddModifier(item.speedModifier);
            defence.AddModifier(item.defenceModifier);
            health.AddModifier(item.healthModifier);
            weight.AddModifier(item.weightModifier);
            magSize.AddModifier(item.magSizeModifier);
            spread.AddModifier(item.spreadModifier);
            bulletSpeed.AddModifier(item.bulletSpeedModifier);
            fireRate.AddModifier(item.fireRateModifier);
            reloadSpeed.AddModifier(item.reloadSpeedModifier);
            bulletWeight.AddModifier(item.bulletWeightModifier);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            TakeDamage(damage.GetValue());
        }
    }

    public void TakeDamage(float damage)
    {

        damage = damage - defence.GetValue();
        damage = Mathf.Clamp(damage, 1, int.MaxValue);
        currentHealth -= damage;
        ChangeHealth?.Invoke(currentHealth);
        Debug.Log(transform.name + " takes " + damage + " damage");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log(transform.name + " has died");
        Destroy(gameObject);
    }
}
