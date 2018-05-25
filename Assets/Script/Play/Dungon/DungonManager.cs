using UnityEngine;
using System.Collections;

public class DungonManager : MonoBehaviour
{

    private DungonButton dungonButton;
    private DungonDialog dialog;
    private UIButton backButton;
    private TweenPosition tween;

    void Start()
    {
        dialog = transform.Find("Dialog").GetComponent<DungonDialog>();
        tween = transform.GetComponent<TweenPosition>();
        backButton = transform.Find("BackButton").GetComponent<UIButton>();
        EventDelegate ed = new EventDelegate(this, "OnBack");
        backButton.onClick.Add(ed);
    }



    void OnDungonBTClick(DungonButton dungonButton)
    {
        this.dungonButton = dungonButton;
        //显示弹框
        dialog.Show(dungonButton);
    }

    void OnBack()
    {
        tween.PlayReverse();
    }
}
