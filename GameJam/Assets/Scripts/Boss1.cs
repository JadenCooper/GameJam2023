using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : EnemyMovement
{
    [SerializeField]
    private List<GameObject> spawnPoints = new List<GameObject>();

    [SerializeField]
    private float spawnTime;

    public GameObject zombie;
    public GameObject demon;

    private List<GameObject> enemies = new List<GameObject>();

    public float attackDelay = 1.5f;
    public bool isAttacking = false;
    
    private int count = 0;
    

    private void Start()
    {
        base.Start();    
        enemies.Add(zombie); 
        enemies.Add(demon);
    }

    bool coroutineIsRunning = false;

    private void Update()
    {
        base.Update();
        if(!coroutineIsRunning)
            StartCoroutine(HandleSpawnEnemies());
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

    float t = 0f;

    IEnumerator HandleSpawnEnemies() {
        coroutineIsRunning = true;
        while (t < spawnTime)
        {
            t += Time.deltaTime;
            yield return null;
        }
        SpawnEnemy();
        t = 0f;
        coroutineIsRunning = false;

        yield return null;
    }

    public void SpawnEnemy()
    {
        int whichEnemy = Random.Range(0, enemies.Count);

        Vector3 spawnPosition = spawnPoints[count % spawnPoints.Count].transform.position;

        Instantiate(enemies[whichEnemy], spawnPosition, Quaternion.identity);
        count++;  

    }

    IEnumerator HitPlayer(GameObject hitTarget)
    {
        speed = 0.0f;
        Debug.Log(hitTarget.transform.name + " was hit by " + gameObject.transform.name);
        Debug.Log(characterStats.currentHealth);
        //if(characterStats.currentHealth < (characterStats.maxHealth / 2))
        //{
        //    bounceBack = 0.1f;
        //    KnockBack(hitTarget);
        //} 
        //else if (characterStats.currentHealth < characterStats.maxHealth / 4)
        //{
        //    bounceBack = 0.2f;
        //    KnockBack(hitTarget);
        //}
        yield return new WaitForSeconds(attackDelay);
        speed = 1.0f;
        isAttacking = false;
    }
}
