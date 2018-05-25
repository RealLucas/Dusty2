using UnityEngine;
using System.Collections;

public class ServerPropety : MonoBehaviour
{
    public string ip
    {
        get;
        set;
    }
    private string _serverName;
    public string ServerName
    {
        get
        {
            return _serverName;
        }
        set
        {
            _serverName = transform.Find("Label").GetComponent<UILabel>().text = value;
        }
    }
    public int playerNumber
    {
        get;
        set;
    }

    public void OnPress(bool isOnPress)
    {
        if (isOnPress)
        {
            transform.root.transform.Find("BG").SendMessage("OnServerButtonClick",this.gameObject);
        }
    }
}
