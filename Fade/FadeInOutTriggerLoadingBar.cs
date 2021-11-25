using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOutTriggerLoadingBar : MonoBehaviour
{
    [SerializeField] private FadeInOutTrigger fadeInOutTrigger;
    private Image triggerState;
    public float CurrentLoading;
    private float MaxLoading;
    private bool inRight;
    private bool inLeft;

    private bool NotActive;

    void Start()
    {
        triggerState = gameObject.GetComponent<Image>();
        triggerState.fillAmount = 1.0f;
        MaxLoading = 3.0f;
        NotActive = false;
    }

    public void NotActiveTurnOff()
    {
        NotActive = false;
        triggerState.fillAmount = 1.0f;
    }

    public void NotActiveTurnOn()
    {
        NotActive = true;
        triggerState.fillAmount = 0.0f;
    }


    void Update()
    {
        if (NotActive)
            return;
        inLeft = fadeInOutTrigger.GetInLeft();
        inRight = fadeInOutTrigger.GetInRight();

        if (!inRight && !inLeft)
        {
            triggerState.fillAmount = 1.0f;
            return;
        }

        CurrentLoading = fadeInOutTrigger.GetElaspedTime();

        triggerState.fillAmount = (MaxLoading - CurrentLoading) / MaxLoading;

        if (triggerState.fillAmount <= 0.0f)
        {
            NotActiveTurnOn();
        }
    }
}
