using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VGestureDetector : MonoBehaviour
{
    private bool transSuccess;
    private bool inLeft;
    private bool inRight;

    [SerializeField]
    private LungManager lungManager;

    private GestureRecongizedLeft gestureRecongizedLeft;
    private GestureRecongizedRight gestureRecongizedRight;
    [SerializeField] private EffectAudioManager effectAudioManager;

    void Start()
    {
        transSuccess = false;
        GameObject GR = GameObject.FindGameObjectWithTag("GR");
        gestureRecongizedLeft = GR.GetComponent<GestureRecongizedLeft>();
        gestureRecongizedRight = GR.GetComponent<GestureRecongizedRight>();

        inLeft = false;
        inRight = false;

    }

    public void TransSuccessTurnOn()
    {
        transSuccess = true;
    }

    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.tag == "LeftHand")
        {
            print("leftHand Detect!");
            inLeft = true;
        }

        if (otherCollider.gameObject.tag == "RightHand")
        {
            print("rightHand Detect!");
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


    void Update()
    {
        if (!transSuccess)
            return;

        if (inLeft)
        { 
            if (gestureRecongizedLeft.GetGestureLeftName().Equals("Left_V"))
            {
                effectAudioManager.CutBronchialEffect();
                lungManager.EndStep1();
            }
        }

        if (inRight)
        {
            if (gestureRecongizedRight.GetGestureRightName().Equals("Right_V"))
            {
                effectAudioManager.CutBronchialEffect();
                lungManager.EndStep1();
            }
        }



    }
}
