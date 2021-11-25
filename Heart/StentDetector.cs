using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StentDetector : MonoBehaviour
{
    [SerializeField] private HeartManager heartManager;

    void OnTriggerEnter(Collider other)
    {
        Stent stent = other.GetComponent<Stent>() ?? other.GetComponentInParent<Stent>();

        if (stent == null)
            return;
        
        OVRGrabber grabber = stent.gameObject.GetComponent<OVRGrabbable>().grabbedBy;
        GameObject leftHand = GameObject.FindWithTag("LeftHand");
        GameObject rightHand = GameObject.FindWithTag("RightHand");

        if (grabber.gameObject == leftHand)
        {
            stent.SetDestroy("LeftHand");
        }
        if (grabber.gameObject == rightHand)
        {
            stent.SetDestroy("RightHand");
        }

        heartManager.EndStage1();
    }
}
