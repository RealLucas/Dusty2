using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TaskManage : MonoBehaviour
{
    public TextAsset taskText;
    public List<Task> taskInfoList = new List<Task>();
    private static TaskManage _instance;
    public static TaskManage GetInstance
    {
        get { return _instance; }
    }
    private Task currentTask;
    private PlayerAutoMove playerAutoMoving;
    private PlayerAutoMove PlayerAutonMoving
    {
        get
        {
            if (playerAutoMoving == null)
            {
                playerAutoMoving = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAutoMove>();
            }
            return playerAutoMoving;
        }
    }


    private void Awake()
    {
        _instance = this;
        ReadTaskInfo();
    }
    

    //读取任务信息
    void ReadTaskInfo()
    {
        string[] strArray = taskText.text.Split('\n');
        foreach (string item in strArray)
        {
            Task task = new Task();
            string[] str = item.Split('|');
            task.Id = int.Parse(str[0]);
            switch (str[1])
            {
                case "Main":
                    task.TaskType = TaskType.Main;
                    break;
                case "Reward":
                    task.TaskType = TaskType.Reward;
                    break;
                case "Daily":
                    task.TaskType = TaskType.Daily;
                    break;
            }
            task.Name = str[2];
            task.IconName = str[3];
            task.Des = str[4];
            task.Coin = int.Parse(str[5]);
            task.Diamon = int.Parse(str[6]);
            task.NPCTalk = str[7];
            task.NPCID = int.Parse(str[8]);
            task.DumgnID = int.Parse(str[9]);
            taskInfoList.Add(task);
        }
    }
    public void ExcutalTask(Task task)
    {
        currentTask = task;
       
        if (currentTask.Progess == TaskProgress.NoStart)
        {
            //自动寻路到NPC
            PlayerAutonMoving.SetAutoMove(NPCManager.GetInstance.npcDir[currentTask.NPCID].transform);
        }
        else if (currentTask.Progess == TaskProgress.Accept)
        {
            //自动寻路到副本
            PlayerAutonMoving.SetAutoMove(NPCManager.GetInstance.dungon.transform);
        }
    }

    //点击接受任务后的改变
    public void OnAcceptTask()
    {

        currentTask.Progess = TaskProgress.Accept;

        PlayerAutonMoving.SetAutoMove(NPCManager.GetInstance.dungon.transform);//寻路到副本入口
    }

    public void OnArrived()
    {
        if (currentTask.Progess == TaskProgress.NoStart)
        {
            //到达任务NPC处
            NPCDialog.GetInstance.ShowTween(currentTask.NPCTalk);
        }
        //到达副本入口
    }
}
