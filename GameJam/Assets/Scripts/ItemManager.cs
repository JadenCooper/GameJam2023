using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    #region Singleton
    public static ItemManager instance {
        get 
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ItemManager>();
            }
            return _instance;
        }
    }
    static ItemManager _instance;

    private void Awake()
    {
        _instance = this; 
    }
    #endregion

    public List<Item> items = new List<Item>();
    public PlayerStats playerStats;

    public void AddItem(Item newItem)
    { 
        items.Add(newItem);
        playerStats.ItemChanged(newItem);
    }
}
