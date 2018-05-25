using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{

    private InventoryItemUI[] inventoryItemUIList;
    private InventoryItemUI[] InventoryItemUIList
    {
        get
        {
            if (inventoryItemUIList == null)
            {
                inventoryItemUIList = this.GetComponentsInChildren<InventoryItemUI>();

            }
            return inventoryItemUIList;
        }
    }
    private InventoryItemUI itUI;
    private static InventoryUI _instance;
    public static InventoryUI GetInstance
    {
        get { return _instance; }
    }
    private UIButton sortButton;
    private UIButton sellButton;
    private UILabel pageLabel;
    private UILabel priceLabel;
    public int pageNumber;


    private void Awake()
    {
        _instance = this;
        sortButton = transform.Find("SortButton").GetComponent<UIButton>();
        sellButton = transform.Find("SeleButton").GetComponent<UIButton>();
        priceLabel = transform.Find("PriceBG/Label").GetComponent<UILabel>();
        pageLabel = transform.Find("PageLabel").GetComponent<UILabel>();
        EventDelegate ed1 = new EventDelegate(this, "SortButton");
        EventDelegate ed2 = new EventDelegate(this, "SellButton");
        sortButton.onClick.Add(ed1);
        sellButton.onClick.Add(ed2);
        OnDisableButton();
    }
    void Start()
    {
        InventoryManager.GetInstance.OnInventoryItemChanged += OnInventoryItemChanged;

    }


    private void OnDestroy()
    {
        InventoryManager.GetInstance.OnInventoryItemChanged -= OnInventoryItemChanged;
    }

    void OnInventoryItemChanged()
    {
        UpdateInfoShow();
        pageLabel.text = InventoryManager.GetInstance.inventoryItemList.Count + "/" + inventoryItemUIList.Length;
    }

    void UpdateInfoShow()
    {
        InventoryItem inventoryItem = null;
        InventoryManager inventoryManager = InventoryManager.GetInstance;
        for (int i = 0; i < inventoryManager.inventoryItemList.Count; i++)
        {
            inventoryItem = inventoryManager.inventoryItemList[i];
            InventoryItemUIList[i].SetInventoryItemShow(inventoryItem);
        }
        for (int i = inventoryManager.inventoryItemList.Count; i < InventoryItemUIList.Length; i++)
        {

            InventoryItemUIList[i].Clear();

        }
    }
    //给背包添加单个物品显示
    public void AddInventory(InventoryItem it)
    {
        //InventoryManager.GetInstance.inventoryItemList.Add(it);
        foreach (InventoryItemUI item in InventoryItemUIList)
        {
            if (item.it == null)
            {
                item.SetInventoryItemShow(it);
                break;
            }
        }
    }

    //背包整理
    public void SortButton()
    {
        InventoryItem inventoryItem = null;
        InventoryManager inventoryManager = InventoryManager.GetInstance;
        int n = 0;
        for (int i = 0; i < inventoryManager.inventoryItemList.Count; i++)
        {
            inventoryItem = inventoryManager.inventoryItemList[i];

            if (inventoryItem.isDrass == false)
            {
                InventoryItemUIList[n].SetInventoryItemShow(inventoryItem);
                n++;
            }

        }
        pageNumber = n;
        for (int i = n; i < InventoryItemUIList.Length; i++)
        {

            InventoryItemUIList[i].Clear();

        }
    }

    //物品出售
    private void SellButton()
    {
        PlayerInfo.GetInstance.GetCoin(itUI.it.inventory.Price);
        itUI.it.Count = 0;
        if (itUI.it.inventory.ItemsType == ItemType.Equip)
        {
            transform.parent.GetChild(4).SendMessage("CloseButtonClick");

        }
        else
        {
            transform.parent.GetChild(0).SendMessage("CloseButtonClick");
        }
        InventoryUI.GetInstance.pageNumber--;
        InventoryUI.GetInstance.UpdateShowPageNumber();
        itUI.OnItemCountChanged();
    }
    //更新物品页面显示
    public void UpdateShowPageNumber()
    {
        int sumNumber = InventoryItemUIList.Length;
        pageLabel.text = pageNumber + "/" + sumNumber;
    }

    public void OnDisableButton()
    {
        sellButton.GetComponent<UIPlaySound>().enabled = false;
        sellButton.SetState(UIButtonColor.State.Disabled, true);
        sellButton.GetComponent<BoxCollider>().enabled = false;
        priceLabel.text = "";
    }
    public void OnEnableButton(InventoryItemUI itUI)
    {
        this.itUI = itUI;
        sellButton.SetState(UIButtonColor.State.Normal, true);
        sellButton.GetComponent<BoxCollider>().enabled = true;
        sellButton.GetComponent<UIPlaySound>().enabled = true;
        priceLabel.text = (itUI.it.Count * itUI.it.inventory.Price).ToString();
    }
}
