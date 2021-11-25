using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBronchial : MonoBehaviour
{
    private GrabLeft leftHand;
    private GrabRight rightHand;
    private GestureRecongizedLeft gestureRecongizedLeft;
    private GestureRecongizedRight gestureRecongizedRight;
    private GameObject detector;
    private OVRGrabbable bronGrabbable;
    private bool updateActive;

    void Start()
    {
        leftHand = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<GrabLeft>();
        rightHand = GameObject.FindGameObjectWithTag("RightHand").GetComponent<GrabRight>();
        gestureRecongizedLeft = GameObject.FindGameObjectWithTag("GR").GetComponent<GestureRecongizedLeft>();
        gestureRecongizedRight = GameObject.FindGameObjectWithTag("GR").GetComponent<GestureRecongizedRight>();
        bronGrabbable = GetComponent<OVRGrabbable>() ?? GetComponentInParent<OVRGrabbable>();
        detector = transform.GetChild(0).gameObject;
        detector.SetActive(false);
        updateActive = false;
    }

    public void StartTransplant()
    {
        updateActive = true;
        detector.SetActive(true);
    }

    public void Attaching()
    {
        updateActive = false;
        OVRGrabber grabber = bronGrabbable.grabbedBy;
        if (grabber.gameObject == leftHand.gameObject)
        {
            gestureRecongizedLeft.CanGrabbingTurnOff();
            leftHand.InsideObjectTurnOff();
            leftHand.RemoveCandidates(bronGrabbable);
            detector.SetActive(false);
            gestureRecongizedLeft.CanGrabbingTurnOn();
        }
        if (grabber.gameObject == rightHand.gameObject)
        {
            gestureRecongizedRight.CanGrabbingTurnOff();
            rightHand.InsideObjectTurnOff();
            rightHand.RemoveCandidates(bronGrabbable);
            detector.SetActive(false);
            gestureRecongizedRight.CanGrabbingTurnOn();
        }
        leftHand.insideObject = false;
        rightHand.insideObject = false;
        Destroy(gameObject);
    }

    void Update()
    {
        if (!updateActive)
            return;
        if (detector.activeSelf == true)
        {
            OVRGrabbable grabbable = GetComponent<OVRGrabbable>() ?? GetComponentInParent<OVRGrabbable>();

            GrabDetector grabDetector = detector.GetComponent<GrabDetector>();
            if (leftHand.insideObject && grabDetector.GetInLeft())
            {
                if (gestureRecongizedLeft.GetCanGrabbing() && (gestureRecongizedLeft.GetGestureLeftName().Equals("Left_rock_v1") || gestureRecongizedLeft.GetGestureLeftName().Equals("Left_rock_v2")))
                {
                    leftHand.AddCandidates(grabbable);
                }
            }


            if (rightHand.insideObject && grabDetector.GetInRight())
            {
                if (gestureRecongizedRight.GetCanGrabbing() && (gestureRecongizedRight.GetGestureRightName().Equals("Right_rock_v1") || gestureRecongizedRight.GetGestureRightName().Equals("Right_rock_v2")))
                {
                    rightHand.AddCandidates(grabbable);
                }
            }
        }
    }

}
