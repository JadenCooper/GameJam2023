using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    #region Singleton
    public static ItemManager Instance;

    private void Awake()
    {
        Instance = this; 
    }
    #endregion

    public List<Item> items = new List<Item>();
    public PlayerStats playerStats;

    public void AddItem(Item newItem)
    {
        items.Add(newItem);
        playerStats.ItemChanged(newItem, null);
    }
}
