using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreHeartManager : MonoBehaviour
{
    [SerializeField] private GameObject WarningPanel;
    [SerializeField] private GameObject CPR;
    [SerializeField] private GameObject CPRGuide;
    [SerializeField] private GameObject portal;
    //길안내
    [SerializeField] private GameObject heart1_line_1;

    public GameObject nextBtn;
    private GestureRecongizedLeft gestureRecongizedLeft;
    private GestureRecongizedRight gestureRecongizedRight;
    //dialog 관련 변수
    private bool preheartdia;
    [SerializeField] private GameObject preheartobj;
    //emblem관련 gameObject
    [SerializeField] private GameObject heartEmblem;
    //effect 관련 스크립트
    [SerializeField] private EffectAudioManager effectAudioManager;
    //bg관련 스크립트
    [SerializeField] private AudioManager audioManager;
    void Start()
    {
        WarningPanel.SetActive(false);
        portal.SetActive(false);
        CPR.SetActive(false);
        CPRGuide.SetActive(false);
        gestureRecongizedLeft = GameObject.FindGameObjectWithTag("GR").GetComponent<GestureRecongizedLeft>();
        gestureRecongizedRight = GameObject.FindGameObjectWithTag("GR").GetComponent<GestureRecongizedRight>();
        preheartobj.SetActive(false);
        preheartdia = false;
        nextBtn.SetActive(false);
        //길안내
        heart1_line_1.SetActive(false);
        StartStage0();
    }
    
    IEnumerator Loading()
    {
        yield return new WaitForSeconds(3.5f);
        WarningPanel.SetActive(true);
        WarningPanel.GetComponent<WarningPanel>().WarningEndTurnOff();
        effectAudioManager.WarningEffect();
    }
    public void StartStage0()
    {
        gestureRecongizedLeft.CPRStartTurnOn();
        gestureRecongizedRight.CPRStartTurnOn();
        StartCoroutine(Loading());
    }

    public void EndStage0()
    {
        WarningPanel.SetActive(false);
        StartStage1();
    }

    public void StartStage1()
    {
        CPR.SetActive(true);
        CPRGuide.SetActive(true);
        
    }

    public void EndStage1()
    {
        
        Destroy(CPR);
        Destroy(CPRGuide);
        gestureRecongizedLeft.CPRStartTurnOff();
        gestureRecongizedRight.CPRStartTurnOff();
        preheartobj.SetActive(true);
        preheartdia = true;
        //nextBtn
        nextBtn.SetActive(true);
        //PreHeartEnd();
    }

    

    IEnumerator TotalLoading()
    {
        yield return new WaitForSeconds(2.0f);
        preheartobj.SetActive(false);
        heartEmblem.SetActive(true);
        effectAudioManager.GetEmblemEffect();
        audioManager.SoundTurnOff();
        yield return new WaitForSeconds(4.0f);
        heartEmblem.SetActive(false);
        audioManager.SoundTurnOn();
        //길안내
        heart1_line_1.SetActive(true);
        portal.SetActive(true);
    }

    public void PreHeartEnd()
    {
        nextBtn.SetActive(false);
        StartCoroutine(TotalLoading());
    }

    public bool GetPreHeartdia()
    {
        return preheartdia;
    }
}
