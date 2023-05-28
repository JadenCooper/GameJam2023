using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bomber : EnemyMovement
{
    [SerializeField]
    private List<GameObject> fireBallLocations = new List<GameObject>();

    public GameObject fireBall;

    private float fuseTime = 0.2f;

    private void Update()
    {
        base.Update();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            StartCoroutine(Suicide(collision.gameObject));
        }
    }

    public void Strapnel()
    {
        int[] directions = { 90, -90, 0, 180 };

        Vector3 objectPos = transform.position;

        float angle = Mathf.Atan2(objectPos.y, objectPos.x) * Mathf.Rad2Deg;

        Debug.Log(angle);

        Debug.Log("bomber blew up");
        player.gameObject.GetComponent<CharacterStats>().TakeDamage(characterStats.damage.GetValue());

        foreach (GameObject obj in fireBallLocations)
        {
            int i = 0;

            GameObject newFireBall = Instantiate(fireBall, obj.transform.position, Quaternion.Euler(0, 0, angle));

            newFireBall.layer = gameObject.layer;
            newFireBall.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            Vector2 FireDirection = (player.transform.position - transform.position).normalized;
            BulletData newBullet = new BulletData();
            newBullet.Direction = FireDirection;
            newBullet.Speed = 5f;
            newBullet.MaxDistance = 10f;
            newFireBall.GetComponent<Bullet>().Initialize(newBullet, characterStats.damage.GetValue(), characterStats.bulletSpeed.GetValue(), characterStats.range.GetValue(), FireDirection);
        }

        Destroy(gameObject);
    }

    IEnumerator Suicide(GameObject target)
    {
        yield return new WaitForSeconds(fuseTime);

        Strapnel();
        Destroy(gameObject);
    }
}
