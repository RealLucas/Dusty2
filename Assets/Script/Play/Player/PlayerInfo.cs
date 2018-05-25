using UnityEngine;
using System.Collections;

public enum PlayerInfoType
{
    Name,
    HeadPortrait,
    Level,
    Power,
    Exp,
    Diamond,
    Coin,
    Energy,
    LiLian,
    HP,
    Damage,
    Equip,
    All
}

public enum PlayerType
{
    Worrir,
    Assenta
}
public class PlayerInfo : MonoBehaviour
{
    private static PlayerInfo _instance;
    public int maxEnergy = 100;
    public int maxLiLian = 50;
    public float energyTimer;
    public float liLianTimer;
    public delegate void OnPlayerInfoChangedHandler(PlayerInfoType type);
    public event OnPlayerInfoChangedHandler OnPlayerInfoChangedEvent;
    private Inventory inventory;
    private InventoryItem it;
    private InventoryItemUI itUI;
    public PowerShow powerShow;

    #region Property
    private string _name;
    private string _headPortrait;
    private int _level;
    private int _power;
    private int _exp;
    private int _diamond;
    private int _coin;
    private int _energy;
    private int _liLian;
    #endregion
    #region Get set method

    public static PlayerInfo GetInstance
    {
        get { return _instance; }
    }

    public int MoveSpeed
    {
        get;
        set;
    }

    public int AttackSpeed
    {
        get;
        set;
    }

    public int Def
    {
        get;
        set;
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string HeadPortrait
    {
        get { return _headPortrait; }
        set { _headPortrait = value; }
    }

    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }

    public int Power
    {
        get { return _power; }
        set { _power = value; }
    }

    public int Exp
    {
        get { return _exp; }
        set { _exp = value; }
    }

    public int Diamond
    {
        get { return _diamond; }
        set { _diamond = value; }
    }

    public int Coin
    {
        get { return _coin; }
        set { _coin = value; }
    }

    public int Energy
    {
        get { return _energy; }
        set { _energy = value; }
    }

    public int LiLian
    {
        get { return _liLian; }
        set { _liLian = value; }
    }


    public InventoryItem HelmInventoryItem
    {
        get;
        set;
    }
    public InventoryItem ClothInventoryItem
    {
        get;
        set;
    }
    public InventoryItem WeaponInventoryItem
    {
        get;
        set;
    }
    public InventoryItem ShoesInventoryItem
    {
        get;
        set;
    }
    public InventoryItem NecklaceInventoryItem
    {
        get;
        set;
    }
    public InventoryItem BraceletInventoryItem
    {
        get;
        set;
    }
    public InventoryItem RingInventoryItem
    {
        get;
        set;
    }
    public InventoryItem WingInventoryItem
    {
        get;
        set;
    }

    public int HP
    {
        get;
        set;
    }
    public int MaxHP
    {
        get;
        set;
    }

    public int MaxMP
    {
        get;
        set;
    }
    public int MP
    {
        get;
        set;
    }

    public int Damage
    {
        get;
        set;
    }
    public PlayerType PlayerClass
    {
        get;
        set;
    }

    #endregion

    void Awake()
    {
        _instance = this;

    }
    private void Start()
    {
        Inist();//角色信息初始化
    }

    void Update()
    {
        NumberRecover();
    }

    //初始化角色属性
    void Inist()
    {
        this.Name = "步惊云";
        this.HeadPortrait = "头像底板女性";
        this.Coin = 10002;
        this.Diamond = 145;
        this.Energy = 91;
        this.Level = 12;
        this.Exp = 21;
        this.LiLian = 23;
        this.HP = 100;
        this.MaxHP = 100;
        this.MaxMP = 100;
        this.Power = 150;

        // OnHPDamagePowerAdd();

        OnPlayerInfoChangedEvent(PlayerInfoType.All);
    }

    void OnHPDamagePowerAdd()
    {
        this.HP = this.Level * 100;
        this.Damage = this.Level * 50;
        this.Power = this.HP + this.Damage;

    }

