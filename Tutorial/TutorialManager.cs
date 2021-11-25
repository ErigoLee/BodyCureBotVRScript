using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject Step1;
    [SerializeField] private GameObject Image;
    [SerializeField] private GameObject Step2;
    [SerializeField] private GameObject Step3;
    [SerializeField] private GameObject Step4;
    [SerializeField] private GameObject portal;
    [SerializeField] private GameObject player;
    [SerializeField] private TutoGuide tutoGuide;
    private GestureAction gestureAction;
    private int step = 0;
    void Start()
    {
        Image.SetActive(false);
        Step1.SetActive(false);
        Step2.SetActive(false);
        Step3.SetActive(false);
        Step4.SetActive(false);
        portal.SetActive(false);
        gestureAction = GameObject.FindGameObjectWithTag("GR").GetComponent<GestureAction>();
        StartStep1();
    }

    public int GetStep()
    {
        return step;
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(3.0f);
        Image.SetActive(true);
        step = 1;
        Step1.SetActive(true);
        tutoGuide.Step1Guide();
    }

    //step1 - 이동관련 튜토리얼
    public void StartStep1()
    {
        StartCoroutine(Loading());   
    }

    public void EndStep1()
    {
        tutoGuide.Step1GuideEnd();
        Step1.SetActive(false);
        player.transform.localPosition = new Vector3(0, 0, 0);
        StartStep2();
    }

    //step2 - 다이얼로그 튜토리얼
    public void StartStep2()
    {
        //이동제한 걸기
        gestureAction.TutoNotGoingTurnOn();
        step = 2;
        Step2.SetActive(true);
        tutoGuide.Step2Guide();
    }

    public void EndStep2()
    {
        tutoGuide.Step2GuideEnd();
        Step2.SetActive(false);
        StartStep3();
    }
    
    //step3 - grab관련 튜토리얼
    public void StartStep3()
    {
        step = 3;
        Step3.SetActive(true);
        tutoGuide.Step3Guide();
    }

    public void EndStep3()
    {
        tutoGuide.Step3GuideEnd();
        Step3.SetActive(false);
        StartStep4();
    }
    //step4 - throw관련 튜토리얼
    public void StartStep4()
    {
        step = 4;
        Step4.SetActive(true);
        tutoGuide.Step4Guide();
    }

    public void EndStep4()
    {
        tutoGuide.Step4GuideEnd();
        Step4.SetActive(false);
        Image.SetActive(false);
        TutoEnd();
    }

    public void TutoEnd()
    {
        //이동제한 풀기
        gestureAction.TutoNotGoingTurnOff();
        portal.SetActive(true);
    }
}
