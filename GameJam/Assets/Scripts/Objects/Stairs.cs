using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    private RoomManager roomManager;
    void Start()
    {
        roomManager =  GameObject.FindWithTag("Manager").GetComponent<RoomManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            roomManager.CheckRoomClear();
        }
    }
}
