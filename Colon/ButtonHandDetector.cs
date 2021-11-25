using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandDetector : MonoBehaviour
{
    [SerializeField]
    private PhysicsButton physicsButton;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "LeftHand")
        {
            physicsButton.InLeftTurnOn();
        }   
        if(other.gameObject.tag == "RightHand")
        {
            physicsButton.InRightTurnOn();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "LeftHand")
        {
            physicsButton.InLeftTurnOff();
        }
        if (other.gameObject.tag == "RightHand")
        {
            physicsButton.InRightTurnOff();
        }
    }

}
