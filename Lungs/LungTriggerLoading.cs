using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LungTriggerLoading : MonoBehaviour
{
    private Image lungTriggerState;
    public float CurrentLoading;
    private float MaxLoading;
    CanTransLungs lungTrigger;
    private bool inRight;
    private bool inLeft;

    private bool NotActive;

    // Start is called before the first frame update
    void Start()
    {
        lungTriggerState = gameObject.GetComponent<Image>();
        lungTriggerState.fillAmount = 1.0f;
        lungTrigger = transform.parent.gameObject.transform.parent.gameObject.GetComponent<CanTransLungs>();
        MaxLoading = 3.0f;
        NotActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (NotActive)
            return;
        inRight = lungTrigger.GetInRight();
        inLeft = lungTrigger.GetInLeft();

        if(!inRight && !inLeft)
        {
            lungTriggerState.fillAmount = 1.0f;
            return;
        }
        CurrentLoading = lungTrigger.GetElaspedTime();

        lungTriggerState.fillAmount = (MaxLoading-CurrentLoading) / MaxLoading;

        if(lungTriggerState.fillAmount<=0.0f)
        {
            NotActive = true;
        }

    }
}
