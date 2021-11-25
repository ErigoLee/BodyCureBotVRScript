using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CPRGuide : MonoBehaviour
{
    [SerializeField] private PreHeartManager preHeartManager;
    [SerializeField] private TMP_Text text;
    public GameObject[] leftHandObjects;
    public GameObject[] rightHandObjects;
    public GameObject[] numberPanels;
    private Color color;

    
    void Start()
    {
        color = text.color;
        color.a = 0.0f;
        text.color = color;
    }

    IEnumerator WaitingText()
    {
        text.text = "Ready!";
        color.a = 1.0f;
        text.color = color;
        yield return new WaitForSeconds(2.0f);
        text.text = "Go!";
        yield return new WaitForSeconds(1.0f);
        color.a = 0.0f;
        text.color = color;
    }

    public void WaitTimerRun()
    {
        StartCoroutine(WaitingText());
    }
    
    public void CPRGuidStart()
    {
        text.text = "CPR Start!!";
        color.a = 1.0f;
        text.color = color;
                
    }

    IEnumerator CPRNumberCounting()
    {
        numberPanels[4].SetActive(true);
        yield return new WaitForSeconds(1);
        numberPanels[4].SetActive(false);
        numberPanels[3].SetActive(true);
        yield return new WaitForSeconds(1);
        numberPanels[3].SetActive(false);
        numberPanels[2].SetActive(true);
        yield return new WaitForSeconds(1);
        numberPanels[2].SetActive(false);
        numberPanels[1].SetActive(true);
        yield return new WaitForSeconds(1);
        numberPanels[1].SetActive(false);
        numberPanels[0].SetActive(true);
        yield return new WaitForSeconds(1);
        numberPanels[0].SetActive(false);
    }

    public void CPRRunStart(int stage)
    {
        StartCoroutine(CPRNumberCounting());
        leftHandObjects[stage].SetActive(true);
        rightHandObjects[stage].SetActive(true);
    }

    public void CPRRunEnd(int stage)
    {
        StopAllCoroutines();
        //StopCoroutine("CPRNumberCounting");
        foreach(GameObject numberPanel in numberPanels)
        {
            numberPanel.SetActive(false);
        }
        leftHandObjects[stage].SetActive(false);
        rightHandObjects[stage].SetActive(false);
    }
    
    public void CPRTryAgainStart()
    {
        text.text = "Try again!";
        color.a = 1.0f;
        text.color = color;
    }

    public void CPREnd()
    {
        color.a = 0.0f;
        text.color = color;
    }

    IEnumerator cprEndShow()
    {
        yield return new WaitForSeconds(2);
        preHeartManager.EndStage1();
    }

    public void CPREnding()
    {
        text.text = "Finish!!";
        color.a = 1.0f;
        text.color = color;
        StartCoroutine(cprEndShow());
    }
}
