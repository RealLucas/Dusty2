using UnityEngine;
using System.Collections;

public class AttackButton : MonoBehaviour
{

    public PosType posType;
    private PlayerAnimation playerAnimation;
    private float coldTimer;
    public float coldTime = 4;
    private UIButton button;
    private BoxCollider colider;
    private UISprite mask;
    private bool isClick;
    private Animator anim;

    void Start()
    {
        playerAnimation = Dungon.GetInstance.player.GetComponent<PlayerAnimation>();
        button = transform.GetComponent<UIButton>();
        colider = transform.GetComponent<BoxCollider>();
        anim = Dungon.GetInstance.player.GetComponent<Animator>();
        if (this.transform.Find("Mask"))
        {
            mask = transform.Find("Mask").GetComponent<UISprite>();
            mask.fillAmount = 0;
        }
    }


    void Update()
    {
        if (coldTimer > 0 && mask != null)
        {
            coldTimer -= Time.deltaTime;
            mask.fillAmount = coldTimer / coldTime;
            if (coldTimer <= 0)
            {
                Enable();
                mask.fillAmount = 0;
            }
        }

    }

    void OnPress(bool isPress)
    {
        if (!anim.GetCurrentAnimatorStateInfo(1).IsTag("Skill")) //在释放当前技能时禁止释放其他技能或者攻击(不触发按键)
        {
            if (isPress && mask != null)
            {
                coldTimer = coldTime;
                Disable();
                isClick = true;
            }
            playerAnimation.OnAttackClick(isPress, posType);
        }
    }

    void Disable()
    {
        colider.enabled = false;
        button.SetState(UIButtonColor.State.Normal, true);
    }
    void Enable()
    {
        colider.enabled = true;
        button.SetState(UIButtonColor.State.Normal, true);
    }
}
