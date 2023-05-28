using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class RangedWeapon : MonoBehaviour
{
    public Transform barrel;
    public bool isReloading = false;
    public int currentClip;
    public bool IsAttacking { get; set; }
    public bool attackBlock;
    public Vector2 direction;
    public RangedStats rangedStats;
    private CharacterStats playerStats;
    private void Start()
    {
        playerStats = gameObject.GetComponentInParent<PlayerStats>();
        currentClip = (int)playerStats.magSize.GetValue();
    }

    public void SetStats(CharacterStats stats)
    {

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
        GameObject newBullet = Instantiate(rangedStats.Bullet, barrel.position, barrel.rotation);
        newBullet.transform.position = barrel.position;
        newBullet.transform.rotation = barrel.rotation;
        newBullet.layer = gameObject.layer;
        newBullet.GetComponent<Bullet>().Initialize(rangedStats.bulletData, playerStats.damage.GetValue(), playerStats.bulletSpeed.GetValue(), playerStats.range.GetValue(), direction);
        currentClip--;
        if (currentClip <= 0)
        {
            isReloading = true;
            StartCoroutine(Reloading());
        }
    }
    public IEnumerator Reloading()
    {
        yield return new WaitForSeconds(playerStats.reloadSpeed.GetValue());
        isReloading = false;
        currentClip = (int)playerStats.magSize.GetValue();
    }

    public  IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(playerStats.fireRate.GetValue());
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
