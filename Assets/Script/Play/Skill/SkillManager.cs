using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillManager : MonoBehaviour
{

    public TextAsset skillText;
    public List<Skill> skillList = new List<Skill>();
    private static SkillManager _instance;
    public static SkillManager GetInstance
    {
        get
        {
            return _instance;

        }
    }

    private void Awake()
    {
        _instance = this;
        IninstSkill();//初始化技能列表
        foreach (Skill item in skillList)
        {
            print(item.ColdTime);
        }
      
    }
   
    void Start()
    {

    }
    void IninstSkill()
    {
        string[] strArray = skillText.text.Split('\n');
        foreach (string item in strArray)
        {
            //1001,浮生万刃,icon_zhu,Warrior,Basic,Basic,0,30
            Skill skill = new Skill();
            string[] array = item.Split(',');
            skill.ID = int.Parse(array[0]);
            skill.Name = array[1];
            skill.IconName = array[2];
            switch (array[3])
            {
                case "Warrior":
                    skill.PlayerClass = PlayerType.Worrir;
                    break;
                case "FemaleAssassin":
                    skill.PlayerClass = PlayerType.Assenta;
                    break;
            }
            switch (array[4])
            {
                case "Basic":
                    skill.SkillClass = SkillType.Basic;
                    break;
                case "Skill":
                    skill.SkillClass = SkillType.Skill;
                    break;
            }
            switch (array[5])
            {
                case "Basic":
                    skill.PositionSkill = PosType.Basic;
                    break;
                case "One":
                    skill.PositionSkill = PosType.One;
                    break;
                case "Two":
                    skill.PositionSkill = PosType.Two;
                    break;
                case "Three":
                    skill.PositionSkill = PosType.Three;
                    break;
            }
            skill.ColdTime = int.Parse(array[6]);
            skill.Damage = int.Parse(array[7]);
            skillList.Add(skill);
        }
    }

    public Skill GetSkillByPos(PosType posType)
    {
        foreach (Skill item in skillList)
        {
            if (item.PositionSkill == posType && PlayerInfo.GetInstance.PlayerClass == item.PlayerClass)
            {
                return item;
            }
           
        }
        return null;
    }

}
