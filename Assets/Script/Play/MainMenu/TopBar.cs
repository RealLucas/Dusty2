using UnityEngine;
using System.Collections;

public class TopBar : MonoBehaviour
{

    private UILabel coinLabel;
    private UILabel diamondLabel;
    private UIButton coinPlusButton;
    private UIButton diamondPlusButton;
    void Awake() 
    {
        coinLabel = transform.Find("CoinBar/CoinLabel").GetComponent<UILabel>();
        diamondLabel = transform.Find("DiamondBar/DiamondLabel").GetComponent<UILabel>();
        coinPlusButton = transform.Find("CoinBar/AddButton").GetComponent<UIButton>();
        diamondPlusButton = transform.Find("DiamondBar/AddButton").GetComponent<UIButton>();
    }

    void Start()
    {   
        //注册
        PlayerInfo.GetInstance.OnPlayerInfoChangedEvent += OnPlayerInfoChange;
    }
    private void OnDestroy()
    {
        //注销
        PlayerInfo.GetInstance.OnPlayerInfoChangedEvent -= OnPlayerInfoChange;
    }

    void OnPlayerInfoChange(PlayerInfoType type)
    {
        if (type == PlayerInfoType.All || type == PlayerInfoType.Coin || type == PlayerInfoType.Diamond)
        {
            UpdateShow();
        }
    }

    void UpdateShow()
    {
        this.coinLabel.text = PlayerInfo.GetInstance.Coin.ToString();
        this.diamondLabel.text = PlayerInfo.GetInstance.Diamond.ToString();
    }
}
