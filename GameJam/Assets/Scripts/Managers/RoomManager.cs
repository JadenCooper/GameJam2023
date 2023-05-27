using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public List<Stairs> ListOfStairs = new List<Stairs>();
    private List<GameObject> ListOfAllRooms = new List<GameObject>();
    private GameObject BossRoom;
    private List<GameObject> ListOfChosenRooms = new List<GameObject>();
    private List<GameObject> ListOfEnemies = new List<GameObject>();
    public GameObject CurrentRoom;
    private int currentRoomIndex = 0;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartRoom(CurrentRoom.GetComponent<RoomData>());
    }
    public void NextRoom()
    {
        ListOfEnemies.Clear();
        Destroy(CurrentRoom);
        currentRoomIndex = currentRoomIndex + 1;
        CurrentRoom = ListOfChosenRooms[currentRoomIndex];
        Instantiate(CurrentRoom);
        StartRoom(CurrentRoom.GetComponent<RoomData>());
    }

    public void StartRoom(RoomData roomData)
    {
        // Spawn Enemies
        int spawnedAmmount = Random.Range((int)roomData.MinMaxEnemyAmount.x, (int)roomData.MinMaxEnemyAmount.y);
        int i = 0;
        Debug.Log(spawnedAmmount);
        do
        {
            int enemyType = Random.Range(0, roomData.EnemyTypes.Count);
            Instantiate(roomData.EnemyTypes[enemyType], roomData.EnemySpawnLocations[i]);
            spawnedAmmount--;
            i++;
            if (i > roomData.EnemySpawnLocations.Count)
            {
                i = 0;
            }
        }while(spawnedAmmount > 0);

        player.transform.position = roomData.PlayerSpawnLocation.transform.position;
    }

    public void RandomizeRoom()
    {
        int roomAmount = Random.Range(3, ListOfAllRooms.Count);
        int i = 0;
        do
        {
            GameObject newRoom = ListOfAllRooms[Random.Range(0, ListOfAllRooms.Count)];
            if (!ListOfChosenRooms.Contains(newRoom))
            {
                ListOfChosenRooms.Add(newRoom);
                i++;
            }
        } while (i < roomAmount);
        ListOfChosenRooms.Add(BossRoom);
    }
}
