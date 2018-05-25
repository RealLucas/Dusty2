using UnityEngine;
using System.Collections;

public class MessageManager : MonoBehaviour
{

    private static MessageManager _instance;
    public static MessageManager GetInstance
    {
        get { return _instance; }
    }
    private UILabel message;
    private TweenAlpha tween;
    private bool isStart;

    private void Awake()
    {
        _instance = this;
        tween = transform.GetComponent<TweenAlpha>();
        message = transform.Find("MessageBG/Label").GetComponent<UILabel>();
        EventDelegate ed = new EventDelegate(this, "OnEndTween");
        tween.onFinished.Add(ed);
        this.gameObject.SetActive(false);
    }


    public void ShowMessageUI(string message, float time=1)
    {

        this.gameObject.SetActive(true);
        StartCoroutine(PlayTween(message, time));

    }
    IEnumerator PlayTween(string message, float time)
    {
        this.message.text = message;
        isStart = true;
        tween.PlayForward();
        yield return new WaitForSeconds(time);
        isStart = false;
        tween.PlayReverse();
    }

    void OnEndTween()
    {
        if (isStart == false)
        {
            this.gameObject.SetActive(false);
        }
    }
}
