using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreState : MonoBehaviour
{
    [SerializeField] private List<Collider> buttonCollider;
    private GameObject leftHand;
    private GameObject rightHand;
    private float preLeftYPos;
    private float preRightYPos;
    private float yLeftPos;
    private float yRightPos;
    private float threshold = 0f;
    void Start()
    {
        leftHand = GameObject.FindGameObjectWithTag("LeftHand");
        rightHand = GameObject.FindGameObjectWithTag("RightHand");
        preLeftYPos = leftHand.transform.position.y;
        preRightYPos = rightHand.transform.position.y;
    }

    
    void Update()
    {
        yLeftPos = leftHand.transform.position.y;
        yRightPos = rightHand.transform.position.y;


        if(preLeftYPos - yLeftPos < threshold)
        {
            Collider[] leftCollider = leftHand.GetComponentsInChildren<Collider>();
            foreach(Collider lc in leftCollider)
            {
                foreach(Collider collider in buttonCollider)
                {
                    Physics.IgnoreCollision(lc,collider,true);
                }
            }
        }
        else
        {
            Collider[] leftCollider = leftHand.GetComponentsInChildren<Collider>();
            foreach (Collider lc in leftCollider)
            {
                foreach (Collider collider in buttonCollider)
                {
                    Physics.IgnoreCollision(lc, collider, false);
                }
            }
        }

        if(preRightYPos - yRightPos < threshold)
        {
            Collider[] leftCollider = rightHand.GetComponentsInChildren<Collider>();
            foreach (Collider lc in leftCollider)
            {
                foreach (Collider collider in buttonCollider)
                {
                    Physics.IgnoreCollision(lc, collider, true);
                }
            }
        }
        else
        {
            Collider[] leftCollider = rightHand.GetComponentsInChildren<Collider>();
            foreach (Collider lc in leftCollider)
            {
                foreach (Collider collider in buttonCollider)
                {
                    Physics.IgnoreCollision(lc, collider, false);
                }
            }
        }

        preLeftYPos = leftHand.transform.position.y;
        preRightYPos = rightHand.transform.position.y;
    }
}