    //穿戴装备
    public void OnEquipOn(InventoryItem it, InventoryItemUI itUI, KnapStackRoleEquip kSRE)
    {
        this.it = it;
        this.itUI = itUI;
        bool isDrassed = false;
        InventoryItem item = null;

        //判断是否穿戴了同一类型的装备
        //是
        //脱下装备,在背包中加入脱下的装备
        //否
        //清空要穿戴的装备
        //属性的变化
        switch (it.inventory.EquipType)
        {
            case EquipmentType.Bracelet:
                if (BraceletInventoryItem != null)
                {
                    isDrassed = true;   //表示已经穿戴了同类型装备
                    item = BraceletInventoryItem;
                }
                BraceletInventoryItem = it;
                break;
            case EquipmentType.Cloth:
                if (ClothInventoryItem != null)
                {
                    isDrassed = true;
                    item = ClothInventoryItem;
                }
                ClothInventoryItem = it;
                break;
            case EquipmentType.Helm:
                if (HelmInventoryItem != null)
                {
                    isDrassed = true;
                    item = HelmInventoryItem;
                }
                HelmInventoryItem = it;
                break;
            case EquipmentType.Necklace:
                if (NecklaceInventoryItem != null)
                {
                    isDrassed = true;
                    item = NecklaceInventoryItem;
                }
                NecklaceInventoryItem = it;
                break;
            case EquipmentType.Ring:
                if (RingInventoryItem != null)
                {
                    isDrassed = true;
                    item = RingInventoryItem;
                }
                RingInventoryItem = it;
                break;
            case EquipmentType.Shoes:
                if (ShoesInventoryItem != null)
                {
                    isDrassed = true;
                    item = ShoesInventoryItem;
                }
                ShoesInventoryItem = it;
                break;
            case EquipmentType.Weapon:
                if (WeaponInventoryItem != null)
                {
                    isDrassed = true;
                    item = WeaponInventoryItem;
                }
                WeaponInventoryItem = it;
                break;
            case EquipmentType.Wing:
                if (WingInventoryItem != null)
                {
                    isDrassed = true;
                    item = WingInventoryItem;
                }
                WingInventoryItem = it;
                break;
        }

        if (isDrassed)
        {
            //已经穿戴了同类型装备,卸下加入背包
            item.isDrass = false;
            OnEquipOff(item, kSRE);
        }
        it.isDrass = true;
        itUI.Clear();
        OnEquipPutOn(it);
        OnPlayerInfoChangedEvent(PlayerInfoType.Equip);

    }

    //卸下装备
    public void OnEquipOff(InventoryItem it, KnapStackRoleEquip kSRE = null)
    {
        if (it == null) return;
        InventoryUI.GetInstance.pageNumber++;
       
        InventoryUI.GetInstance.UpdateShowPageNumber();
        it.isDrass = false;
        InventoryUI.GetInstance.AddInventory(it);
        OnEquipPutOff(it);

        //装备面板处卸下时执行清理
        if (kSRE != null) kSRE.OnClear();

        DessOff(it);
        OnPlayerInfoChangedEvent(PlayerInfoType.Equip);
    }

    //卸下装备时需要清空原来的装备信息,防止更新装备时再一次把卸下的装备添加回去
    void DessOff(InventoryItem it)
    {
        switch (it.inventory.EquipType)
        {
            case EquipmentType.Bracelet:
                if (BraceletInventoryItem != null)
                    BraceletInventoryItem = null;
                break;
            case EquipmentType.Cloth:
                if (ClothInventoryItem != null)
                    ClothInventoryItem = null;
                break;
            case EquipmentType.Helm:
                if (HelmInventoryItem != null)
                    HelmInventoryItem = null;
                break;
            case EquipmentType.Necklace:
                if (NecklaceInventoryItem != null)
                    NecklaceInventoryItem = null;
                break;
            case EquipmentType.Ring:
                if (RingInventoryItem != null)
                    RingInventoryItem = null;
                break;
            case EquipmentType.Shoes:
                if (ShoesInventoryItem != null)
                    ShoesInventoryItem = null;
                break;
            case EquipmentType.Weapon:
                if (WeaponInventoryItem != null)
                    WeaponInventoryItem = null;
                break;
            case EquipmentType.Wing:
                if (WingInventoryItem != null)
                    WingInventoryItem = null;
                break;

        }
        it.isDrass = false;
    }

