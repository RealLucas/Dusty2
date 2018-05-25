using UnityEngine;
using System.Collections;

public class PlayerAutoMove : MonoBehaviour
{

    public float minDistance = 3;
    private UnityEngine.AI.NavMeshAgent agent;
    private VillagePlayerAnimation anim;

    void Start()
    {
        agent = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (anim == null)
            anim = transform.GetComponent<VillagePlayerAnimation>();

        Skill skill = new Skill();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
            //寻路模式
            anim.isAgent = true;

            if (agent.remainingDistance <= minDistance && agent.remainingDistance != 0)
            {
                SetStop();
                //到达目的地(两种目的地)
                TaskManage.GetInstance.OnArrived();
            }
        }

        //检测是否按下移动控制键,是-停用自动寻路
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (Mathf.Abs(h) > 0.05f || Mathf.Abs(v) > 0.05f)
        {
            SetStop();
        }

    }


    public void SetAutoMove(Transform targetPos)
    {
        agent.enabled = true;
        agent.SetDestination(targetPos.position);

    }

    public void SetStop()
    {
        if (agent.enabled)
        {
            agent.Stop();
            agent.enabled = false;
            anim.isAgent = false;
        }
    }


}
