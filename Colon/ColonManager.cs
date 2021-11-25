using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColonManager : MonoBehaviour
{
    //guideObject
    private bool explainning = false;
    [SerializeField] private GameObject ColonGuide;
    [SerializeField] private ColonGuideText colonGuideText;
    //stage0
    [SerializeField] private GameObject preFloor;
    [SerializeField] private GameObject createRope;
    [SerializeField] private GameObject handle;
    [SerializeField] private GameObject npcFloor;
    [SerializeField] private GameObject npc;
    [SerializeField] private GameObject npcManager;
    //stage1
    [SerializeField] private GameObject floor;
    private GameObject[] tumorGrabDetectors;
    private List<GameObject> tumors;
    [SerializeField] List<GameObject> tumorGuideEffects;
    //preStage2
    private bool arrivedStage2;
    [SerializeField] private GameObject buttonStagePlace;
    //stage2
    [SerializeField] private GameObject buttonManager;
    [SerializeField] private GameObject buttonGuide;
    [SerializeField] private GameObject pedestal;
    //preStage3
    private bool arrivedStage3;
    [SerializeField] private GameObject targetPlace;
    //stage3
    [SerializeField] private GameObject box;
    [SerializeField] private GameObject fence;
    [SerializeField] private GameObject fence2;
    [SerializeField] private GameObject targetManager;
    [SerializeField] private GameObject player;
    //portal
    [SerializeField] private GameObject portal;
    //dialog
    private bool colon2dia1;
    private bool colon2dia2;
    private bool colon2dia3;
    private bool colon2dia4;
    private bool colon2dia5;
    //대화창 관련 오브젝트
    [SerializeField] private GameObject colonobj1;
    [SerializeField] private GameObject colonobj2;
    [SerializeField] private GameObject colonobj3;
    [SerializeField] private GameObject colonobj4;
    [SerializeField] private GameObject colonobj5;
    //next 대화창 관련 오브젝트
    public GameObject nextBtn1;
    public GameObject nextBtn2;
    public GameObject nextBtn3;
    public GameObject nextBtn4;
    public GameObject nextBtn5;
    //길안내
    [SerializeField] private GameObject colon2_line_1;
    [SerializeField] private GameObject colon2_line_2;
    [SerializeField] private GameObject colon2_line_3;
    [SerializeField] private GameObject colon2_line_4;
    [SerializeField] private GameObject colon2_line_5;
    [SerializeField] private GameObject colon2_line_6;
    //stage 변수
    private int stage = 0;
    //emblem관련 gameobject
    [SerializeField] private GameObject colonEmblem;
    //effect관련 스크립트
    [SerializeField] private EffectAudioManager effectAudioManager;
    //bg관련 스크립트
    [SerializeField] private AudioManager audioManager;
    
    void Start()
    {
        //portal 및 guide 관련 오브젝트
        portal.SetActive(false);
        ColonGuide.SetActive(true);
        
        //stage0
        createRope.SetActive(false);
        handle.SetActive(false);

        //stage1
        floor.SetActive(false);
        //tumors관련 오브젝트, stage1이전까지 grabDetector를 비활성화
        tumors = new List<GameObject>();
        GameObject[] tumors_array = GameObject.FindGameObjectsWithTag("Tumor");
        tumorGrabDetectors = new GameObject[tumors_array.Length];
        int i = 0;
        foreach (GameObject tumor in tumors_array)
        {
            tumors.Add(tumor);
            tumorGrabDetectors[i] = tumor.transform.GetChild(1).gameObject;
            tumorGrabDetectors[i].SetActive(false);
            i++;
        }

        foreach(GameObject tumorGuideEffect in tumorGuideEffects)
        {
            tumorGuideEffect.SetActive(false);
        }

        //preStage2&Stage2
        buttonStagePlace.SetActive(false);
        //default
        arrivedStage2 = false;
        
        //preStage3&Stage3
        targetPlace.SetActive(false);
        //default
        arrivedStage3 = false;
        
        //dialog관련 변수 및 오브젝트
        colon2dia1 = true;
        colon2dia2 = false;
        colon2dia3 = false;
        colon2dia4 = false;
        colon2dia5 = false;
        colonobj1.SetActive(true);
        colonobj2.SetActive(false);
        colonobj3.SetActive(false);
        colonobj4.SetActive(false);
        colonobj5.SetActive(false);

        //nextBtn 관련 오브젝트
        nextBtn1.SetActive(true);
        nextBtn2.SetActive(false);
        nextBtn3.SetActive(false);
        nextBtn4.SetActive(false);
        nextBtn5.SetActive(false);

        //길안내
        colon2_line_1.SetActive(false);
        colon2_line_2.SetActive(false);
        colon2_line_3.SetActive(false);
        colon2_line_4.SetActive(false);
        colon2_line_5.SetActive(false);
        colon2_line_6.SetActive(false);

    }

    IEnumerator ExplainningLoading()
    {
        yield return new WaitForSeconds(2.0f);
        explainning = false;
        colonGuideText.guideEnd();
    }
    public void ExplainningEnd()
    {
        StartCoroutine(ExplainningLoading());
    }

    IEnumerator StartStage0_1Loading()
    {
        yield return new WaitForSeconds(2.0f);
        colonobj1.SetActive(false);
        createRope.SetActive(true);
        handle.SetActive(true);
        //길안내
        colon2_line_1.SetActive(true);
    }

    public void StartStage0_1()
    {
        nextBtn1.SetActive(false);
        StartCoroutine(StartStage0_1Loading());
    }

    public void EndStage0_1()
    {
        Destroy(createRope);
        //길안내 종료
        colon2_line_1.SetActive(false);
        StartStage0_2();
    }
    
    public void StartStage0_2()
    {
        handle.GetComponent<Rope>().enabled = true;
        

    }

    public void EndStage0_2()
    {
        Destroy(npcManager);
        colon2dia2 = true;
        //길안내
        colon2_line_2.SetActive(true);
        colonobj2.SetActive(true);
        //nextBtn
        nextBtn2.SetActive(true);
        //StartStage1();
    }

    IEnumerator StartStage1Loading()
    {
        yield return new WaitForSeconds(2.0f);
        foreach (GameObject tumorGrabDetector in tumorGrabDetectors)
        {
            tumorGrabDetector.SetActive(true);
        }
        foreach (GameObject tumorGuideEffect in tumorGuideEffects)
        {
            tumorGuideEffect.SetActive(true);
        }
        colon2_line_2.SetActive(false);
        colon2_line_3.SetActive(true);
        colonobj2.SetActive(false);
    }


    public void StartStage1()
    {
        stage = 1;
        Destroy(preFloor);
        floor.SetActive(true);
        //dialog2대화가 종료가 되었으므로 nextBtn2을 비활성화
        nextBtn2.SetActive(false);
        //길안내
        colon2_line_2.SetActive(false);
        colon2_line_3.SetActive(true);
        StartCoroutine(StartStage1Loading());
    }


    public void EndStage1(GameObject tumor)
    {
        tumors.Remove(tumor);
        Destroy(tumor);
        if (tumors.Count != 0)
            return;
        colon2dia3 = true;
        colonobj3.SetActive(true);
        //nextBtn
        nextBtn3.SetActive(true);
        colon2_line_3.SetActive(false);
    }


    IEnumerator PreStartStage2Loading()
    {
        yield return new WaitForSeconds(2.0f);
        colonobj3.SetActive(false);
        explainning = true;
        stage = 2;
        colonGuideText.guideStage2();
        buttonStagePlace.SetActive(true);
        effectAudioManager.ColonNextStageGuideEffect();
        //길안내
        colon2_line_3.SetActive(false);
    }


    public void PreStartStage2()
    {
        //dialogue 대화 3 종료 -> nextBtn3 비활성화
        nextBtn3.SetActive(false);
        StartCoroutine(PreStartStage2Loading());   
    }


    public void StartStage2()
    {
        buttonStagePlace.SetActive(false);
        buttonManager.SetActive(true);
        buttonGuide.SetActive(true);
        pedestal.SetActive(true);
        player.GetComponent<RestrictedAreaSet>().Stage2TurnOn();
    }

    public void EndStage2_1()
    {
        Destroy(pedestal);
        Destroy(buttonManager);
    }

    public void EndStage2_2()
    {
        Destroy(buttonGuide);
        player.GetComponent<RestrictedAreaSet>().Stage2TurnOff();
        colon2dia4 = true;
        colonobj4.SetActive(true);
        //nextBtn
        nextBtn4.SetActive(true);
        colon2_line_4.SetActive(true);
    }

    IEnumerator PreStartStage3Loading()
    {
        yield return new WaitForSeconds(1.5f);
        colonobj4.SetActive(false);
        explainning = true;
        stage = 3;
        colonGuideText.guideStage3();
        targetPlace.SetActive(true);
        effectAudioManager.ColonNextStageGuideEffect();
        //길안내
        colon2_line_4.SetActive(false);
    }


    public void PreStartStage3()
    {
        //dialogue4 대화  종료 -> nextBtn4 비활성화
        nextBtn4.SetActive(false);
        StartCoroutine(PreStartStage3Loading());
    }

    public void StartStage3()
    {
        Destroy(targetPlace);
        box.SetActive(true);
        fence.SetActive(true);
        fence2.SetActive(true);
        targetManager.SetActive(true);
        player.GetComponent<RestrictedAreaSet>().Stage3TurnOn();
    }

    public void EndStage3()
    {
        Destroy(box,2.5f);
        Destroy(fence,2.5f);
        Destroy(fence2,2.5f);
        Destroy(targetManager,2.5f);
        player.GetComponent<RestrictedAreaSet>().Stage3TurnOff();
        StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(2.5f);
        colon2dia5 = true;
        colonobj5.SetActive(true);
        //길안내
        colon2_line_5.SetActive(true);
        //nextBtn
        nextBtn5.SetActive(true);

    }

    IEnumerator ColonLoading()
    {
        yield return new WaitForSeconds(2.0f);
        //길안내
        colon2_line_5.SetActive(false);
        colonobj5.SetActive(false);
        colonEmblem.SetActive(true);
        effectAudioManager.GetEmblemEffect();
        audioManager.SoundTurnOff();
        yield return new WaitForSeconds(4.0f);
        colonEmblem.SetActive(false);
        audioManager.SoundTurnOn();
        colon2_line_6.SetActive(true);
        portal.SetActive(true);
    }

    public void ColonEnd()
    {
        stage = 4;
        //dialogue5 대화  종료 -> nextBtn5 비활성화
        nextBtn5.SetActive(false);
        StartCoroutine(ColonLoading());
        
    }


    void Update()
    {
        if(!explainning && !arrivedStage2 && stage==2)
        {
            Vector3 position = player.transform.localPosition;
            if(position.z <= -3.8f)
            {
                arrivedStage2 = true;
                StartStage2();
            }
        }

        if(!explainning && !arrivedStage3 && stage==3)
        {
            Vector3 position = player.transform.localPosition;
            if(position.z <= -10.0f)
            {
                arrivedStage3 = true;
                StartStage3();
            }
        }
    }

    public bool GetColon2dia1()
    {
        return colon2dia1;
    }
    public bool GetColon2dia2()
    {
        return colon2dia2;
    }
    public bool GetColon2dia3()
    {
        return colon2dia3;
    }
    public bool GetColon2dia4()
    {
        return colon2dia4;
    }
    public bool GetColon2dia5()
    {
        return colon2dia5;
    }
}
