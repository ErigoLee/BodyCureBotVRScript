using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverLungs : MonoBehaviour
{
    [SerializeField] private LungManager lungManager;
    [SerializeField] private EffectAudioManager effectAudioManager;
    private float elaspedTime;
    private float endTime;

    private bool inLeft;
    private bool inRight;

    private bool plantedLungs;

    void Start()
    {
        elaspedTime = 0.0f;
        endTime = 3.0f;
        inLeft = false;
        inRight = false;
        plantedLungs = false;
    }

    
    void Update()
    {
        if (plantedLungs)
            return;

        if(!inRight && !inLeft)
        {
            elaspedTime = 0.0f;
            return;
        }

        elaspedTime += Time.deltaTime;

        if(elaspedTime>endTime)
        {

            plantedLungs = true;
            lungManager.EndStep5();
            effectAudioManager.TriggerBarEffectTurnOff();
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
        if (otherCollider.gameObject.tag == "LeftHand")
        {
            inLeft = false;
            if (!inRight)
                effectAudioManager.TriggerBarEffectTurnOff();
        }

        if (otherCollider.gameObject.tag == "RightHand")
        {
            inRight = false;
            if (!inLeft)
                effectAudioManager.TriggerBarEffectTurnOff();
        }
    }
}
