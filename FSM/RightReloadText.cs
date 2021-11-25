using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RightReloadText : MonoBehaviour
{
    private Color color;
    [SerializeField] private SpriteRenderer spriteColor;
    private bool reloadStart;
    [SerializeField] private EffectAudioManager effectAudioManager;
    void Start()
    {
        reloadStart = false;
        color = spriteColor.color;
        color.a = 0.0f;
        spriteColor.color = color;
    }

    IEnumerator Reloading()
    {
        effectAudioManager.ReloadEffect();
        yield return new WaitForSeconds(0.5f);
        color.a = 0.0f;
        spriteColor.color = color;
        yield return new WaitForSeconds(0.5f);
        color.a = 1.0f;
        spriteColor.color = color;
        StartCoroutine(Reloading());
    }

    public void ReloadTextStart()
    {
        if (!reloadStart)
        {
            color.a = 1.0f;
            spriteColor.color = color;
            StartCoroutine(Reloading());
            reloadStart = true;
        }
        
    }

    public void ReloadTextEnd()
    {
        if(reloadStart)
        {
            StopAllCoroutines();
            color.a = 0.0f;
            spriteColor.color = color;
            reloadStart = false;
        }
        
    }
}
