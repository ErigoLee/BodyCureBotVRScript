using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialThrowChecking : MonoBehaviour
{
    [SerializeField] private TutorialThrowCheck tutorialThrowCheck;

    void OnTriggerEnter(Collider other)
    {
        ThrowGrabbable throwGrabbable = other.GetComponent<ThrowGrabbable>() ?? other.GetComponentInParent<ThrowGrabbable>();

        if (throwGrabbable == null)
            return;
        tutorialThrowCheck.ThrowingTurnOn();
    }
}
