using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecoverLungTriggerLodingBar : MonoBehaviour
{
    private Image lungTriggerState;
    public float CurrentLoading;
    private float MaxLoading;
    [SerializeField]
    private RecoverLungs newLungTrigger;
    private bool inRight;
    private bool inLeft;

    private bool NotActive;
    void Start()
    {
        lungTriggerState = gameObject.GetComponent<Image>();
        lungTriggerState.fillAmount = 1.0f;
        MaxLoading = 3.0f;
        NotActive = false;
    }

   
    void Update()
    {
        if (NotActive)
            return;
        inLeft = newLungTrigger.GetInLeft();
        inRight = newLungTrigger.GetInRight();

        if(!inRight&&!inLeft)
        {
            lungTriggerState.fillAmount = 1.0f;
            return;
        }

        CurrentLoading = newLungTrigger.GetElaspedTime();

        lungTriggerState.fillAmount = (MaxLoading - CurrentLoading) / MaxLoading;

        if(lungTriggerState.fillAmount<=0.0f)
        {
            NotActive = true;
        }
    }
}
