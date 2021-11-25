using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoStartButton : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        SceneTransfer sceneTransfer = other.GetComponent<SceneTransfer>() ?? other.GetComponentInParent<SceneTransfer>();
        if (sceneTransfer == null)
            return;
        print("button Inter");
        sceneTransfer.FadeInTurnOn(-2);
    }
}
