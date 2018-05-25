using System.Collections;

public enum ItemType
{
    Equip,
    Box,
    Drug
}

public enum EquipmentType
{
    Helm,
    Cloth,
    Weapon,
    Shoes,
    Necklace,
    Bracelet,
    Ring,
    Wing
}

public class Inventory
{
    public int ID
    {
        get;
        set;
    }
    public string Name
    {
        get;
        set;
    }
    public string IconName
    {
        get;
        set;
    }
    public ItemType ItemsType
    {
        get;
        set;
    }
    public EquipmentType EquipType
    {
        get;
        set;
    }
    public int Price
    {
        get;
        set;
    }
    public int StartLevel
    {
        get;
        set;
    }
    public int Quality
    {
        get;
        set;
    }
    public int Damge
    {
        get;
        set;
    }
    public int HP
    {
        get;
        set;
    }
    public int Power
    {
        get;
        set;
    }
    public PlayerInfoType InfoType
    {
        get;
        set;
    }
    public int ApplyValue
    {
        get;
        set;
    }
    public string Des
    {
        get;
        set;
    }
}
