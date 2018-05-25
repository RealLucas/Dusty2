using UnityEngine;
using System.Collections;

public class KnapStackRoleEquip : MonoBehaviour
{

    private Inventory inventory;
    private bool isExsit;
    // private object[] objectArry = new object[3];
    private InventoryItem it;
    private UISprite _sprite;
    private UISprite Sprite
    {
        get
        {
            if (_sprite == null)
            {
                _sprite = this.GetComponent<UISprite>();
            }
            return _sprite;
        }
    }

    public void SetByID(int id)
    {
        inventory = null;

        isExsit = false;
        isExsit = InventoryManager.GetInstance.InventoryDic.TryGetValue(id, out inventory);
        if (isExsit)
        {
            Sprite.spriteName = inventory.IconName;
        }
    }

    public void SetByInventoryItem(InventoryItem it)
    {
        if (it == null) return;

        this.it = it;
        Sprite.spriteName = it.inventory.IconName;
    }


    void OnPress(bool isPress)
    {
        if (isPress)
        {
            if (it == null) return;
            object[] objectArry = new object[3];
            objectArry[0] = it;
            objectArry[1] = false;
            objectArry[2] = this;
            transform.parent.parent.SendMessage("OnEquipClick", objectArry);

            //OnClear();
        }
    }

    public void OnClear()
    {
        it = null;
        inventory = null;
        Sprite.spriteName = "bg_道具";
    }

}
