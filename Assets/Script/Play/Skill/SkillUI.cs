using UnityEngine;
using System.Collections;

public class SkillUI : MonoBehaviour
{

    private UILabel skillName;
    private UILabel skillDes;
    private UILabel upgradeLabel;
    private UIButton upgradeButton;
    private UIButton closeButton;
    private Skill skill;
    private bool isShow;
    private TweenPosition tween;
    private static SkillUI _instance;
    public static SkillUI GetInstance
    {
        get
        {
            return _instance;

        }
    }

    void Awake()
    {
        _instance = this;
        skillName = transform.Find("SkillBG/SkillNameLabel").GetComponent<UILabel>();
        skillDes = transform.Find("SkillBG/SkillNameLabel/DesLabel").GetComponent<UILabel>();
        upgradeButton = transform.Find("UpgrateButton").GetComponent<UIButton>();
        upgradeLabel = transform.Find("UpgrateButton/Label").GetComponent<UILabel>();
        closeButton = transform.Find("CloseButton").GetComponent<UIButton>();
        tween = transform.GetComponent<TweenPosition>();
    }

    private void Start()
    {
        EventDelegate ed1 = new EventDelegate(this, "CloseButton");
        closeButton.onClick.Add(ed1);
        EventDelegate ed2 = new EventDelegate(this, "UpgradeButton");
        upgradeButton.onClick.Add(ed2);
        DisableButton("请选择技能");
        EventDelegate ed = new EventDelegate(this, "Hide");
        tween.onFinished.Add(ed);
        this.gameObject.SetActive(false);
    }


    public void EnableButton(string label = "")
    {
        upgradeButton.SetState(UIButtonColor.State.Normal, true);
        upgradeButton.GetComponent<BoxCollider>().enabled = true;
        if (label != null)
        {
            upgradeLabel.text = label;
        }
    }

    public void DisableButton(string label = "")
    {
        upgradeButton.SetState(UIButtonColor.State.Disabled, true);
        upgradeButton.GetComponent<BoxCollider>().enabled = false;
        skillName.text = "";
        skillDes.text = "";
        if (label != null)
        {
            upgradeLabel.text = label;
        }
    }
    void OnSkillClick(Skill skill)
    {

        this.skill = skill;
        PlayerInfo info = PlayerInfo.GetInstance;
        if (500 * (skill.Level + 1) < info.Coin && skill.Level < info.Level)
        {
            EnableButton("升级");
        }
        else if (500 * (skill.Level + 1) > info.Coin)
        {
            DisableButton("金币不足");
        }
        else if (skill.Level >= info.Level)
        {
            DisableButton("最大等级");
        }
        //更新技能名称等级, 和介绍,升级按键的显示
        skillName.text = skill.Name + "Lv." + skill.Level;
        skillDes.text = "当前技能攻击力:" + (skill.Damage * skill.Level) + '\n' + "下一级技能攻击力:" + (skill.Damage * (skill.Level + 1)) + '\n' + "升级所需金币:" + (500 * (skill.Level + 1));

    }

    public void Show()
    {
        if (isShow == false)
        {
            this.gameObject.SetActive(true);
            tween.PlayForward();
            isShow = true;
        }
        else
        {
            tween.PlayReverse();
            isShow = false;
        }
    }
    void Hide()
    {
        if (isShow == false)
        {
            this.gameObject.SetActive(false);
        }
    }

    void CloseButton()
    {
        tween.PlayReverse();
        isShow = false;
    }

    void UpgradeButton()
    {
        bool isSuccess = PlayerInfo.GetInstance.UseCoin(500 * (this.skill.Level + 1));

        if (isSuccess)
        {

            this.skill.Level++;
            OnSkillClick(this.skill);

        }
        else
        {
            DisableButton("金币不足");
        }
    }

}

