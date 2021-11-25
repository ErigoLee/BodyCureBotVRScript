using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartButton : MonoBehaviour
{
    [SerializeField]
    private bool inLeft;
    private bool inRight;

    private float elaspedTime;
    private float endTime;

    private bool startGame;

    // Start is called before the first frame update
    void Start()
    {
        elaspedTime = 0.0f;
        endTime = 0.1f;
        inLeft = false;
        inRight = false;
        startGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
            return;

        if (!inRight && !inLeft)
        {
            elaspedTime = 0.0f;
            return;
        }

        elaspedTime += Time.deltaTime;

        if (elaspedTime > endTime)
        {
            startGame = true;
            //SceneManagement.Instance.LoadSceneNum(1);
        }
    }

    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.tag == "LeftHand")
        {
            inLeft = true;
        }

        if (otherCollider.gameObject.tag == "RightHand")
        {
            inRight = true;
        }
    }

    void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.gameObject.tag == "LeftHand")
        {
            inLeft = false;
        }
        if (otherCollider.gameObject.tag == "RightHand")
        {
            inRight = false;
        }
    }
}
