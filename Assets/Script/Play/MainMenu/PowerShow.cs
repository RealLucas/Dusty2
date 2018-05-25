using UnityEngine;
using System.Collections;

public class PowerShow : MonoBehaviour
{
    private float startValue;
    private float endValue;
    private bool isStart;
    public float speed = 1000;//每秒增加的速度
    private bool isUp;  //是否增加
    private TweenAlpha tween;
    private UILabel powerLabel;

    void Awake()
    {
        tween = this.GetComponent<TweenAlpha>();
        powerLabel = transform.Find("Label").GetComponent<UILabel>();
        EventDelegate ed = new EventDelegate(this, "OnTweenEnd");
        tween.onFinished.Add(ed);
        this.gameObject.SetActive(false);
    }


    void Update()
    {
        if (isStart)
        {
            if (isUp)
            {
                //战斗力增加
                startValue += speed * Time.deltaTime;
                if (startValue >= endValue)
                {
                    StartCoroutine(WaitTime());
                }
            }
            else
            {
                //减少
                startValue -= speed * Time.deltaTime;
                if (startValue <= endValue)
                {

                    StartCoroutine(WaitTime());
                }
            }
            powerLabel.text = ((int)startValue).ToString();
        }
    }
    IEnumerator WaitTime()
    {
        startValue = endValue;
        isStart = false;
        yield return new WaitForSeconds(0.5f);
        tween.PlayReverse();
    }

    public void OnTweenEnd()
    {
        if (isStart == false)
            this.gameObject.SetActive(false);
    }

    public void PowerChanged(int startValue, int endValue)
    {
        this.gameObject.SetActive(true);
        tween.PlayForward();
        this.startValue = startValue;
        this.endValue = endValue;
        isStart = true;
        isUp = (startValue < endValue) ? true : false;
    }
}
