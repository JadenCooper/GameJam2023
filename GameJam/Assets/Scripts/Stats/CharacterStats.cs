using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterStats : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;

    public Stat damage;
    public Stat speed;
    public Stat defence;
    public Stat weight;

    public Stat magSize;
    public Stat spread;
    public Stat bulletSpeed;
    public Stat fireRate;
    public Stat reloadSpeed;
    public Stat bulletWeight;
    public Stat range;

    public UnityEvent<float> ChangeHealth, SetHealth;
    public UnityEvent OnDeath;

    private void Awake()
    {
        currentHealth = maxHealth;
        SetHealth?.Invoke(currentHealth);
        ChangeHealth?.Invoke(currentHealth);
    }

    public void Start()
    {
        foreach (Item item in ItemManager.instance.items)
        {
            damage.AddModifier(item.damageModifier);
            speed.AddModifier(item.speedModifier);
            defence.AddModifier(item.defenceModifier);
            if (item.healthModifier > 0)
            {
                maxHealth += item.healthModifier;
                currentHealth += item.healthModifier;
                ChangeHealth?.Invoke(currentHealth);
            }
            weight.AddModifier(item.weightModifier);
            magSize.AddModifier(item.magSizeModifier);
            spread.AddModifier(item.spreadModifier);
            bulletSpeed.AddModifier(item.bulletSpeedModifier);
            fireRate.AddModifier(item.fireRateModifier);
            reloadSpeed.AddModifier(item.reloadSpeedModifier);
            bulletWeight.AddModifier(item.bulletWeightModifier);
            range.AddModifier(item.rangeModifier);
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

        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();
            if (gameObject.tag != "Player")
            {
                Die();
            }
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
