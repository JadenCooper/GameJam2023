using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    bool TrapActivated = false;
    bool CanAttack = true;
    float attackDelay = 0.4f;
    public float Damage = 10f;
    public void ActivateTrap()
    {
        TrapActivated = !TrapActivated;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        CharacterStats stats = collision.GetComponent<CharacterStats>();
        Debug.Log("Spike?");
        if (stats != null && TrapActivated && CanAttack)
        {
            stats.TakeDamage(Damage);
            StartCoroutine(AttackDelay());
            Debug.Log("Spiked");
        }
    }

    private IEnumerator AttackDelay()
    {
        CanAttack = false;
        yield return new WaitForSeconds(attackDelay);
        CanAttack = true;
    }
}
