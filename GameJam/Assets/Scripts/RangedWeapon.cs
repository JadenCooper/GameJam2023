using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class RangedWeapon : MonoBehaviour
{
    public Transform barrel;
    public bool isReloading = false;
    private int currentClip;
    public bool IsAttacking { get; set; }
    public bool attackBlock;
    public Vector2 direction;


    public GameObject Bullet;
    public float ReloadDelay = 1f;
    public float AttackDelay = 0.2f;
    public int MaxAmmo = 5;
    private void Start()
    {
        currentClip = MaxAmmo;
    }
    public void Attack()
    {
        if (attackBlock || isReloading)
        {
            return;
        }
        //animator.SetTrigger("Attack");
        Shoot();
        IsAttacking = true;
        attackBlock = true;
        StartCoroutine(DelayAttack());
    }
    public void Shoot()
    {
        GameObject newBullet = Instantiate(Bullet, barrel.position, barrel.rotation);
        newBullet.transform.position = barrel.position;
        newBullet.transform.rotation = barrel.rotation;
        newBullet.layer = gameObject.layer;
        currentClip--;
        if (currentClip <= 0)
        {
            isReloading = true;
            StartCoroutine(Reloading());
        }
    }
    public IEnumerator Reloading()
    {
        yield return new WaitForSeconds(ReloadDelay);
        isReloading = false;
        currentClip = MaxAmmo;
    }

    public  IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(AttackDelay);
        attackBlock = false;
    }
    public void Reload()
    {
        if (isReloading == false)
        {
            Debug.Log("Reload");
            isReloading = true;
            StartCoroutine(Reloading());
        }
    }
}
