using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public List<GameObject> ListOfAllRooms = new List<GameObject>();
    private List<GameObject> ListOfChosenRooms = new List<GameObject>();
    public List<GameObject> ListOfEnemies = new List<GameObject>();
    public List<GameObject> EnemyTypes = new List<GameObject>();
    public List<Item> ListOfItems = new List<Item>();
    public GameObject CurrentRoom;
    private int currentRoomIndex = 0;
    private GameObject player;
    private void Start()
    {
        foreach (GameObject room in ListOfAllRooms)
        {
            room.SetActive(false);
        }
        ListOfAllRooms[0].SetActive(true);
        player = GameObject.FindWithTag("Player");
        StartRoom(CurrentRoom.GetComponent<RoomData>());
    }

    public void NextRoom()
    {
        ListOfEnemies.Clear();
        ListOfAllRooms[currentRoomIndex].SetActive(false);
        currentRoomIndex++;
        player.transform.position = ListOfAllRooms[currentRoomIndex].GetComponent<RoomData>().PlayerSpawnLocation.transform.position;
        ListOfAllRooms[currentRoomIndex].SetActive(true);;
        StartRoom(ListOfAllRooms[currentRoomIndex].GetComponent<RoomData>());
    }

    public void StartRoom(RoomData roomData)
    {
        // Spawn Enemies
        int spawnedAmmount = Random.Range((int)roomData.MinMaxEnemyAmount.x, (int)roomData.MinMaxEnemyAmount.y);
        int i = 0;
        while(spawnedAmmount > 0)
        {
            int enemyType = Random.Range(0, EnemyTypes.Count);
            Debug.Log(enemyType);
            GameObject NewEnemy = Instantiate(EnemyTypes[enemyType], roomData.EnemySpawnLocations[i]);
            ListOfEnemies.Add(NewEnemy);
            spawnedAmmount--;
            i++;
            if (i > roomData.EnemySpawnLocations.Count)
            {
                i = 0;
            }
        };

        for (int item = 0; item < roomData.ItemSpawns.Count; item++)
        {
            roomData.ItemSpawns[item].item = ListOfItems[Random.Range(0, ListOfItems.Count)];
        }

        player.transform.position = roomData.PlayerSpawnLocation.transform.position;
    }

    //public void RandomizeRoom()
    //{
    //    int roomAmount = Random.Range(3, ListOfAllRooms.Count);
    //    int i = 0;
    //    do
    //    {
    //        GameObject newRoom = ListOfAllRooms[Random.Range(0, ListOfAllRooms.Count)];
    //        if (!ListOfChosenRooms.Contains(newRoom))
    //        {
    //            ListOfChosenRooms.Add(newRoom);
    //            i++;
    //        }
    //    } while (i < roomAmount);
    //    ListOfChosenRooms.Add(BossRoom);
    //}

    public void CheckRoomClear()
    {
        for (int i = 0; i < ListOfEnemies.Count; i++)
        {
            if(ListOfEnemies[i] != null)
            {
                return;
            }
        }
        NextRoom();
    }
    public Item GetItem()
    {
        return ListOfItems[Random.Range(0, ListOfItems.Count)];
    }
}
