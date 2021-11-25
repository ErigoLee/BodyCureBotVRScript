using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDetector : MonoBehaviour
{

    private int myButtonID;//초기값
    [SerializeField]
    private ButtonManager buttonManager;

    public void SetMyButtonID(int buttonID)
    {
        myButtonID = buttonID;
    }

    public void Pressed()
    {
        buttonManager.SetClickButtonID(myButtonID);
    }

    public void Released()
    {
        buttonManager.ClickRecongizedTurnOn();
    }

}
