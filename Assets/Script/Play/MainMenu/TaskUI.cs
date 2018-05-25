using UnityEngine;
using System.Collections;

public class TaskUI : MonoBehaviour
{

    private UIGrid grid;
    private UIScrollView scrollView;
    public GameObject prefab;
    private GameObject inistGo;
    private UIButton closeButton;
    private bool isShow;
    private TweenPosition tween;
    private static TaskUI _instance;
    public static TaskUI GetInstance
    {
        get { return _instance; }
    }


    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        grid = transform.Find("Scroll View/Grid").GetComponent<UIGrid>();
        scrollView = transform.Find("Scroll View").GetComponent<UIScrollView>();
        closeButton = transform.Find("CloseButton").GetComponent<UIButton>();
        tween = transform.GetComponent<TweenPosition>();
        EventDelegate ed1 = new EventDelegate(this, "CloseButton");
        closeButton.onClick.Add(ed1);
        EventDelegate ed2 = new EventDelegate(this, "Hide");
        tween.onFinished.Add(ed2);


        InistTask();
    }

    //实例化任务列表
    void InistTask()
    {
        for (int i = 0; i < TaskManage.GetInstance.taskInfoList.Count; i++)
        {
            inistGo = NGUITools.AddChild(grid.transform.gameObject, prefab);
            inistGo.GetComponent<UIDragScrollView>().scrollView = scrollView;
            inistGo.transform.SetParent(grid.transform);
            //更新任务信息
            inistGo.GetComponent<TaskItemUI>().SetByTask(TaskManage.GetInstance.taskInfoList[i]);
        }
        grid.enabled = true;
    }

    public void Show()
    {
        if (isShow == false)
        {
            isShow = true;
            this.gameObject.SetActive(true);
            tween.PlayForward();

        }
        else
        {
            tween.PlayReverse();
            isShow = false;
        }
    }


    public void CloseButton()
    {
        tween.PlayReverse();
        isShow = false;
    }

    public void Hide()
    {
        if (isShow == false)
        {
            this.gameObject.SetActive(false);
        }
    }

}
