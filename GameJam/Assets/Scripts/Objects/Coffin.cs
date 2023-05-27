using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffin : MonoBehaviour
{
    public Sprite brokenSprite;
    private float BreakOutTime = 5f;
    public GameObject EnemyToSpawn;
    public Transform SpawnLocation;
    void Start()
    {
        StartCoroutine(BreakoutTimer());
    }
    public IEnumerator BreakoutTimer()
    {
        yield return new WaitForSeconds(BreakOutTime);
        gameObject.GetComponent<SpriteRenderer>().sprite = brokenSprite;
        Instantiate(EnemyToSpawn, SpawnLocation);
    }
}
