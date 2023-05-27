using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    private RoomManager roomManager;
    public bool RoomCleared = false;
    void Start()
    {
        roomManager =  GameObject.FindWithTag("Manager").GetComponent<RoomManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && RoomCleared == true)
        {
            roomManager.NextRoom();
        }
    }
}
