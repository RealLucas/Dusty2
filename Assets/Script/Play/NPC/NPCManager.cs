using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCManager : MonoBehaviour
{

    private static NPCManager _instance;
    public static NPCManager GetInstance
    {
        get { return _instance; }
    }

    public GameObject[] NPC;
    [HideInInspector]
    public Transform dungon;
    [HideInInspector]
    public Dictionary<int, GameObject> npcDir = new Dictionary<int, GameObject>();

    private void Awake()
    {
        if (_instance == null || _instance != this)
            _instance = this;
    }

    void Start()
    {
        Inist();//初始化NPC存储字典
        dungon = transform.Find("Dungon").transform;
    }


    // Update is called once per frame
    void Update()
    {

    }

    void Inist()
    {
        if (NPC == null) return;
        foreach (GameObject item in NPC)
        {
            int id = int.Parse(item.name.Substring(0, 4));
            npcDir.Add(id, item);
        }
    }

    public bool GetNPCByID(int id)
    {
        GameObject npc;
        return npcDir.TryGetValue(id, out npc);
    }

    private void OnDestroy()
    {
        _instance = null;
    }
}
