using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KnapStack : MonoBehaviour
{

    private KnapStackRoleEquip helm;
    private KnapStackRoleEquip cloth;
    private KnapStackRoleEquip weapon;
    private KnapStackRoleEquip shoes;
    private KnapStackRoleEquip nocklace;
    private KnapStackRoleEquip bracelet;
    private KnapStackRoleEquip ring;
    private KnapStackRoleEquip wing;
    private UILabel hpLabel;
    private UILabel damageLabel;
    private UILabel expLabel;
    private UISlider expSlider;
    private EquipInfoFrame equipInfoFrame;
    private ItemInfoFrame itemInfoFrame;
    private bool isLeft;
    private InventoryItem it;
    private InventoryItemUI itUI;
    private KnapStackRoleEquip kSRE;
    private TweenPosition tween;
    private UIButton closeButton;
    private bool isShow;
    private static KnapStack _instance;
    public static KnapStack GetInstance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        _instance = this;
        helm = transform.Find("Role/HelmSprite").GetComponent<KnapStackRoleEquip>();
        cloth = transform.Find("Role/ClothSprite").GetComponent<KnapStackRoleEquip>();
        weapon = transform.Find("Role/WeaponSprite").GetComponent<KnapStackRoleEquip>();
        shoes = transform.Find("Role/ShoesSprite").GetComponent<KnapStackRoleEquip>();
        nocklace = transform.Find("Role/NocklaceSprite").GetComponent<KnapStackRoleEquip>();
        bracelet = transform.Find("Role/BraceletSprite").GetComponent<KnapStackRoleEquip>();
        ring = transform.Find("Role/RingSprite").GetComponent<KnapStackRoleEquip>();
        wing = transform.Find("Role/WingSprite").GetComponent<KnapStackRoleEquip>();
        hpLabel = transform.Find("Role/HPbg/HPLabel").GetComponent<UILabel>();
        damageLabel = transform.Find("Role/Damgebg/DamageLabel").GetComponent<UILabel>();
        expLabel = transform.Find("Role/ExpSlider/ExpLabel").GetComponent<UILabel>();
        expSlider = transform.Find("Role/ExpSlider").GetComponent<UISlider>();
        equipInfoFrame = transform.Find("EquipInfoFrame").GetComponent<EquipInfoFrame>();
        itemInfoFrame = transform.Find("ItemInfoFrame").GetComponent<ItemInfoFrame>();
        closeButton = transform.Find("CloseButton").GetComponent<UIButton>();
        EventDelegate ed = new EventDelegate(this, "Hide");
        closeButton.onClick.Add(ed);
        tween = transform.GetComponent<TweenPosition>();
        PlayerInfo.GetInstance.OnPlayerInfoChangedEvent += OnPlayerInfoChanged;
    }


    void OnPlayerInfoChanged(PlayerInfoType type)
    {
        if (type == PlayerInfoType.All || type == PlayerInfoType.Damage || type == PlayerInfoType.Exp || type == PlayerInfoType.HP || type == PlayerInfoType.Equip)
        {
            UpdateInfoShow();
        }
    }


    //更新穿戴显示
    void UpdateInfoShow()
    {
        PlayerInfo info = PlayerInfo.GetInstance;
        helm.SetByInventoryItem(info.HelmInventoryItem);
        cloth.SetByInventoryItem(info.ClothInventoryItem);
        weapon.SetByInventoryItem(info.WeaponInventoryItem);
        shoes.SetByInventoryItem(info.ShoesInventoryItem);
        nocklace.SetByInventoryItem(info.NecklaceInventoryItem);
        bracelet.SetByInventoryItem(info.BraceletInventoryItem);
        ring.SetByInventoryItem(info.RingInventoryItem);
        wing.SetByInventoryItem(info.WingInventoryItem);

        hpLabel.text = info.HP.ToString();
        damageLabel.text = info.Damage.ToString();
        expLabel.text = info.Exp + "/" + GameControl.GetRequireByLevel(info.Level);
        expSlider.value = info.Exp / (float)GameControl.GetRequireByLevel(info.Level);
    }

    public void OnEquipClick(object[] objectArry)
    {
        it = (InventoryItem)objectArry[0];
        isLeft = (bool)objectArry[1];

        if (isLeft)
        {
            itUI = (InventoryItemUI)objectArry[2];
        }
        else
        {
            kSRE = (KnapStackRoleEquip)objectArry[2];
        }

        if (it.inventory.ItemsType == ItemType.Equip)
        {

            equipInfoFrame.ShowEquipInfoUI(it, itUI, kSRE, isLeft);
            itemInfoFrame.CloseButtonClick();
        }
        else
        {
            itUI = (InventoryItemUI)objectArry[2];
            itemInfoFrame.ShowItemDesUI(it, itUI);
            equipInfoFrame.CloseButtonClick();
        }

        if (it.inventory.ItemsType != ItemType.Equip || (it.inventory.ItemsType == ItemType.Equip && isLeft))
        {
            this.transform.GetChild(2).SendMessage("OnEnableButton", (InventoryItemUI)objectArry[2]);
        }
    }

    public void Show()
    {
        if (isShow == false)
        {
            tween.PlayForward();
            isShow = true;
        }
        else
        {
            Hide();
        }
    }

    public void Hide()
    {
        tween.PlayReverse();
        isShow = false;
    }
}
