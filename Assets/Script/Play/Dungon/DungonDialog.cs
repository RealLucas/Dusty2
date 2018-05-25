using UnityEngine;
using System.Collections;

public class DungonDialog : MonoBehaviour
{
    private UILabel des;
    private UILabel energyTag;
    private UILabel energyNum;
    private UIButton closeButton;
    private UIButton enterButton;
    private TweenScale tween;
    private DungonButton dungonButton;

    void Awake()
    {
        des = transform.Find("DesLabel").GetComponent<UILabel>();
        energyTag = transform.Find("TagLabel").GetComponent<UILabel>();
        energyNum = transform.Find("NumLabel").GetComponent<UILabel>();
        closeButton = transform.Find("CloseButton").GetComponent<UIButton>();
        enterButton = transform.Find("EnterButton").GetComponent<UIButton>();
        tween = transform.GetComponent<TweenScale>();

        EventDelegate ed1 = new EventDelegate(this, "OnClose");
        closeButton.onClick.Add(ed1);
        EventDelegate ed2 = new EventDelegate(this, "OnEnter");
        enterButton.onClick.Add(ed2);
    }

    void ShowDialog()
    {
        tween.PlayForward();
        des.text = "这里是爱神的箭阿萨圣诞节萨达四大四大";
        energyTag.gameObject.SetActive(true);
        energyNum.text = "3";
        enterButton.gameObject.SetActive(true);
    }
    void ShowWarn()
    {
        tween.PlayForward();
        des.text = "等级不足";
        energyTag.gameObject.SetActive(false);
        energyNum.text = "";
        enterButton.gameObject.SetActive(false);
    }

    public void Show(DungonButton dungonButton)
    {
        this.dungonButton = dungonButton;
        if (dungonButton.needLevel <= PlayerInfo.GetInstance.Level)
        {
            ShowDialog();
        }
        else 
        {
            ShowWarn();
        }
    }

    void Hide()
    {
        tween.PlayReverse();
    }
    void OnEnter()
    {
        //进入游戏场景
    }
    void OnClose()
    {
        Hide();
    }
}
