using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecoginzed : MonoBehaviour
{
    [SerializeField] private TutorialManager tutorialManager;
    [SerializeField] private GameObject player;
    void OnTriggerEnter(Collider other)
    {
        SceneTransfer sceneTransfer = other.GetComponent<SceneTransfer>() ?? other.GetComponentInParent<SceneTransfer>();

        if (sceneTransfer == null)
            return;

        player.transform.localPosition = new Vector3(0, 0, 0);
        tutorialManager.EndStep1();
    }
}
