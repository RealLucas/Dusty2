using UnityEngine;
using System.Collections;


public enum TaskType
{
    Main,
    Reward,
    Daily
}

public enum TaskProgress
{
    NoStart,
    Accept,
    Complete,
    Reward
}

public class Task
{
    public delegate void OnTaskUIHandler();
    public event OnTaskUIHandler OnTaskUIChangedEvent;
    public int Id { get; set; }
    public TaskType TaskType { get; set; }
    public string Name { get; set; }
    public string IconName { get; set; }
    public string Des { get; set; }
    public int Coin { get; set; }
    public int Diamon { get; set; }
    public string NPCTalk { get; set; }
    public int NPCID { get; set; }
    public int DumgnID { get; set; }
    private TaskProgress _progess = TaskProgress.NoStart;
    public TaskProgress Progess
    {
        get
        {
            return _progess;
        }

        set
        {
            if (_progess != value)
            {
                _progess = value;
                OnTaskUIChangedEvent();
                
            }
        }
    }
}
