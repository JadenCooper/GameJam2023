using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffin : MonoBehaviour
{
    public Sprite brokenSprite;
    private float BreakOutTime = 5f;
    public GameObject EnemyToSpawn;
    public Transform SpawnLocation;
    public EnemyLOS playerDetector;
    private bool seenPlayer;
    private void Update()
    {
        if (!seenPlayer)
        {
            if (playerDetector.CheckForPlayer())
            {
                seenPlayer = true;
                StartCoroutine(BreakoutTimer(Random.Range(1, BreakOutTime)));
            }
        }
    }
    public IEnumerator BreakoutTimer(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.GetComponent<SpriteRenderer>().sprite = brokenSprite;
        Instantiate(EnemyToSpawn, SpawnLocation);
    }
}
