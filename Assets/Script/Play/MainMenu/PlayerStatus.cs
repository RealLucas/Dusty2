using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour
{
    #region GameObject
    private UISprite headSprite;
    private UILabel levelLabel;
    private UILabel nameLabel;
    private UILabel powerLabel;
    private UILabel expLabel;
    private UISlider expSlider;
    private UILabel diamondLabel;
    private UILabel coinLabel;
    private UILabel energyLabel;
    private UILabel energyRecoverTimeLabel;
    private UILabel energyAllRecoverTimerLabel;
    private UILabel liLianLabel;
    private UILabel lilianRecoverTimeLabel;
    private UILabel liLianAllRecoverTimeLabel;
    private UIButton changeNameButton;
    private UIButton closedButton;
    private TweenPosition tween;
    private static PlayerStatus _instance;
    public static PlayerStatus GetInstance
    {
        get { return _instance; }
    }

    private GameObject changeNameUI;
    private UIInput nameInput;
    private UIButton confirmButton;
    private UIButton cancelButton;
    #endregion

    void Awake()
    {
        _instance = this;
        headSprite = transform.Find("HeadSprite").GetComponent<UISprite>();
        levelLabel = transform.Find("LevelLabel").GetComponent<UILabel>();
        nameLabel = transform.Find("NameLabel").GetComponent<UILabel>();
        powerLabel = transform.Find("PowerLabel/PowerNumber").GetComponent<UILabel>();
        expLabel = transform.Find("EXP_BG/NumberLabel").GetComponent<UILabel>();
        expSlider = transform.Find("EXP_BG/EXP_bar").GetComponent<UISlider>();
        diamondLabel = transform.Find("Diiamond/NumberLabel").GetComponent<UILabel>();
        coinLabel = transform.Find("Coin/NumberLabel").GetComponent<UILabel>();
        energyLabel = transform.Find("EnegyLabel/NumberLabel").GetComponent<UILabel>();
        energyRecoverTimeLabel = transform.Find("EnegyLabel/EnegyBackLabel/TimeLabel").GetComponent<UILabel>();
        energyAllRecoverTimerLabel = transform.Find("EnegyLabel/EnegyBackLabel2/TimeLabel").GetComponent<UILabel>();
        liLianLabel = transform.Find("LiLianLabel/NumberLabel").GetComponent<UILabel>();
        lilianRecoverTimeLabel = transform.Find("LiLianLabel/EnegyBackLabel/TimeLabel").GetComponent<UILabel>();
        liLianAllRecoverTimeLabel = transform.Find("LiLianLabel/EnegyBackLabel2/TimeLabel").GetComponent<UILabel>();
        changeNameButton = transform.Find("ChangeNameButton").GetComponent<UIButton>();
        closedButton = transform.Find("CloseButton").GetComponent<UIButton>();

        //注册事件,绑定按键
        tween = this.GetComponent<TweenPosition>();
        changeNameUI = transform.Find("ChangeNameUI").gameObject;
        confirmButton = transform.Find("ChangeNameUI/ConfirmButton").GetComponent<UIButton>();
        cancelButton = transform.Find("ChangeNameUI/CancelButton").GetComponent<UIButton>();
        nameInput = transform.Find("ChangeNameUI/NameInput").GetComponent<UIInput>();
        EventDelegate ed = new EventDelegate(this, "ClosedButtonClick");
        closedButton.onClick.Add(ed);
        EventDelegate ed2 = new EventDelegate(this, "OnChangeNameButtonClick");
        changeNameButton.onClick.Add(ed2);
        EventDelegate ed3 = new EventDelegate(this, "OnConfirmButtonClick");
        confirmButton.onClick.Add(ed3);
        EventDelegate ed4 = new EventDelegate(this, "OnCancelButtonClick");
        cancelButton.onClick.Add(ed4);
        closedButton.onClick.Add(ed4);
        changeNameUI.SetActive(false);
        PlayerInfo.GetInstance.OnPlayerInfoChangedEvent += OnPlayerInfoChanged;
    }


    void Start()
    {
        
    }

    private void Update()
    {
        UpdateEnergyAndLilian();//更新体力和历练回复及时间显示
    }

    private void OnDestroy()
    {
        PlayerInfo.GetInstance.OnPlayerInfoChangedEvent -= OnPlayerInfoChanged;
    }

    void OnPlayerInfoChanged(PlayerInfoType type)
    {
        UpdateShow();
    }

    //更新面板属性显示
    void UpdateShow()
    {
        PlayerInfo info = PlayerInfo.GetInstance;
        this.headSprite.spriteName = info.HeadPortrait;
        this.levelLabel.text = info.Level.ToString();
        this.nameLabel.text = info.Name;
        this.powerLabel.text = info.Power.ToString();
        int requestExp = GameControl.GetRequireByLevel(info.Level + 1);
        this.expLabel.text = info.Exp + "/" + requestExp;
        this.expSlider.value = info.Exp / (float)requestExp;
        this.diamondLabel.text = info.Diamond.ToString();
        this.coinLabel.text = info.Coin.ToString();

        UpdateEnergyAndLilian();//更新体力和历练回复及时间显示

    }

    //更新体力和历练的自动回复
    void UpdateEnergyAndLilian()
    {
        PlayerInfo info = PlayerInfo.GetInstance;

        //体力
        this.energyLabel.text = info.Energy + "/100";
        if (info.Energy >= info.maxEnergy)
        {
            //体力满,显示都为00:00:00
            energyRecoverTimeLabel.text = "00:00:00";
            energyAllRecoverTimerLabel.text = "00:00:00";
        }
        else
        {
            //体力未满

            //(每点体力回复)
            int second = (60 - (int)info.energyTimer);
            string s = second > 9 ? second.ToString() : "0" + second;
            energyRecoverTimeLabel.text = "00:00:" + s;

            //(剩余所有体力恢复时间)
            int remain = info.maxEnergy - 1 - info.Energy; //-1 因为最后"秒"计时占了一个
            int hours = remain / 60;
            int mintus = remain % 60;
            string h = hours > 9 ? hours.ToString() : "0" + hours;
            string m = mintus > 9 ? mintus.ToString() : "0" + mintus;
            energyAllRecoverTimerLabel.text = h + ":" + m + ":" + s;
        }

        //历练
        this.liLianLabel.text = info.LiLian + "/50";
        if (info.LiLian >= info.maxLiLian)
        {
            //历练满,显示00:00:00
            lilianRecoverTimeLabel.text = "00:00:00";
            liLianAllRecoverTimeLabel.text = "00:00:00";
        }
        else
        {
            //未满

            //每点历练回复时间
            int lilianSecond = (60 - (int)info.liLianTimer);
            string lilianS = lilianSecond > 9 ? lilianSecond.ToString() : "0" + lilianSecond;
            lilianRecoverTimeLabel.text = "00:00:" + lilianS;

            //剩余所有回复时间
            int lilianRemain = info.maxLiLian - 1 - info.LiLian;
            int lilianHours = lilianRemain / 60;
            int lilianMintus = lilianRemain % 60;
            string lilianH = lilianHours > 9 ? lilianHours.ToString() : "0" + lilianHours;
            string lilianM = lilianMintus > 9 ? lilianMintus.ToString() : "0" + lilianMintus;
            liLianAllRecoverTimeLabel.text = lilianH + ":" + lilianM + ":" + lilianS;
        }
    }
    public void ShowButtonClick()
    {
        tween.PlayForward();
    }
    public void ClosedButtonClick()
    {
        tween.PlayReverse();
    }
    public void OnChangeNameButtonClick()
    {
        changeNameUI.SetActive(true);
    }

    public void OnConfirmButtonClick()
    {
        if (nameInput.value == null || nameInput.value == "") return;
        PlayerInfo.GetInstance.OnChangeName(nameInput.value);
        changeNameUI.SetActive(false);
    }
    public void OnCancelButtonClick()
    {

        changeNameUI.SetActive(false);
    }
}
