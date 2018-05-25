using UnityEngine;
using System.Collections;

public class FunctionBar : MonoBehaviour
{

    private UIButton taskBar;
    private UIButton systemBar;
    private UIButton skillBar;
    private UIButton fightBar;
    private UIButton shopBar;
    private UIButton inventoryBar;
    private KnapStack ks;
    void Start()
    {

        taskBar = transform.Find("TaskBar").GetComponent<UIButton>();
        systemBar = transform.Find("SystemBar").GetComponent<UIButton>();
        skillBar = transform.Find("SkillBar").GetComponent<UIButton>();
        fightBar = transform.Find("FightBar").GetComponent<UIButton>();
        shopBar = transform.Find("ShopBar").GetComponent<UIButton>();
        inventoryBar = transform.Find("InventoryBar").GetComponent<UIButton>();
        ClickButton();
    }

    void ClickButton()
    {
        ks = KnapStack.GetInstance;
        EventDelegate ed1 = new EventDelegate(ks, "Show");
        inventoryBar.onClick.Add(ed1);

        EventDelegate ed2 = new EventDelegate(TaskUI.GetInstance, "Show");
        taskBar.onClick.Add(ed2);

        EventDelegate ed3 = new EventDelegate(SkillUI.GetInstance, "Show");
        skillBar.onClick.Add(ed3);
    }
}
