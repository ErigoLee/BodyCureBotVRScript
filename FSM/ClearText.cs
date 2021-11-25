using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ClearText : MonoBehaviour
{
    private TMP_Text text;
    private Color color;
    
    void Start()
    {
        text = GetComponent<TMP_Text>();
        color = text.color;
        color.a = 0.0f;
        text.color = color;
    }

    
    public void SetClear()
    {
        color.a = 1.0f;
        text.color = color;
    }
}
