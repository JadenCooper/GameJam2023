using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Zombie : EnemyMovement
{
    public float attackDelay = 10.0f;
    public bool isAttacking = false;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(MoanTimer(Random.Range(3, 15)));
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isAttacking)
        {
            isAttacking = true;
            collision.gameObject.GetComponent<CharacterStats>().TakeDamage(characterStats.damage.GetValue());
            StartCoroutine(HitPlayer(collision.gameObject));
            // HitPlayer(collision.gameObject);
        }
    }

    IEnumerator HitPlayer(GameObject hitTarget)
    {
        speed = 0.0f;
        // hitTarget.GetComponent<CharacterStats>().takeDamage(gameObject.GetComponent<CharacterStats>().damage);
        KnockBack(hitTarget);
        yield return new WaitForSeconds(attackDelay);
        speed = 1.0f;
        isAttacking = false;
    }

    IEnumerator MoanTimer(float Timer)
    {
        yield return new WaitForSeconds(Timer);
        audioSource.Play();
    }
}
