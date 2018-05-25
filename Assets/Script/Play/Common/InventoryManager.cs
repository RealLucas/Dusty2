using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class InventoryManager : MonoBehaviour
{
    public TextAsset inventoryListInfo;
    public Dictionary<int, Inventory> InventoryDic = new Dictionary<int, Inventory>();

    public List<InventoryItem> inventoryItemList = new List<InventoryItem>();
    private Inventory inventory = null;
    private static InventoryManager _instance;
    public static InventoryManager GetInstance
    {
        get { return _instance; }
    }

    public delegate void OnInventoryItemChangedHandler();
    public event OnInventoryItemChangedHandler OnInventoryItemChanged;

    private void Awake()
    {
        _instance = this;
        InistInventoryListInfo();

    }

    private void Start()
    {
        GetItem();
        InventoryUI.GetInstance.pageNumber = inventoryItemList.Count;
    }
    //初始化物品信息
    void InistInventoryListInfo()
    {
        string[] strArray = inventoryListInfo.text.Split('\n');
        foreach (string item in strArray)
        {
            Inventory inventory = new Inventory();
            string[] infoArray = item.Split('|');
            inventory.ID = int.Parse(infoArray[0]);
            inventory.Name = infoArray[1];
            inventory.IconName = infoArray[2];
            switch (infoArray[3])
            {
                case "Equip":
                    inventory.ItemsType = ItemType.Equip;
                    break;
                case "Drug":
                    inventory.ItemsType = ItemType.Drug;
                    break;
                case "Box":
                    inventory.ItemsType = ItemType.Box;
                    break;
            }


            if (inventory.ItemsType == ItemType.Equip)
            {
                switch (infoArray[4])
                {
                    case "Helm":
                        inventory.EquipType = EquipmentType.Helm;
                        break;
                    case "Cloth":
                        inventory.EquipType = EquipmentType.Cloth;
                        break;
                    case "Weapon":
                        inventory.EquipType = EquipmentType.Weapon;
                        break;
                    case "Shoes":
                        inventory.EquipType = EquipmentType.Shoes;
                        break;
                    case "Necklace":
                        inventory.EquipType = EquipmentType.Necklace;
                        break;
                    case "Bracelet":
                        inventory.EquipType = EquipmentType.Bracelet;
                        break;
                    case "Ring":
                        inventory.EquipType = EquipmentType.Ring;
                        break;
                    case "Wing":
                        inventory.EquipType = EquipmentType.Wing;
                        break;
                }
                inventory.Price = int.Parse(infoArray[5]);
                inventory.StartLevel = int.Parse(infoArray[6]);
                inventory.Quality = int.Parse(infoArray[7]);
                inventory.Damge = int.Parse(infoArray[8]);
                inventory.HP = int.Parse(infoArray[9]);
                inventory.Power = int.Parse(infoArray[10]);
            }
            else
            {
                inventory.Price = int.Parse(infoArray[4]);
                if (inventory.ItemsType == ItemType.Drug)
                {
                    inventory.ApplyValue = int.Parse(infoArray[12]);
                }
            }
            inventory.Des = infoArray[13];
            InventoryDic.Add(inventory.ID, inventory);
        }
    }

    //读取角色背包信息
    //获得物品的方法
    public void GetItem(int count = 20)
    {
        //通过连接服务器读取
        //ToDo

        for (int i = 0; i < count; i++)
        {
            int id = Random.Range(1001, 1020);
            InventoryDic.TryGetValue(id, out inventory);
            if (inventory.ItemsType == ItemType.Equip)
            {
                //装备的话就每个添加一个物品栏
                InventoryItem inventoryItem = null;
                inventoryItem = new InventoryItem();
                inventoryItem.inventory = inventory;
                inventoryItem.Level = Random.Range(1, 10);
                inventoryItem.Count = 1;
                inventoryItemList.Add(inventoryItem);

            }
            else
            {
                //为BOX,Drug,有就叠加没有就创建
                InventoryItem inventoryItem = null;
                bool isExsit = false;

                foreach (InventoryItem item in inventoryItemList)
                {
                    if (item.inventory.ID == id)
                    {
                        //存在
                        inventoryItem = item;
                        isExsit = true;
                    }
                }
                if (isExsit)
                {
                    //存在
                    inventoryItem.Count++;

                }
                else
                {
                    //不存在,就创建
                    inventoryItem = new InventoryItem();
                    inventoryItem.inventory = inventory;
                    inventoryItem.Count = 1;
                    //InventoryItemDic.Add(id, inventoryItem);
                    inventoryItemList.Add(inventoryItem);
                }
            }

        }
        OnInventoryItemChanged();
    }

    public void UpdateInventory()
    {
        OnInventoryItemChanged();
    }

}
