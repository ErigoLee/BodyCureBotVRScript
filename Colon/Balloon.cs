using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    private BalloonGenerator balloonGenerator;
    private GrabLeft leftHand;
    private GrabRight rightHand;
    private GestureRecongizedLeft gestureRecongizedLeft;
    private GestureRecongizedRight gestureRecongizedRight;
    private bool once = false;
    void Start()
    {
        balloonGenerator = GameObject.FindGameObjectWithTag("BalloonGenerator").GetComponent<BalloonGenerator>();
        leftHand = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<GrabLeft>();
        rightHand = GameObject.FindGameObjectWithTag("RightHand").GetComponent<GrabRight>();
        gestureRecongizedLeft = GameObject.FindGameObjectWithTag("GR").GetComponent<GestureRecongizedLeft>();
        gestureRecongizedRight = GameObject.FindGameObjectWithTag("GR").GetComponent<GestureRecongizedRight>();
    }
    
    void Update()
    {
        Vector3 position = transform.position;
        if (balloonGenerator == null)
        {
            OVRGrabbable grabbable = GetComponent<OVRGrabbable>() ?? GetComponentInParent<OVRGrabbable>();
            GameObject detector = transform.GetChild(0).gameObject;
            detector.SetActive(false);
            gestureRecongizedLeft.CanGrabbingTurnOff();
            gestureRecongizedRight.CanGrabbingTurnOff();
            if (leftHand.isGrabbing)
            {
                leftHand.GrabFinish();
            }
            if (rightHand.isGrabbing)
            {
                rightHand.GrabFinish();
            }
            leftHand.InsideObjectTurnOff();
            rightHand.InsideObjectTurnOff();
            leftHand.RemoveCandidates(grabbable);
            rightHand.RemoveCandidates(grabbable);
            gestureRecongizedLeft.CanGrabbingTurnOn();
            gestureRecongizedRight.CanGrabbingTurnOn();
            Destroy(gameObject);
        }
            
        if (position.y < 10.4f || position.z > -11.0f || position.z < -17.0f || position.x > 1.5f || position.x < -1.5f)
        {
            if(balloonGenerator != null)
            {
                balloonGenerator.DeleteBalloon(gameObject,false);
            }
            
            Destroy(gameObject);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        
        Target target = other.GetComponent<Target>() ?? other.GetComponentInParent<Target>();

        if (target == null)
            return;
        if (!once)
        {
            target.Attacked();
            balloonGenerator.DeleteBalloon(gameObject, true);
            once = true;
        }
        
        Destroy(gameObject);
    }
}
