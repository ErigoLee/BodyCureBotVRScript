using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonGuideGUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;
    private Color color;
    [SerializeField]
    private ColonManager colonManager;
    void Start()
    {
        color = text.color;
        color.a = 0.0f;
        text.color = color;
    }

    public void ButtonGuidStart()
    {
        text.text = "Biopsy Start!!";
        color.a = 1.0f;
        text.color = color;
    }

    public void ButtonGuidEnd()
    {
        color.a = 0.0f;
        text.color = color;
    }

    public void ButtonRunAlert(int stage)
    {
        text.text = (stage + 1) + " stage start";
        color.a = 1.0f;
        text.color = color;
    }

    public void ButtonSuccessAlert(int order)
    {
        text.text = (order + 1) + " button correct";
        color.a = 1.0f;
        text.color = color;
    }

    public void ButtonFailAlert(int order)
    {
        text.text = (order + 1) + " button answer";
        color.a = 1.0f;
        text.color = color;
    }

    public void TryAgainShow()
    {
        text.text = "Try again";
        color.a = 1.0f;
        text.color = color;
    }

    public void ButtonGuidFinish()
    {
        StartCoroutine("FinishShow");
    }

    IEnumerator FinishShow()
    {
        text.text = "Finish!!";
        color.a = 1.0f;
        text.color = color;
        yield return new WaitForSeconds(2f);
        colonManager.EndStage2_2();
    }
}
