using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomData : MonoBehaviour
{
    public Transform PlayerSpawnLocation;
    public List<Transform> EnemySpawnLocations = new List<Transform>();
    public Stairs RoomStairs;
    public Vector2 MinMaxEnemyAmount;
}
