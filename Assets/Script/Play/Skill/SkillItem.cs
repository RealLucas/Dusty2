using UnityEngine;
using System.Collections;

public class SkillItem : MonoBehaviour
{
    public PosType postion;
    private Skill skill;
    private UIButton _button;
    private UIButton Button
    {
        get
        {
            if (_button == null)
            {
                _button = transform.GetComponent<UIButton>();
            }
            return _button;
        }
    }
    private UISprite _spriteName;
    private UISprite SpriteName
    {
        get
        {
            if (_spriteName == null)
            {
                _spriteName = transform.GetComponent<UISprite>();
            }
            return _spriteName;
        }
    }

    void Start()
    {
        UpgradSkillItem();
    }

    void UpgradSkillItem()
    {
        skill = SkillManager.GetInstance.GetSkillByPos(postion);
        SpriteName.spriteName = skill.IconName;
        Button.normalSprite = SpriteName.spriteName;
    }
   
    void OnClick()
    {
       
        transform.parent.parent.SendMessage("OnSkillClick", skill);
       
    }
}
