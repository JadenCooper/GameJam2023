using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewRangedStats", menuName = "Data/RangedStatData")]
public class RangedStats : ScriptableObject
{
    public GameObject Bullet;
    public int MaxAmmo = 5;
    public float ReloadDelay = 2f;
    public float BulletSpeed = 20;
    public float AttackDelay = 0.2f;
    public BulletData bulletData;
}
