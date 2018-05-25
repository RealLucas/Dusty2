using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartMenuControl : MonoBehaviour
{
    public static StartMenuControl _instance;

    public TweenScale startMenuTween, loginMenuTween, regestTween, serverListTween;
    public TweenPosition characterSelectedTween;
    public UILabel startUserName, serverNumber;
    public UIInput loginUserName, loginPassword;
    public UIInput regestUserName, regestPassword, regestPasswordConfirm;
    public UIInput nameInput;

    public static string password, userName;
    public static ServerPropety sp;

    public float animTime = 0.4f;
    public GameObject serverRedPrefab, serverGreenPrefab, gridParent;
    public GameObject selectedServer;
    public UIPanel characterPanel;
    private GameObject inistGO;

    public int serverNum = 20;
    public bool isInist;

    private  GameObject selectedCharacterGo;
    public List<GameObject> selectedPrefabArry = new List<GameObject>();
    public List<GameObject> showPrefabArry = new List<GameObject>();
    public Transform characterParent;
    private GameObject inistCharacterGo;
    public int level = 1;
    public UILabel playerName, levelLabel;
    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        InistServerList();
    }
    public static StartMenuControl GetInstance()
    {
        if (_instance == null)
        {
            return new StartMenuControl();
        }
        return _instance;
    }

    //初始化服务器列表
    private void InistServerList()
    {
        if (isInist) return;
        for (int i = 0; i < serverNum; i++)
        {
            int n = Random.Range(0, 100);
            if (n <= 50)
            {
                //流畅
                inistGO = NGUITools.AddChild(gridParent, serverGreenPrefab);
                inistGO.transform.SetParent(gridParent.transform);
            }
            else
            {
                //火爆
                inistGO = NGUITools.AddChild(gridParent, serverRedPrefab);
                inistGO.transform.SetParent(gridParent.transform);
            }
            ServerPropety sp = inistGO.GetComponent<ServerPropety>();
            sp.ServerName = (i + 1) + "区 龙叩首";
            sp.playerNumber = n;
            sp.ip = "127.0.0.1:9080";

        }
        isInist = true;
    }

    //StartMenu
    public void StartUserNameClick()
    {
        StartCoroutine(UITweenForward(startMenuTween, startMenuTween.transform.gameObject));
        StartCoroutine(UITweenForward(loginMenuTween, loginMenuTween.transform.gameObject));
    }

    public void StartServerNumberClick()
    {
        StartCoroutine(UITweenForward(startMenuTween, startMenuTween.transform.gameObject));
        StartCoroutine(UITweenForward(serverListTween, serverListTween.transform.gameObject));
    }

    public void StartEnterGameClick()
    {
        //TODO
        //连接服务器,验证账号和密码
        //错误弹错误提示
        startMenuTween.transform.gameObject.SetActive(false);
        characterPanel.gameObject.SetActive(true);
        characterPanel.alpha = Mathf.Lerp(0, 1, 1.5f);
    }

    //LoginMenu
    public void LoginConfirmClick()
    {
        password = loginPassword.value;
        userName = loginUserName.value;
        startUserName.text = userName;
        StartCoroutine(UITweenReverse(loginMenuTween, loginMenuTween.transform.gameObject));
        StartCoroutine(UITweenReverse(startMenuTween, startMenuTween.transform.gameObject));
    }

    public void LoginRegestClick()
    {
        //进入注册面板
        StartCoroutine(UITweenReverse(loginMenuTween, loginMenuTween.transform.gameObject));
        StartCoroutine(UITweenForward(regestTween, regestTween.transform.gameObject));
    }

    public void LoginClosedClick()
    {
        StartCoroutine(UITweenReverse(loginMenuTween, loginMenuTween.transform.gameObject));
        StartCoroutine(UITweenReverse(startMenuTween, startMenuTween.transform.gameObject));
    }

    //ResgestMenu
    public void RegestConfirmClick()
    {
        password = regestPassword.value;
        userName = regestUserName.value;
        //TODO
        //连接服务器,验证密码和账号
        //连接成功进入游戏
    }

    public void RegestCancelClick()
    {
        StartCoroutine(UITweenReverse(regestTween, regestTween.transform.gameObject));
        StartCoroutine(UITweenForward(loginMenuTween, loginMenuTween.transform.gameObject));
    }

    public void RegestColsedClick()
    {
        StartCoroutine(UITweenReverse(regestTween, regestTween.transform.gameObject));
        StartCoroutine(UITweenForward(loginMenuTween, loginMenuTween.transform.gameObject));
    }

    private IEnumerator UITweenForward(TweenScale tween, GameObject go)
    {
        go.SetActive(true);
        tween.PlayForward();
        yield return new WaitForSeconds(animTime);
        if (go.name == "StartMenu")
        {
            go.SetActive(false);
        }
    }
    private IEnumerator UIPosTweenForward(TweenPosition tween, GameObject go)
    {
        go.SetActive(true);
        tween.PlayForward();
        yield return new WaitForSeconds(animTime);
        if (go.name == "StartMenu")
        {
            go.SetActive(false);
        }
    }
    private IEnumerator UIPosTweenReverse(TweenPosition tween, GameObject go)
    {
        go.SetActive(true);
        tween.PlayReverse();
        yield return new WaitForSeconds(animTime);
        go.SetActive(false);
    }

    private IEnumerator UITweenReverse(TweenScale tween, GameObject go)
    {
        go.SetActive(true);
        tween.PlayReverse();
        yield return new WaitForSeconds(animTime);
        if (go.name != "StartMenu")
        {
            Debug.Log("隐藏");
            go.SetActive(false);
        }
    }

    public void OnServerButtonClick(GameObject serverGo)
    {
        sp = serverGo.GetComponent<ServerPropety>();
        selectedServer.GetComponent<UISprite>().spriteName = serverGo.GetComponent<UISprite>().spriteName;
        selectedServer.transform.GetChild(0).GetComponent<UILabel>().text = sp.ServerName;
        selectedServer.transform.GetChild(0).GetComponent<UILabel>().color = serverGo.transform.GetChild(0).GetComponent<UILabel>().color;
    }

    public void OnSelectedServerButtonClick()
    {
        StartCoroutine(UITweenReverse(serverListTween, serverListTween.transform.gameObject));
        StartCoroutine(UITweenReverse(startMenuTween, startMenuTween.transform.gameObject));
        serverNumber.text = sp.ServerName;
    }

    public void GetSelectedCharater(GameObject CharacterGo)
    {
        if (selectedCharacterGo != null)
        {
            //把未选择的角色变回原来的大小
            iTween.ScaleTo(selectedCharacterGo, new Vector3(1, 1, 1), 0.5f);
        }
        //放大选中的人物角色
        iTween.ScaleTo(CharacterGo, new Vector3(1.3f, 1.3f, 1.3f), 0.5f);
        selectedCharacterGo = CharacterGo;
    }
    private void InistCharacter()
    {
        //要先销毁存在的角色对象
        if (characterParent.GetComponentInChildren<SpinWithMouse>())
        {
            GameObject.Destroy(characterParent.GetComponentInChildren<SpinWithMouse>().gameObject);
        }
        int index = -1;
        index = selectedPrefabArry.IndexOf(selectedCharacterGo);
        if (index == -1) return;
        inistCharacterGo = GameObject.Instantiate(showPrefabArry[index]);
        inistCharacterGo.transform.SetParent(characterParent);
        inistCharacterGo.transform.localScale = new Vector3(1, 1, 1);
        inistCharacterGo.transform.localPosition = Vector3.zero;
        inistCharacterGo.transform.localRotation = Quaternion.identity;
    }


    public void BackButtonClick()
    {
        //返回开始界面
        StartCoroutine(UIPosTweenReverse(characterSelectedTween, characterSelectedTween.transform.gameObject));
        characterPanel.gameObject.SetActive(true);
        characterPanel.alpha = Mathf.Lerp(0, 1, 1.5f);
    }
    public void ConfirmNameInputButton()
    {
        startUserName.text = nameInput.value;
        //返回开始界面
        BackButtonClick();
        //更新等级,名字
        levelLabel.text = "Lv." + level;
        playerName.text = nameInput.value;
        InistCharacter();
    }
    public void ChangeCharacterButton()
    {
        characterPanel.alpha = Mathf.Lerp(1, 0, 0.5f);
        characterPanel.gameObject.SetActive(false);
        StartCoroutine(UIPosTweenForward(characterSelectedTween, characterSelectedTween.transform.gameObject));
    }
}
