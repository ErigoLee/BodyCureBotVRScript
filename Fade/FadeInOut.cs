using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{

    [SerializeField] private Image panel;
    [SerializeField] private FadeInOutTrigger fadeInOutTrigger;
    [SerializeField] private FadeInOutTriggerLoadingBar FadeInOutTriggerLoadingBar;
    private Color color;
    private bool fadeIn;
    private bool fadeOut;
    void Start()
    {
        color = panel.color;
        color.a = 0.0f;
        panel.color = color;
        fadeIn = false;
        fadeOut = false;
    }

    public void FadeInTurnOn()
    {
        fadeIn = true;
    }

    IEnumerator Interval()
    {
        yield return new WaitForSeconds(2.0f);
        fadeOut = true;
    }

    public void TriggerTurnOn()
    {
        fadeInOutTrigger.CanTriggerTurnOn();
        FadeInOutTriggerLoadingBar.NotActiveTurnOff();
    }

    void Update()
    {
        if (fadeIn)
        {
            color.a += (Time.deltaTime / 2);
            panel.color = color;
            if (color.a > 0.9f)
            {
                fadeIn = false;
                color.a = 1.0f;
                panel.color = color;
                StartCoroutine(Interval());
            }
        }   

        if(fadeOut)
        {
            color.a -= (Time.deltaTime / 5);
            panel.color = color;
            if(color.a < 0.1f)
            {
                fadeOut = false;
                color.a = 0.0f;
                panel.color = color;
                TriggerTurnOn();
            }
        }
    }
}
