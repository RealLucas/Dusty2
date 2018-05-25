using UnityEngine;
using System.Collections;

public class NPCDialog : MonoBehaviour
{
    private static NPCDialog _instance;
    public static NPCDialog GetInstance
    {
        get { return _instance; }
    }
    private UILabel _talkNPC;
    private UILabel TalkNpc
    {
        get
        {
            if (_talkNPC == null)
            {
                _talkNPC = transform.Find("Label").GetComponent<UILabel>();
            }
            return _talkNPC;
        }
    }
    private UIButton acceptButton;
    private TweenPosition tween;
    private void Awake()
    {
        if (_instance != this || _instance == null)
        {
            _instance = this;
        }
        acceptButton = transform.Find("AcceptButton").GetComponent<UIButton>();
        tween = transform.GetComponent<TweenPosition>();
    }

    void Start()
    {
        EventDelegate ed = new EventDelegate(this, "OnAcceptButton");
        acceptButton.onClick.Add(ed);
    }

    public void ShowTween(string talkNpc)
    {
        TalkNpc.text = talkNpc;
        tween.PlayForward();
    }

    //接受按键
    private void OnAcceptButton()
    {
        tween.PlayReverse();
        //然后寻路到副本入口
        TaskManage.GetInstance.OnAcceptTask();//回调

    }

    private void OnDestroy()
    {
        if (_instance != null) _instance = null;
    }
}
