using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{

    public Vector3 offset;
    private Transform playerBip;
    private Transform player;
    private PlayerMove playerMove;
    void Start()
    {
        playerBip = Dungon.GetInstance.player.transform.Find("Bip01");
        player = Dungon.GetInstance.player.transform.Find("Player");
        if(playerMove==null)
        playerMove = Dungon.GetInstance.player.transform.GetComponent<PlayerMove>();
    }


    void Update()
    {
        if (playerMove.animationType == AnimtionType.Run)
        {
            transform.position = player.position + offset;
        }
        else
        {
            transform.position = player.position + offset;
        }
    }
}
