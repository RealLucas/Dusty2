using UnityEngine;
using System.Collections;

public enum SkillType
{
    Basic,
    Skill
}

public enum PosType
{
    Basic,
    One,
    Two,
    Three
}

public class Skill
{


    public int ID
    {
        get;
        set;
    }
    public string Name
    {
        get;
        set;
    }
    public string IconName
    {
        get;
        set;
    }
    public PlayerType PlayerClass
    {
        get;
        set;
    }
    public SkillType SkillClass
    {
        get;
        set;
    }
    public PosType PositionSkill
    {
        get;
        set;
    }
    public int ColdTime
    {
        get;
        set;
    }
    public int Damage
    {
        get;
        set;
    }

    private int level = 1;
    public int Level
    {
        get { return level; }
        set { level = value; }
    }
}
