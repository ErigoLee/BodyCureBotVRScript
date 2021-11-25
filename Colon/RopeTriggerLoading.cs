using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RopeTriggerLoading : MonoBehaviour
{
    private Image ropeTriggerState;
    public float CurrentLoading;
    private float MaxLoading;
    CreateRope ropeTrigger;
    private bool inRight;
    private bool inLeft;

    private bool NotActive;

    // Start is called before the first frame update
    void Start()
    {
        ropeTriggerState = gameObject.GetComponent<Image>();
        ropeTriggerState.fillAmount = 1.0f;
        ropeTrigger = transform.parent.gameObject.transform.parent.gameObject.GetComponent<CreateRope>();
        MaxLoading = 3.0f;
        NotActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (NotActive)
            return;
        inRight = ropeTrigger.inRight;
        inLeft = ropeTrigger.inLeft;

        if (!inRight && !inLeft)
        {
            ropeTriggerState.fillAmount = 1.0f;
            return;
        }
        CurrentLoading = ropeTrigger.GetElaspedTime();

        ropeTriggerState.fillAmount = (MaxLoading - CurrentLoading) / MaxLoading;

        if (ropeTriggerState.fillAmount <= 0.0f)
        {
            NotActive = true;
        }
    }
}
