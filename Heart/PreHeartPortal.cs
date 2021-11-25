using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreHeartPortal : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        SceneTransfer sceneTransfer = other.GetComponent<SceneTransfer>() ?? other.GetComponentInParent<SceneTransfer>();

        if (sceneTransfer == null)
            return;
        print("inter!");
        //temporary
        GestureRecongizedLeft gestureRecongizedLeft = GameObject.FindGameObjectWithTag("GR").GetComponent<GestureRecongizedLeft>();
        GestureRecongizedRight gestureRecongizedRight = GameObject.FindGameObjectWithTag("GR").GetComponent<GestureRecongizedRight>();
        gestureRecongizedLeft.CPRStartTurnOff();
        gestureRecongizedRight.CPRStartTurnOff();
        sceneTransfer.FadeInTurnOn(2);
        gameObject.SetActive(false);
    }
}
