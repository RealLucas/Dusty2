using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private PosType posType;
    private void Start()
    {
        anim = transform.GetComponent<Animator>();
    }

    public void OnAttackClick(bool isPress, PosType posType)
    {
        this.posType = posType;
        if (posType == PosType.Basic)
        {
            if (isPress)
                anim.SetTrigger("AttackTrigger");
        }
        else
        {

            anim.SetBool("Skill" + (int)posType, true);
            Invoke("WaitTime", 0.5f);
        }
    }

    void WaitTime()
    {
        anim.SetBool("Skill" + (int)posType, false);
    }
}
