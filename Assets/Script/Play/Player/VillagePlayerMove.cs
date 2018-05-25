using UnityEngine;
using System.Collections;

public class VillagePlayerMove : MonoBehaviour
{

    public float speed = 15;
    private Rigidbody rig;
    void Start()
    {
        rig = transform.GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 vel = rig.velocity;
        if (Mathf.Abs(h) > 0.05f || Mathf.Abs(v) > 0.05f)
        {
            rig.velocity = new Vector3(-h * speed, vel.y, -v * speed);
            Quaternion rota = transform.rotation;
            Quaternion final = Quaternion.LookRotation(new Vector3(-h, 0, -v));
            transform.rotation = Quaternion.LerpUnclamped(rota, final, 0.5f);
        }
        else
        {
            rig.velocity = Vector3.zero;
        }

    }
}
