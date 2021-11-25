using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChanceText : MonoBehaviour
{
    private TMP_Text text;
    private Color color;

    [SerializeField]
    private Generator generator;

    void Start()
    {
        text = GetComponent<TMP_Text>();
        color = text.color;
        color.a = 0.0f;
        text.color = color;
    }

    public void AlertWindow(int stage)
    {
        text.text = "한 번 더!";
        color.a = 1.0f;
        text.color = color;
    }
    

    public void AlertWindowEnd()
    {
        color.a = 0.0f;
        text.color = color;
    }
}
