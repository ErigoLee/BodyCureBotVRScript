using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoManager : MonoBehaviour
{
    [SerializeField] private GameObject leftArm;
    [SerializeField] private GameObject wrench;
    [SerializeField] private GameObject portal;
    [SerializeField] private GameObject Deco_line_1;
    [SerializeField] private GameObject Deco_line_2;
    [SerializeField] private GameObject Deco_line_3;
    [SerializeField] private GameObject Deco_line_4;
    public GameObject nextBtn;
    //grabDector 오브젝트
    private GameObject leftArmGrabDetector;
    private GameObject wrenchGrabDetector;
    //dialog 관련 변수
    private bool decodia1;
    private bool decodia2;
    //deco 관련 dialog 오브젝트
    [SerializeField] private GameObject decoobj;
    //퀘스트 물건&지점 표시하기
    [SerializeField] private GameObject LeftArmGuideEffect;
    [SerializeField] private GameObject WrenchGuideEffect;
    //잡기 감지하기
    private int step = 0;
    private GrabLeft leftHand;
    private GrabRight rightHand;
    private OVRGrabbable wrenchGrabbable;
    private OVRGrabbable leftArmGrabbable;
    //player 위치 재조정
    [SerializeField] private GameObject player;
    

    void Start()
    {
        //잡기관련 변수
        leftHand = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<GrabLeft>();
        rightHand = GameObject.FindGameObjectWithTag("RightHand").GetComponent<GrabRight>();
        wrenchGrabbable = wrench.GetComponent<OVRGrabbable>();
        leftArmGrabbable = leftArm.GetComponent<OVRGrabbable>();

        //effect 관련 변수
        LeftArmGuideEffect.SetActive(false);
        WrenchGuideEffect.SetActive(false);

        //grab detector관련 변수
        leftArmGrabDetector = leftArm.transform.GetChild(1).gameObject;
        wrenchGrabDetector = wrench.transform.GetChild(0).gameObject;
        leftArmGrabDetector.SetActive(false);
        wrenchGrabDetector.SetActive(false);

        //portal
        portal.SetActive(false);

        //dialog
        decodia1 = true;
        decodia2 = false;
        decoobj.SetActive(true);

        //nextBtn 활성화
        nextBtn.SetActive(true);

        //안내선 비활성화
        Deco_line_1.SetActive(false);
        Deco_line_2.SetActive(false);
        Deco_line_3.SetActive(false);
        Deco_line_4.SetActive(false);
    }



    //dialogue부분
    public void EndStep0()
    {
        //nextBtn 비활성화 -> mission 수행 중
        nextBtn.SetActive(false);
        StartStep1();
    }

    //팔고치기 부분 - 팔 갖다대기
    public void StartStep1()
    {
        step = 1;
        LeftArmGuideEffect.SetActive(true);
        leftArmGrabDetector.SetActive(true);
        //안내선
        Deco_line_1.SetActive(true);

    }
    //wrench하는 부분
    public void StartStep1_1()
    {
        step = 2;
        WrenchGuideEffect.SetActive(true);
        wrenchGrabDetector.SetActive(true);
        //안내선
        Deco_line_2.SetActive(false);
        Deco_line_3.SetActive(true);

    }


    IEnumerator Loading()
    {
        yield return new WaitForSeconds(1.0f);
        player.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void EndStep1()
    {
        step = 3;
        decodia1 = false; //대화 1 종료
        decodia2 = true; //대화 2 실행
        //player 위치 재조정
        StartCoroutine(Loading());
        //nextBtn 활성화
        nextBtn.SetActive(true);
        //안내선
        Deco_line_2.SetActive(false);
        //DecoEnd();//마지막 단계에서 호출해줄 것!
    }

    public void DecoEnd()
    {
        nextBtn.SetActive(false);
        portal.SetActive(true);
        //안내선
        Deco_line_4.SetActive(true);
    }

    //effect Turn on 하는변수
    //wrench && leftarm
    public void EffectTurnOn()
    {
        if (step == 2 && wrench != null)
        {
            WrenchGuideEffect.SetActive(true);
        }
        if(step==1 && leftArm != null)
        {
            LeftArmGuideEffect.SetActive(true);
        }
    }
    

    public bool GetDecodia1()
    {
        return decodia1;
    }
    public bool GetDecodia2()
    {
        return decodia2;
    }

    void Update()
    {
        if (step == 1) //집는 순간 effect를 없애기 위해서 만든 코드
        {
            //leftHand 집을 때
            if (leftHand.isGrabbing)
            {
                OVRGrabbable grabbable = leftHand.grabbedObject;
                if (leftArmGrabbable != null)
                {
                    if (leftArmGrabbable == grabbable && LeftArmGuideEffect.activeSelf == true)
                    {
                        LeftArmGuideEffect.SetActive(false);
                        //안내선
                        Deco_line_1.SetActive(false);
                        Deco_line_2.SetActive(true);
                    }
                }
            }


            //rightHand 집을 때
            if (rightHand.isGrabbing)
            {
                OVRGrabbable grabbable = rightHand.grabbedObject;
                if (leftArmGrabbable != null)
                {
                    if (leftArmGrabbable == grabbable && LeftArmGuideEffect.activeSelf == true)
                    {
                        LeftArmGuideEffect.SetActive(false);
                        //안내선
                        Deco_line_1.SetActive(false);
                        Deco_line_2.SetActive(true);
                    }
                }
            }

        }
        if (step == 2)
        {
            //leftHand 집을 때
            if (leftHand.isGrabbing)
            {
                OVRGrabbable grabbable = leftHand.grabbedObject;
                if (wrenchGrabbable != null)
                {
                    if (wrenchGrabbable == grabbable && WrenchGuideEffect.activeSelf == true)
                    {
                        WrenchGuideEffect.SetActive(false);
                        //안내선
                        Deco_line_3.SetActive(false);
                        Deco_line_2.SetActive(true);
                    }
                }
                
            }


            //rightHand 집을 때
            if (rightHand.isGrabbing)
            {
                OVRGrabbable grabbable = rightHand.grabbedObject;
                if (wrenchGrabbable != null)
                {
                    if (wrenchGrabbable == grabbable && WrenchGuideEffect.activeSelf == true)
                    {
                        WrenchGuideEffect.SetActive(false);
                        //안내선
                        Deco_line_3.SetActive(false);
                        Deco_line_2.SetActive(true);
                    }
                }
                
            }
        }

    }
}
