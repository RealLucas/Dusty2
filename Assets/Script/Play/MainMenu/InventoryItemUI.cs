using UnityEngine;
using System.Collections;

public class InventoryItemUI : MonoBehaviour
{

    private UISprite _sprite;
    private UILabel _label;
    private UISprite Sprite
    {
        get
        {
            if (_sprite == null)
            {
                _sprite = transform.Find("InventoryItemSprite").GetComponent<UISprite>();
            }
            return _sprite;
        }
    }
    public InventoryItem it;
    private UILabel Label
    {
        get
        {
            if (_label == null)
            {
                _label = transform.Find("NumberLabel").GetComponent<UILabel>();
            }
            return _label;
        }
    }
    private static InventoryItemUI _instance;
    public static InventoryItemUI GetInstance
    {
        get { return _instance; }
    }



    private void Awake()
    {
        _instance = this;
        
    }
    private void Start()
    {
        ItemInfoFrame.GetInstance.OnItemCountChangedEvent += OnItemCountChanged;
    }

    //更新显示物品栏物品的图标显示和数量显示
    public void SetInventoryItemShow(InventoryItem item)
    {
        if (item == null) return;
        it = item;
        Sprite.spriteName = item.inventory.IconName;
        Label.text = item.Count.ToString();
        if (item.Count == 1) _label.text = "";

    }

    //清空
    public void Clear()
    {
        it = null;
        Sprite.spriteName = "bg_道具";
        Label.text = "";
    }
    void OnPress(bool isPress)
    {
        if (isPress)
        {
            if (it != null)
            {
                object[] objectArry = new object[3];
                objectArry[0] = it;
                objectArry[1] = true;
                objectArry[2] = this;
                this.transform.parent.parent.parent.parent.SendMessage("OnEquipClick", objectArry);
            }
        }
    }



    //处理道具的减少
    public void OnItemCountChanged()
    {
        if (it == null) return;
        if (it.Count <= 0)
        {
            //小于等于0
            InventoryManager.GetInstance.inventoryItemList.Remove(it);
            Clear();
        }
        else if (it.Count == 1)
        {
            //等于1
            _label.text = "";
        }
        else
        {
            //大于1
            _label.text = it.Count.ToString();
        }

    }
}
