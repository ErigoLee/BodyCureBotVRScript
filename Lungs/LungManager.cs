using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungManager : MonoBehaviour
{
    //step0
    [SerializeField] private GameObject canTransLungs;
    [SerializeField] private GameObject leftLung;
    //step1
    [SerializeField] private GameObject vGestureDetector; 
    [SerializeField] private GameObject bronGuideEffect;
    [SerializeField] private GameObject VGestureGuide;
    //step2
    [SerializeField] private GameObject bronchial;
    [SerializeField] private GameObject bronDetector;
    //step3_1
    [SerializeField] private GameObject newBronchial;
    [SerializeField] private GameObject defenceManager;
    [SerializeField] private GameObject explainCanvas;
    //step3_2
    [SerializeField] private GameObject generator;
    [SerializeField] private GameObject leftGun;
    [SerializeField] private GameObject rightGun;
    [SerializeField] private GameObject attackedCanvas;
    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private GestureAction gestureAction;
    //step4
    [SerializeField] private GameObject newBronDetector;
    [SerializeField] private GameObject newBronGuideEffect;
    [SerializeField] private GameObject plantedBronGuideEffect;
    [SerializeField] private GameObject plantedGuide;
    //step5
    [SerializeField] private GameObject plantedBronchial;
    [SerializeField] private GameObject recoverLungTrigger;
    [SerializeField] private TransferLungMaterial transferLungMaterial;
    //portal
    [SerializeField] private GameObject portal;


    //길안내
    [SerializeField] private GameObject lung_line_1;
    [SerializeField] private GameObject lung_line_2;
    [SerializeField] private GameObject lung_line_3;
    [SerializeField] private GameObject lung_line_4;
    [SerializeField] private GameObject lung_line_5;

    //player
    [SerializeField] private GameObject player;
    private int step = 0;

    //emblem관련 gameObject
    [SerializeField] private GameObject lungEmblem;

    //effect 관련 스크립트
    [SerializeField] private EffectAudioManager effectAudioManager;
    //bg 관련 스크립트
    [SerializeField] private AudioManager audioManager;

    //hand
    private GrabLeft leftHand;
    private GrabRight rightHand;
    private OVRGrabbable newBronGrabbable;



    void Start()
    {
        //portal
        portal.SetActive(false);
        //step1
        bronGuideEffect.SetActive(false);
        VGestureGuide.SetActive(false);
        //step2
        bronDetector.SetActive(false);
        //stepe3_1
        newBronchial.SetActive(false);
        defenceManager.SetActive(false);
        explainCanvas.SetActive(false);
        //step3_2
        leftGun.SetActive(false);
        rightGun.SetActive(false);
        gameCanvas.SetActive(false);
        attackedCanvas.SetActive(false);
        //step4
        newBronDetector.SetActive(false);
        newBronGuideEffect.SetActive(false);
        plantedBronGuideEffect.SetActive(false);
        plantedGuide.SetActive(false);
        //step5
        plantedBronchial.SetActive(false);
        recoverLungTrigger.SetActive(false);

        //hand
        leftHand = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<GrabLeft>();
        rightHand = GameObject.FindGameObjectWithTag("RightHand").GetComponent<GrabRight>();
        newBronGrabbable = newBronchial.GetComponent<OVRGrabbable>();

        //길안내
        lung_line_1.SetActive(true);
        lung_line_2.SetActive(false);
        lung_line_3.SetActive(false);
        lung_line_4.SetActive(false);
        lung_line_5.SetActive(false);

    }

    public void EndStep0()
    {
        Destroy(canTransLungs);
        leftLung.SetActive(false);
        //길안내
        lung_line_1.SetActive(false);
        StartStep1();
    }


    public void StartStep1()
    {
        step = 1;
        vGestureDetector.GetComponent<VGestureDetector>().TransSuccessTurnOn();
        bronGuideEffect.SetActive(true);
        VGestureGuide.SetActive(true);
        
    }
    
    public void EndStep1()
    {
        VGestureGuide.SetActive(false);
        vGestureDetector.SetActive(false);
        bronGuideEffect.SetActive(false);
        Destroy(vGestureDetector);
        //길안내
        lung_line_2.SetActive(true);
        StartStep2();
    }

    public void StartStep2()
    {
        step = 2;
        bronDetector.SetActive(true);
        bronchial.GetComponent<Bronchial>().Grabable();
    }


    public void EndStep2()
    {
        Destroy(bronDetector);
        //길안내 종료
        lung_line_2.SetActive(false);
        StartStep3_1();
    }

    public void StartStep3_1()
    {
        step = 3;
        newBronchial.SetActive(true);
        //GR->움직임X
        gestureAction.TutoNotGoingTurnOn();

        //설명하는 text시작
        defenceManager.SetActive(true);
        defenceManager.GetComponent<DefenceManger>().DenfenceReadyStage();
        explainCanvas.SetActive(true);
    }

    public void StartStep3_2()
    {
        Destroy(explainCanvas);
        gestureAction.DefenceTurnOn();
        generator.SetActive(true);
        generator.GetComponent<Generator>().GeneratorStopTurnOff();
        leftGun.SetActive(true);
        rightGun.SetActive(true);
        gameCanvas.SetActive(true);
        attackedCanvas.SetActive(true);
    }

    IEnumerator clearExplaining()
    {
        yield return new WaitForSeconds(3.5f);
        Destroy(gameCanvas);
        Destroy(attackedCanvas);
        defenceManager.GetComponent<DefenceManger>().DefenceEndStage();
        StartStep4();
    }
    public void EndStep3()
    {
        //GR->움직임
        gestureAction.TutoNotGoingTurnOff();
        gestureAction.DefenceTurnOff();
        Destroy(leftGun);
        Destroy(rightGun);
        Destroy(generator);
        StartCoroutine("clearExplaining");
    }

    public void StartStep4()
    {
        step = 4;
        newBronchial.GetComponent<NewBronchial>().StartTransplant();
        newBronDetector.SetActive(true);
        newBronGuideEffect.SetActive(true); //newBronGuideEffect 활성화
        plantedGuide.SetActive(true);
        //길안내
        lung_line_3.SetActive(true);
    }

    public void EndStep4()
    {
        plantedGuide.SetActive(false);
        plantedBronGuideEffect.SetActive(false); //plantedBronGuideEffect
        Destroy(newBronDetector);
        //길안내
        lung_line_4.SetActive(false);
        StartStep5();
    }
    IEnumerator Step5Loading()
    {
        yield return new WaitForSeconds(1.0f);
        //player위치 재조정
        player.transform.localPosition = new Vector3(-3.4f, 0.0f, 9.3f);

    }
    public void StartStep5()
    {
        step = 5;
        StartCoroutine(Step5Loading());
        plantedBronchial.SetActive(true);
        recoverLungTrigger.SetActive(true);
        transferLungMaterial.TransMaterial();
        
    }

    public void EndStep5()
    {
        Destroy(recoverLungTrigger);
        leftLung.SetActive(true);
        LungEnd();
    }

    

    IEnumerator LungEndLoading()
    {
        yield return new WaitForSeconds(1.0f);
        //player 위치 재조정
        player.transform.localPosition = new Vector3(0,0,4);
        lungEmblem.SetActive(true);
        effectAudioManager.GetEmblemEffect();
        audioManager.SoundTurnOff();
        yield return new WaitForSeconds(4.0f);
        //길안내
        lung_line_5.SetActive(true);
        lungEmblem.SetActive(false);
        audioManager.SoundTurnOn();
        portal.SetActive(true);
    }

    public void LungEnd()
    {
        StartCoroutine(LungEndLoading());
    }

    void Update()
    {
        if(step == 4) //집는 순간 effect를 없애기 만듬
        {
            //leftHand 집을 때
            if(leftHand.isGrabbing)
            {
                OVRGrabbable grabbable = leftHand.grabbedObject;
                if(newBronGrabbable != null)
                {
                    if(newBronGrabbable == grabbable && newBronGuideEffect.activeSelf == true)
                    {
                        newBronGuideEffect.SetActive(false);
                        plantedBronGuideEffect.SetActive(true);
                        //길안내
                        lung_line_3.SetActive(false);
                        lung_line_4.SetActive(true);
                    }
                }
            }
            if (rightHand.isGrabbing)
            {
                OVRGrabbable grabbable = rightHand.grabbedObject;
                if (newBronGrabbable != null)
                {
                    if (newBronGrabbable == grabbable && newBronGuideEffect.activeSelf == true)
                    {
                        newBronGuideEffect.SetActive(false);
                        plantedBronGuideEffect.SetActive(true);
                        //길안내
                        lung_line_3.SetActive(false);
                        lung_line_4.SetActive(true);
                    }
                }
            }
        }
    }
}