    //穿上装备属性改变
    public void OnEquipPutOn(InventoryItem it)
    {
        if (it == null) return;
        InventoryUI.GetInstance.pageNumber--;
       
        InventoryUI.GetInstance.UpdateShowPageNumber();
        int startValue = this.Power;
        int id = it.inventory.ID;
        inventory = null;
        InventoryManager.GetInstance.InventoryDic.TryGetValue(id, out inventory);
        this.HP += inventory.HP;
        this.Power += inventory.Power;
        this.Damage += inventory.Damge;
        OnPlayerInfoChangedEvent(PlayerInfoType.HP);
        OnPlayerInfoChangedEvent(PlayerInfoType.Power);
        OnPlayerInfoChangedEvent(PlayerInfoType.Damage);
        int endValue = this.Power;
        //出现战斗力增加
        powerShow.PowerChanged(startValue, endValue);
    }

    //卸下装备属性改变
    public void OnEquipPutOff(InventoryItem it)
    {
        if (it == null) return;
        int startValue = this.Power;
        int id = it.inventory.ID;
        inventory = null;
        InventoryManager.GetInstance.InventoryDic.TryGetValue(id, out inventory);
        this.HP -= inventory.HP;
        this.Power -= inventory.Power;
        this.Damage = inventory.Damge;

        OnPlayerInfoChangedEvent(PlayerInfoType.HP);
        OnPlayerInfoChangedEvent(PlayerInfoType.Power);
        OnPlayerInfoChangedEvent(PlayerInfoType.Damage);
        //出现战斗力减少
        int endValue = this.Power;
        powerShow.PowerChanged(startValue, endValue);
    }

    //体力和历练自动回复
    void NumberRecover()
    {
        if (energyTimer < maxEnergy)
        {
            energyTimer += Time.deltaTime;
            if (energyTimer > 60)
            {
                ++Energy;
                energyTimer = 0;
                OnPlayerInfoChangedEvent(PlayerInfoType.Energy);
            }
        }
        else
        {
            energyTimer = 0;
        }
        if (liLianTimer < maxLiLian)
        {
            liLianTimer += Time.deltaTime;
            if (liLianTimer > 60)
            {
                ++LiLian;
                liLianTimer = 0;
                OnPlayerInfoChangedEvent(PlayerInfoType.LiLian);
            }
        }
        else
        {
            liLianTimer = 0;
        }
    }
    public void OnChangeName(string newName)
    {
        this.Name = newName;
        OnPlayerInfoChangedEvent(PlayerInfoType.Name);
    }


    //使用金币
    public bool UseCoin(int coin)
    {
        if (Coin >= coin)
        {
            Coin -= coin;
            OnPlayerInfoChangedEvent(PlayerInfoType.Coin);
            return true;
        }
        return false;
    }
    
    //获得金币
    public void GetCoin(int coin)
    {
        if (coin == 0) return;
        this.Coin += coin;
        OnPlayerInfoChangedEvent(PlayerInfoType.Coin);
    }

    public void AddHP(InventoryItem it, int count = 1)
    {
        this.HP += it.inventory.ApplyValue * count;
        //限制回血的最大上限度
        if (this.HP > this.MaxHP)
            this.HP = this.MaxHP;
        OnPlayerInfoChangedEvent(PlayerInfoType.HP);
    }

    public void OpenBox(int count)
    {
        InventoryManager.GetInstance.GetItem(count);
    }

    //根据装备等级增加战斗力
    public void PowerAddByLevel(InventoryItem it)
    {
        int startValue = this.Power;
        this.Power = it.inventory.Power * (int)((1 + (it.Level - 1) / 10f));
        OnPlayerInfoChangedEvent(PlayerInfoType.Power);
        int endValue = this.Power;
        //出现战斗力增加
        powerShow.PowerChanged(startValue, endValue);
    }
}
