using UnityEngine;
using System.Collections;

public class ItemInfoFrame : MonoBehaviour
{
    private UILabel itemName;
    private UILabel des;
    private UILabel blachLabel;
    private UISprite itemSprite;
    private UIButton closeButton;
    private UIButton useButton;
    private UIButton blachUseButton;
    private InventoryItem it;
    private InventoryItemUI itUI;
    private static ItemInfoFrame _instance;
    public static ItemInfoFrame GetInstance
    {
        get { return _instance; }
    }
    public delegate void OnItemCountChangedHandler();
    public event OnItemCountChangedHandler OnItemCountChangedEvent;
    void Awake()
    {
        _instance = this;
        itemName = transform.Find("BG/ItemNameLabel").GetComponent<UILabel>();
        des = transform.Find("BG/InfoLabel").GetComponent<UILabel>();
        blachLabel = transform.Find("BG/BatchUseButton/Label").GetComponent<UILabel>();
        itemSprite = transform.Find("BG/ItemBg/ItemSprite").GetComponent<UISprite>();
        closeButton = transform.Find("BG/CloseButton").GetComponent<UIButton>();
        useButton = transform.Find("BG/UseButton").GetComponent<UIButton>();
        blachUseButton = transform.Find("BG/BatchUseButton").GetComponent<UIButton>();
        EventDelegate ed1 = new EventDelegate(this, "CloseButtonClick");
        closeButton.onClick.Add(ed1);
        EventDelegate ed2 = new EventDelegate(this, "UseButtonClick");
        useButton.onClick.Add(ed2);
        EventDelegate ed3 = new EventDelegate(this, "BlachUseButton");
        blachUseButton.onClick.Add(ed3);
        this.gameObject.SetActive(false);

    }

    public void ShowItemDesUI(InventoryItem it, InventoryItemUI itUI)
    {
        if (it == null) return;
        this.it = it;
        this.itUI = itUI;
        this.gameObject.SetActive(true);
        itemName.text = it.inventory.Name;
        des.text = it.inventory.Des;
        blachLabel.text = "批量使用(" + it.Count + ")";
        itemSprite.spriteName = it.inventory.IconName;
    }


    public void CloseButtonClick()
    {
        this.it = null;
        this.itUI = null;
        this.gameObject.SetActive(false);
        InventoryUI.GetInstance.OnDisableButton();
    }
    public void UseButtonClick()
    {
        if (it.inventory.ItemsType == ItemType.Box)
        {
            PlayerInfo.GetInstance.OpenBox(1);
        }
        else
        {
            PlayerInfo.GetInstance.AddHP(it);
        }
        it.Count--;
        OnItemCountChangedEvent();
        CloseButtonClick();

    }
    public void BlachUseButton()
    {
        if (it.inventory.ItemsType == ItemType.Box)
        {
            PlayerInfo.GetInstance.OpenBox(it.Count);
        }
        else
        {
            PlayerInfo.GetInstance.AddHP(it, it.Count);
        }

        it.Count = 0;
        OnItemCountChangedEvent();
        CloseButtonClick();
    }


}
