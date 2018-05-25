using UnityEngine;
using System.Collections;

public enum AnimtionType
{
    Idle,
    Run
}
public class PlayerMove : MonoBehaviour
{

    public int moveSpeed = 15;
    private Rigidbody rig;
    private Animator anim;
    [HideInInspector]
    public AnimtionType animationType= AnimtionType.Idle;

    void Start()
    {
        rig = transform.GetComponent<Rigidbody>();
        anim = transform.GetComponent<Animator>();
    }


    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (Mathf.Abs(h) > 0.05f || Mathf.Abs(v) > 0.05f)
        {
            animationType = AnimtionType.Run;
            Quaternion rota = transform.rotation;
            Quaternion finl = Quaternion.LookRotation(new Vector3(h, 0, v));
            if (anim.GetCurrentAnimatorStateInfo(1).IsName("Empty State"))
            {
                transform.rotation = Quaternion.LerpUnclamped(rota, finl, 0.5f);
                anim.SetBool("Move", true);
                rig.velocity = new Vector3(h * moveSpeed, rig.velocity.y, v * moveSpeed);
            }
            else
            {
                animationType = AnimtionType.Idle;
                anim.SetBool("Move", false);
                rig.velocity = Vector3.zero;
            }
        }
        else
        {
            animationType = AnimtionType.Idle;
            anim.SetBool("Move", false);
            rig.velocity = Vector3.zero;
        }
    }
}
