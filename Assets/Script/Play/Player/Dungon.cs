using UnityEngine;
using System.Collections;

public class Dungon : MonoBehaviour
{
    private static Dungon _instance;
    public static Dungon GetInstance
    {
        get { return _instance; }
    }
    [HideInInspector]
    public GameObject player;

    void Awake()
    {
        _instance = this;
        player = GameObject.FindWithTag("Player");
    }

    void Start()
    {
        
    }
}
