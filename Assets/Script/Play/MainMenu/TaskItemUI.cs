using UnityEngine;
using System.Collections;

public class TaskItemUI : MonoBehaviour
{
    private UISprite taskTypeSprite;
    private UISprite taskSprite;
    private UILabel taskName;
    private UILabel taskDes;
    private UILabel taskCoinRewards;
    private UILabel taskDiamonRewards;
    private UIButton acceptTaskButton;
    private UIButton getRewardsButton;
    [HideInInspector]public Task task;
    private static TaskItemUI _instance;
    private UILabel acceptLabel;

    void Awake()
    {
        taskTypeSprite = transform.Find("TaskTypeSprite").GetComponent<UISprite>();
        taskSprite = transform.Find("TaskBG/TaskSprite").GetComponent<UISprite>();
        taskName = transform.Find("TaskName").GetComponent<UILabel>();
        acceptLabel = transform.Find("AcceptButton/Label").GetComponent<UILabel>();
        taskDes = transform.Find("TaskDes").GetComponent<UILabel>();
        taskCoinRewards = transform.Find("TaskReward/CoinBG/Label").GetComponent<UILabel>();
        taskDiamonRewards = transform.Find("TaskReward/DiamonBG/Label").GetComponent<UILabel>();
        acceptTaskButton = transform.Find("AcceptButton").GetComponent<UIButton>();
        getRewardsButton = transform.Find("RewardButton").GetComponent<UIButton>();
        EventDelegate ed1 = new EventDelegate(this, "AcceptTaskButton");
        EventDelegate ed2 = new EventDelegate(this, "GetRewardButton");
        acceptTaskButton.onClick.Add(ed1);
        getRewardsButton.onClick.Add(ed2);
        taskCoinRewards.gameObject.SetActive(false);
        taskDiamonRewards.gameObject.SetActive(false);
    }



    public void SetByTask(Task task)
    {
        this.task = task;
        task.OnTaskUIChangedEvent += OnTaskUIChanged;
        UpdateShow();
    }

    void UpdateShow()
    {

        switch (task.TaskType)
        {
            case TaskType.Main:
                taskTypeSprite.spriteName = "pic_主线";
                break;
            case TaskType.Daily:
                taskTypeSprite.spriteName = "pic_日常";
                break;
            case TaskType.Reward:
                taskTypeSprite.spriteName = "pic_奖赏";
                break;
        }
        taskSprite.spriteName = task.IconName;
        taskDes.text = task.Des;
        if (task.Coin != 0)
        {
            taskCoinRewards.gameObject.SetActive(true);
            taskCoinRewards.text = "X" + task.Coin;
        }

        if (task.Coin != 0)
        {
            taskDiamonRewards.gameObject.SetActive(true);
            taskDiamonRewards.text = "X" + task.Diamon;
        }

        switch (task.Progess)
        {
            case TaskProgress.NoStart:
                getRewardsButton.gameObject.SetActive(false);
                break;
            case TaskProgress.Accept:
                acceptLabel.text = "战斗";
                break;
            case TaskProgress.Complete:
                getRewardsButton.gameObject.SetActive(false);
                break;
        }
    }
    void OnTaskUIChanged()
    {
        UpdateShow();
    }
    public void AcceptTaskButton()
    {
        //改变任务状态
        TaskManage.GetInstance.ExcutalTask(task);

        TaskUI.GetInstance.CloseButton();
    }
    public void GetRewardButton()
    {
        //改变任务状态
    }

    private void OnDestroy()
    {
        task.OnTaskUIChangedEvent -= OnTaskUIChanged;
    }
}
