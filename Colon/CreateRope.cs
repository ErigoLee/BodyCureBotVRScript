using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRope : MonoBehaviour
{
    [SerializeField]
    private GameObject handle;

    [SerializeField]
    private GameObject npcFloor;

    private float elaspedTime;
    private float endTime;

    public bool inLeft;
    public bool inRight;

    private bool createRopes;
    [SerializeField] private ColonManager colonManager;
    [SerializeField] private EffectAudioManager effectAudioManager;
    
    void Start()
    {
        elaspedTime = 0.0f;
        endTime = 3.0f;
        inLeft = false;
        inRight = false;
        createRopes = false;
    }

    void Update()
    {
        if (createRopes)
            return;

        if (!inRight && !inLeft)
        {
            elaspedTime = 0.0f;
            return;
        }

        elaspedTime += Time.deltaTime;

        if (elaspedTime > endTime)
        {
            createRopes = true;
            colonManager.EndStage0_1();
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


    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.tag == "LeftHand")
        {
            inLeft = true;
            effectAudioManager.TriggerBarEffectTurnOn();
        }

        if (otherCollider.gameObject.tag == "RightHand")
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
