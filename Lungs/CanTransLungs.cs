using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanTransLungs : MonoBehaviour
{
    [SerializeField] private LungManager lungManager;
    [SerializeField] private EffectAudioManager effectAudioManager;
    private float elaspedTime;
    private float endTime;

    private bool inLeft;
    private bool inRight;

    private bool transparentLungs;

    void Start()
    {
        elaspedTime = 0.0f;
        endTime = 3.0f;
        inLeft = false;
        inRight = false;
        transparentLungs = false;
    }

    void Update()
    {
        if (transparentLungs)
            return;

        if(!inRight && !inLeft)
        {
            elaspedTime = 0.0f;
            return;
        }

        elaspedTime += Time.deltaTime;

        if(elaspedTime > endTime)
        {
            transparentLungs = true;
            lungManager.EndStep0();
            effectAudioManager.TriggerBarEffectTurnOff();
        }
    }

    public bool GetInRight()
    {
        return inRight;
    }

    public bool GetInLeft()
    {
        return inLeft;
    }


    public float GetElaspedTime()
    {
        return elaspedTime;
    }

    public float GetEndTime()
    {
        return endTime;
    }


    void OnTriggerEnter(Collider otherCollider)
    {
        if(otherCollider.gameObject.tag == "LeftHand")
        {
            inLeft = true;
            effectAudioManager.TriggerBarEffectTurnOn();
        }

        if(otherCollider.gameObject.tag == "RightHand")
        {
            inRight = true;
            effectAudioManager.TriggerBarEffectTurnOn();
        }
    }

    void OnTriggerExit(Collider otherCollider)
    {
        if(otherCollider.gameObject.tag == "LeftHand")
        {
            inLeft = false;
            if(!inRight)
                effectAudioManager.TriggerBarEffectTurnOff();
        }
        if(otherCollider.gameObject.tag == "RightHand")
        {
            inRight = false;
            if(!inLeft)
                effectAudioManager.TriggerBarEffectTurnOff();
        }
    }
}
