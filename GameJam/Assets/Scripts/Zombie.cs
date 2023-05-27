using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Zombie : EnemyMovement
{
    private GameObject zombie;

    public float attackDelay = 10.0f;
    public bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
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
            StartCoroutine(HitPlayer(collision.gameObject));
            // HitPlayer(collision.gameObject);
        }
    }

    IEnumerator HitPlayer(GameObject hitTarget)
    {
        speed = 0.0f;
        Debug.Log(hitTarget.transform.name + " was hit by " + gameObject.transform.name);
        // hitTarget.GetComponent<CharacterStats>().takeDamage(gameObject.GetComponent<CharacterStats>().damage);
        KnockBack(hitTarget);
        yield return new WaitForSeconds(attackDelay);
        speed = 1.0f;
        isAttacking = false;
    }
}
