using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private Dictionary<string, PlayerEffect> effectDict = new Dictionary<string, PlayerEffect>();
    // Use this for initialization
    void Start()
    {
        PlayerEffect[] peArray = GetComponentsInChildren<PlayerEffect>();
        foreach (PlayerEffect pe in peArray)
        {
            effectDict.Add(pe.gameObject.name, pe);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //0  normal skill1 skill2 skill3
    //1  effect name
    //2 sound name
    //3 move forward
    //4 jump height
    public void Attack(string args)
    {
        string[] str = args.Split(',');
        string effectName = str[1];
        ShowPlayerEffect(effectName);
    }

    void ShowPlayerEffect(string effectName)
    {
        PlayerEffect playerEffect;
        if (effectDict.TryGetValue(effectName, out playerEffect))
        {
            playerEffect.Show();
        }
    }
}
