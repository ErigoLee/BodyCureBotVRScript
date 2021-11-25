using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOutTrigger : MonoBehaviour
{
    [SerializeField] private FadeInOut fadeInOut;
    private float elaspedTime;
    private float endTime;

    private bool inLeft;
    private bool inRight;

    private bool canTrigger;

    void Start()
    {
        elaspedTime = 0.0f;
        endTime = 3.0f;
        inLeft = false;
        inRight = false;
        canTrigger = true;
    }

    public void CanTriggerTurnOn()
    {
        canTrigger = true;
    }

    public void CanTriggerTurnOff()
    {
        canTrigger = false;
    }


    void Update()
    {
        if (!canTrigger)
            return;

        if (!inRight && !inLeft)
        {
            elaspedTime = 0.0f;
            return;
        }

        elaspedTime += Time.deltaTime;

        if (elaspedTime > endTime)
        {
            canTrigger = false;
            elaspedTime = 0.0f;
            fadeInOut.FadeInTurnOn();
        }
    }

    public float GetElaspedTime()
    {
        return elaspedTime;
    }

    public float GetEndTime()
    {
        return endTime;
    }

    public bool GetInLeft()
    {
        return inLeft;
    }

    public bool GetInRight()
    {
        return inRight;
    }

    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.tag == "LeftHand")
        {
            inLeft = true;
        }

        if (otherCollider.gameObject.tag == "RightHand")
        {
            inRight = true;
        }
    }

    void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.gameObject.tag == "LeftHand")
        {
            inLeft = false;
        }

        if (otherCollider.gameObject.tag == "RightHand")
        {
            inRight = false;
        }
    }
}
