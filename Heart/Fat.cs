using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fat : MonoBehaviour
{
    [SerializeField] private BVTransfer bVTransfer;


    void OnTriggerEnter(Collider other)
    {

        RestrictedAreaSet2 player = other.GetComponent<RestrictedAreaSet2>() ?? other.GetComponentInParent<RestrictedAreaSet2>();

        if (player == null)
            return;

        if(bVTransfer != null)
        {
            bVTransfer.PreGoBack();
        } 
    }


}
