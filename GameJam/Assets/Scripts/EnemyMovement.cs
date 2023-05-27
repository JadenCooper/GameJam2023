using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public GameObject player;

    public float speed = 1.0f;
    public float bounceBack = 1f;
    public CharacterStats characterStats;

    public bool canSeePlayer;
    // Start is called before the first frame update
    public void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        canSeePlayer = false;
    }

    public void Update()
    {
        if (canSeePlayer) 
        { 
            
            MoveEnemy(gameObject);
        }
    }

    public void MoveEnemy(GameObject enemy)
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        // enemy.transform.LookAt(player.transform);
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, player.transform.position, step);
        CheckSide(enemy);
    }

    private void CheckSide(GameObject enemy)
    {
        Vector2 movementVector = (player.transform.position - enemy.transform.position).normalized;
        if (movementVector.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public void KnockBack(GameObject enemy)
    {
        // Check where the enemy came from 
        Vector3 direction = transform.position - enemy.transform.position;
        // Vector3 moveBack = direction * -1.0f * bounceBack;

        transform.GetComponent<Rigidbody2D>().AddForce(direction * bounceBack, ForceMode2D.Impulse);
        enemy.GetComponent<Rigidbody2D>().AddForce(direction * -1.0f * bounceBack, ForceMode2D.Impulse);

       // rb2D.AddForce(enemy.transform.forward * -1 * bounceBack, ForceMode2D.Impulse);
    }

}
