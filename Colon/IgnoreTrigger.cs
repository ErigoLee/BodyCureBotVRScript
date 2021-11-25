using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreTrigger : MonoBehaviour
{
    [SerializeField] private Collider ignoreButtonCollider;
    private GameObject leftHand;
    private GameObject rightHand;
    private bool leftProceeding;
    private bool rightProceeding;
    void Start()
    {
        leftHand = GameObject.FindGameObjectWithTag("LeftHand");
        rightHand = GameObject.FindGameObjectWithTag("RightHand");
        leftProceeding = false;
        rightProceeding = false;
    }

    IEnumerator leftInterival()
    {
        yield return new WaitForSeconds(0.5f);
        Collider[] leftCollider = leftHand.GetComponentsInChildren<Collider>();

        foreach (Collider lc in leftCollider)
        {
            Physics.IgnoreCollision(lc, ignoreButtonCollider, false);
        }
        leftProceeding = false;
    }

    IEnumerator rightInterival()
    {
        yield return new WaitForSeconds(0.5f);
        Collider[] rightCollider = rightHand.GetComponentsInChildren<Collider>();
        foreach (Collider rc in rightCollider)
        {
            Physics.IgnoreCollision(rc, ignoreButtonCollider, false);
        }
        rightProceeding = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "LeftHand")
        {
            print("leftHand");
            if (!leftProceeding)
            {
                leftProceeding = true;
                ignoreButtonCollider.enabled = false;
                Collider[] leftCollider = leftHand.GetComponentsInChildren<Collider>();

                foreach(Collider lc in leftCollider)
                {
                    Physics.IgnoreCollision(lc,ignoreButtonCollider,true);
                }
                
                StartCoroutine(leftInterival());
            }
        }
        if(other.gameObject.tag == "RightHand")
        {
            print("rightHand");
            if (!rightProceeding)
            {
                rightProceeding = true;
                ignoreButtonCollider.enabled = false;
                Collider[] rightCollider = rightHand.GetComponentsInChildren<Collider>();
                foreach(Collider rc in rightCollider)
                {
                    Physics.IgnoreCollision(rc,ignoreButtonCollider,true);
                }
                
                StartCoroutine(rightInterival());
            }
        }
    }
}
