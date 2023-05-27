using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 startPostion;
    private float conquaredDistance = 0;
    private Rigidbody2D rb2d;
    public BulletData bulletData;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    public void Initialize(BulletData newBulletData, Vector2 direction)
    {
        bulletData.Direction = direction;
        bulletData = newBulletData;
        startPostion = transform.position;
        rb2d.velocity = bulletData.Direction * bulletData.Speed;
    }
    private void Update()
    {
        conquaredDistance = Vector2.Distance(transform.position, startPostion);
        if (conquaredDistance > bulletData.MaxDistance)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hit = collision.gameObject;
        if (hit.layer == gameObject.layer)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), hit.GetComponent<Collider2D>());
            return;
        }
        hit.GetComponent<CharacterStats>().TakeDamage(bulletData.damage);
        Debug.Log(hit.name);
        Destroy(gameObject);
    }
}
