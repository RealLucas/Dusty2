using UnityEngine;
using System.Collections;

public class EquipInfoFrame : MonoBehaviour
{

    private UILabel equipName;
    private UILabel quality;
    private UILabel damage;
    private UILabel hP;
    private UILabel power;
    private UILabel des;
    private UILabel startLevel;
    private UISprite equipSprite;
    private UIButton closeButton;
    private UIButton equipButton;
    private UIButton levelUpButton;
    private InventoryItem it;
    private InventoryItemUI itUI;
    private UILabel equipLabel;
    private KnapStackRoleEquip kSRE;
    private EventDelegate edEquip = new EventDelegate();
    private void Awake()
    {
        equipName = transform.Find("EquipBG/EquipNameLabel").GetComponent<UILabel>();
        quality = transform.Find("EquipBG/Order/OrderLabel").GetComponent<UILabel>();
        damage = transform.Find("EquipBG/Attack/AttackLabel").GetComponent<UILabel>();
        hP = transform.Find("EquipBG/HP/HPLabel").GetComponent<UILabel>();
        power = transform.Find("EquipBG/Label/Label").GetComponent<UILabel>();
        des = transform.Find("EquipBG/InfoLabel").GetComponent<UILabel>();
        startLevel = transform.Find("EquipBG/StartLevel/Label").GetComponent<UILabel>();
        equipSprite = transform.Find("EquipBG/ItemBg/EquipSprite").GetComponent<UISprite>();
        closeButton = transform.Find("EquipBG/CloseButton").GetComponent<UIButton>();
        equipButton = transform.Find("EquipBG/EquipButton").GetComponent<UIButton>();
        levelUpButton = transform.Find("EquipBG/LevelUpButton").GetComponent<UIButton>();
        equipLabel = transform.Find("EquipBG/EquipButton/Label").GetComponent<UILabel>();
        EventDelegate ed1 = new EventDelegate(this, "CloseButtonClick");
        closeButton.onClick.Add(ed1);
        EventDelegate ed3 = new EventDelegate(this, "LevelUpButtonClick");
        levelUpButton.onClick.Add(ed3);
        this.gameObject.SetActive(false);
    }

    public void ShowEquipInfoUI(InventoryItem it, InventoryItemUI itemUI, KnapStackRoleEquip kSRE, bool isLeft = true)
    {
        this.gameObject.SetActive(true);
        this.it = it;
        this.itUI = itemUI;
        this.kSRE = kSRE;
        Vector3 pos = this.transform.localPosition;
        equipName.text = it.inventory.Name;
        quality.text = it.inventory.Quality.ToString();
        damage.text = it.inventory.Damge.ToString();
        hP.text = it.inventory.HP.ToString();
        startLevel.text = it.Level.ToString();
        power.text = it.inventory.Power.ToString();
        des.text = it.inventory.Des;
        equipSprite.spriteName = it.inventory.IconName;

        if (isLeft)
        {
            equipLabel.text = "装备";
            this.transform.localPosition = new Vector3(-Mathf.Abs(30), pos.y, pos.z);
            edEquip.Set(this, "EquipButtonClick");

        }
        else
        {
            equipLabel.text = "卸下";
            edEquip.Set(this, "EquipPutOff");
            this.transform.localPosition = new Vector3(Mathf.Abs(220), pos.y, pos.z);
        }

        equipButton.onClick.Add(edEquip);
    }

    public void CloseButtonClick()
    {
        this.it = null;
        this.itUI = null;
        edEquip.oneShot = true;
        equipButton.onClick.Clear();
        this.gameObject.SetActive(false);
        InventoryUI.GetInstance.OnDisableButton();
    }
    public void EquipPutOff()
    {
        PlayerInfo.GetInstance.OnEquipOff(it, kSRE);
        CloseButtonClick();
    }

    public void EquipButtonClick()
    {

        PlayerInfo.GetInstance.OnEquipOn(it, itUI, kSRE);
        CloseButtonClick();
    }
    public void LevelUpButtonClick()
    {
        int coin = (this.it.Level + 1) * this.it.inventory.Price;
        bool isSuccess = PlayerInfo.GetInstance.UseCoin(coin);
        if (isSuccess)
        {
            this.it.Level++;
            startLevel.text = this.it.Level.ToString();
            PlayerInfo.GetInstance.PowerAddByLevel(it);
        }
        else
        {
            MessageManager.GetInstance.ShowMessageUI("金币不足,无法升级");
        }
    }
}
