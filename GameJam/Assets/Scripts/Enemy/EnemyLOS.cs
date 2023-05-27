using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyLOS : MonoBehaviour
{
    private EnemyMovement enemyMovement;

    private List<Collider2D> targets = new List<Collider2D>();

    private float dectectionRange = 6f;
    private LayerMask playerMask;

    private void Awake()
    {
        enemyMovement= GetComponent<EnemyMovement>();
        targets = new List<Collider2D>();
        playerMask = LayerMask.GetMask("Player");
    }

    private void Update()
    {
            CheckForPlayer();
    }

    public void CheckForPlayer()
    {
        targets.Clear();
        targets.AddRange(Physics2D.OverlapCircleAll(transform.position, dectectionRange, playerMask));

        if(targets.Count <= 0)
        {
            enemyMovement.canSeePlayer = false;
        }
        else
        {
            enemyMovement.canSeePlayer = true;
            Destroy(this);
        }
    }
}
