using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectType
{
    None,
    ShaderEffect,
    NCCurveEffect
}

public class PlayerEffect : MonoBehaviour
{
    [SerializeField]
    private EffectType effectType;
    [HideInInspector]
    public Renderer[] rendererArray;
    [HideInInspector]
    public NcCurveAnimation[] curveAnimationArray;

    // Use this for initialization
    void Start()
    {
        rendererArray = GetComponentsInChildren<Renderer>();
        if (effectType == EffectType.NCCurveEffect)
            curveAnimationArray = GetComponentsInChildren<NcCurveAnimation>();
    }

    private void Update()
    {
        //Test>>>>>
        if (Input.GetMouseButtonDown(0))
        {
          Show();
        }
    }

    public void Show()
    {
        foreach (Renderer render in rendererArray)
        {
            render.enabled = true;

        }

        if (effectType == EffectType.NCCurveEffect)
            foreach (NcCurveAnimation anim in curveAnimationArray)
            {
                anim.ResetAnimation();
            }
    }
}
