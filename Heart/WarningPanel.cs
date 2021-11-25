using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WarningPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private SpriteRenderer iconWarning;
    [SerializeField] private SpriteRenderer popupWarning;
    [SerializeField] private PreHeartManager preHeartManager;
    private float fadeTimer = 0.0f;
    private float fadeEndTime = 0.5f;
    private Color textColor;
    private Color iconColor;
    private Color popupColor;
    private float elaspedTimer = 0.0f;
    private float endTime = 5.0f;
    private bool fadeIn = false;
    private bool warningEnd = true;
    void Start()
    {
        textColor = text.color;
        iconColor = iconWarning.color;
        popupColor = popupWarning.color;
        fadeIn = true;
    }

    public void WarningEndTurnOff()
    {
        warningEnd = false;
    }

    
    void Update()
    {
        if (!warningEnd)
        {
            elaspedTimer += Time.deltaTime;
            if (elaspedTimer >= endTime)
            {
                warningEnd = true;
                preHeartManager.EndStage0();
                return;
            }

            if(fadeIn)
            {
                fadeTimer += Time.deltaTime;
                //text
                textColor = text.color;
                textColor.a -= Time.deltaTime;
                text.color = textColor;
                //icon
                iconColor = iconWarning.color;
                iconColor.a -= Time.deltaTime;
                iconWarning.color = iconColor;
                //popup
                popupColor = popupWarning.color;
                popupColor.a -= Time.deltaTime;
                popupWarning.color = popupColor;
                if (fadeTimer >= fadeEndTime)
                {
                    fadeTimer = 0.0f;
                    fadeIn = false;
                }
            }
            else
            {
                fadeTimer += Time.deltaTime;
                //text
                textColor = text.color;
                textColor.a += Time.deltaTime;
                text.color = textColor;
                //icon
                iconColor = iconWarning.color;
                iconColor.a += Time.deltaTime;
                iconWarning.color = iconColor;
                //popup
                popupColor = popupWarning.color;
                popupColor.a += Time.deltaTime;
                popupWarning.color = popupColor;
                if (fadeTimer >= fadeEndTime)
                {
                    fadeTimer = 0.0f;
                    fadeIn = true;
                }
            }
        }
    }
}
