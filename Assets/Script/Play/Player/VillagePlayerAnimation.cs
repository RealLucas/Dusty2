using UnityEngine;
using System.Collections;

public class VillagePlayerAnimation : MonoBehaviour
{

    private Animator anim;
    private Rigidbody rig;
    [HideInInspector]
    public bool isAgent;

    void Start()
    {
        anim = transform.GetComponent<Animator>();
        rig = transform.GetComponent<Rigidbody>();
    }


    void Update()
    {

        if (rig.velocity.magnitude > 0.5f || isAgent)
        {
            anim.SetBool("Move", true);
        }
        else
        {
            anim.SetBool("Move", false);
        }
    }
}
