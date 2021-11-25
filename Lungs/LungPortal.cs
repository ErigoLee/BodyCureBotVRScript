using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungPortal : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        SceneTransfer sceneTransfer = other.GetComponent<SceneTransfer>() ?? other.GetComponentInParent<SceneTransfer>();

        if (sceneTransfer == null)
            return;
        print("inter!");
        sceneTransfer.FadeInTurnOn(1);
        gameObject.SetActive(false);
    }

}
