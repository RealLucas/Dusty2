using UnityEngine;
using System.Collections;

public class InventoryItem 
{
    public bool isDrass;
    public Inventory inventory
    {
        get;
        set;
    }
    public int Count
    {
        //物品个数;
        get;
        set;
    }
    public int Level
    {
        //物品等级
        get;
        set;
    }
}
