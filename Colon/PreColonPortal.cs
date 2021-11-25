using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreColonPortal : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        SceneTransfer sceneTransfer = other.GetComponent<SceneTransfer>() ?? other.GetComponentInParent<SceneTransfer>();

        if (sceneTransfer == null)
            return;
        print("inter!");
        sceneTransfer.FadeInTurnOn(4);
        gameObject.SetActive(false);
    }
}
