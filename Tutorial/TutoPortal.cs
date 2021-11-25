using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoPortal : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        SceneTransfer sceneTransfer = other.GetComponent<SceneTransfer>() ?? other.GetComponentInParent<SceneTransfer>();

        if (sceneTransfer == null)
            return;
        sceneTransfer.FadeInTurnOn(-1);
        gameObject.SetActive(false);

    }
}
