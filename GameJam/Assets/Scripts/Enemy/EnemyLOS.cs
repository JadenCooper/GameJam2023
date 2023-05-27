using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyLOS : MonoBehaviour
{

    private List<Collider2D> targets = new List<Collider2D>();

    public float dectectionRange = 6f;
    private LayerMask playerMask;

    private void Awake()
    {
        targets = new List<Collider2D>();
        playerMask = LayerMask.GetMask("Player");
    }

    public bool CheckForPlayer()
    {
        targets.Clear();
        targets.AddRange(Physics2D.OverlapCircleAll(transform.position, dectectionRange, playerMask));

        if(targets.Count <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
