using UnityEngine;
using System.Collections;

public class PlayerBar : MonoBehaviour
{

    private UISprite headSprite;
    private UILabel nameLabel;
    private UILabel levelLabel;
    private UISlider energySlider;
    private UILabel energyLabel;
    private UISlider liLianSlider;
    private UILabel liLianLabel;
    private UIButton energyPlusButton;
    private UIButton liLianPlusButton;
    private UIButton showButton;
    void Awake()
    {
        headSprite = transform.Find("HeadSprite").GetComponent<UISprite>();
        nameLabel = transform.Find("NameLabel").GetComponent<UILabel>();
        levelLabel = transform.Find("LevelLabel").GetComponent<UILabel>();
        energySlider = transform.Find("EnegtSlider").GetComponent<UISlider>();
        energyLabel = transform.Find("EnegtSlider/NumberLabel").GetComponent<UILabel>();
        energyPlusButton = transform.Find("EnegtSlider/AddButton").GetComponent<UIButton>();
        liLianSlider = transform.Find("LiLianSlider").GetComponent<UISlider>();
        liLianLabel = transform.Find("LiLianSlider/NumberLabel").GetComponent<UILabel>();
        liLianPlusButton = transform.Find("LiLianSlider/AddButton").GetComponent<UIButton>();
        showButton = transform.Find("ShowButton").GetComponent<UIButton>();
        EventDelegate ed = new EventDelegate(this, "ShowPlayerStatusBar");
        showButton.onClick.Add(ed);
    }

    void Start()
    {
        //注册事件
        PlayerInfo.GetInstance.OnPlayerInfoChangedEvent += OnPlayerInfoChange;
    }

    private void OnDestroy()
    {
        //注销事件
        PlayerInfo.GetInstance.OnPlayerInfoChangedEvent -= OnPlayerInfoChange;
    }
    void OnPlayerInfoChange(PlayerInfoType type)
    {
        if (type == PlayerInfoType.All || type == PlayerInfoType.Energy || type == PlayerInfoType.HeadPortrait || type == PlayerInfoType.Level || type == PlayerInfoType.LiLian || type == PlayerInfoType.Name)
        {
            UpdateInfoShow();
        }
    }
    void UpdateInfoShow()
    {
        PlayerInfo info = PlayerInfo.GetInstance;
        this.nameLabel.text = info.Name;
        this.headSprite.spriteName = info.HeadPortrait;
        this.levelLabel.text = info.Level.ToString();
        this.energyLabel.text = info.Energy.ToString()+"/100";
        this.energySlider.value = info.Energy / 100f;
        this.liLianLabel.text = info.LiLian.ToString()+"/50";
        this.liLianSlider.value = info.LiLian / 50f;


    }
    void ShowPlayerStatusBar()
    {
        PlayerStatus.GetInstance.ShowButtonClick();
    }
}
