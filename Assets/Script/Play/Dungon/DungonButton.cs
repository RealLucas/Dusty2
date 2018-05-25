using UnityEngine;
using System.Collections;

public class DungonButton : MonoBehaviour
{

    public int id;
    public int needLevel;
    public string sceneName;

    void Start()
    {

    }

    public void OnClick()
    {
        transform.parent.SendMessage("OnDungonBTClick", this);
    }
}
