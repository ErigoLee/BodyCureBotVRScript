using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageText : MonoBehaviour
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

    public void StageTextStart(int stage)
    {
        text.text = "Stage" + stage;
        color.a = 1.0f;
        text.color = color;
    }

    public void StageTextEnd()
    { 
        color.a = 0.0f;
        text.color = color;
    }
}
