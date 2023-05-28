using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGoblin : EnemyMovement
{
    public float attackDelay = 10.0f;
    public bool isAttacking = false;
    public AudioSource audioSource;
    private void Start()
    {
        base.Start();
        StartCoroutine(CoinTimer(Random.Range(3, 15)));
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isAttacking)
        {
            isAttacking = true;
            collision.gameObject.GetComponent<CharacterStats>().TakeDamage(characterStats.damage.GetValue());
            StartCoroutine(HitPlayer(collision.gameObject));
        }
    }

    IEnumerator HitPlayer(GameObject hitTarget)
    {
        speed = 0.0f;
        KnockBack(hitTarget);
        yield return new WaitForSeconds(attackDelay);
        speed = 1.0f;
        isAttacking = false;
    }

    IEnumerator CoinTimer(float Timer)
    {
        yield return new WaitForSeconds(Timer);
        audioSource.Play();
    }
}
