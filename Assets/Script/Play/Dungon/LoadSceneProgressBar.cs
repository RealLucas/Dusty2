using UnityEngine;
using System.Collections;

public class LoadSceneProgressBar : MonoBehaviour
{

    private UISprite bg;
    private UISlider progressSlider;
    private bool isAysnc;
    private AsyncOperation ao;

    void Awake()
    {
        bg = transform.Find("BG").GetComponent<UISprite>();
        progressSlider = transform.Find("BG/PrograssBarBackGround").GetComponent<UISlider>();
        bg.gameObject.SetActive(false);
        transform.gameObject.SetActive(false);
    }


    void Update()
    {

        if (isAysnc)
        {
            progressSlider.value = ao.progress;

        }
    }


    public void Show(AsyncOperation ao)
    {
        this.ao = ao;
        isAysnc = true;
        transform.gameObject.SetActive(true);
        bg.gameObject.SetActive(true);
    }
}
