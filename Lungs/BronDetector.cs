using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BronDetector : MonoBehaviour
{
    [SerializeField] private LungManager lungManager;

    void OnTriggerEnter(Collider otherCollider)
    {
        Bronchial bronchinal = otherCollider.GetComponent<Bronchial>() ?? otherCollider.GetComponentInParent<Bronchial>();

        if (bronchinal == null)
            return;
        OVRGrabber grabber = bronchinal.gameObject.GetComponent<OVRGrabbable>().grabbedBy;
        GameObject leftHand = GameObject.FindWithTag("LeftHand");
        GameObject rightHand = GameObject.FindWithTag("RightHand");
        
        if (grabber.gameObject == leftHand)
        {
            bronchinal.SetDestroy("LeftHand");
        }
        if (grabber.gameObject == rightHand)
        {
            bronchinal.SetDestroy("RightHand");
        }

        lungManager.EndStep2();
    }

}
