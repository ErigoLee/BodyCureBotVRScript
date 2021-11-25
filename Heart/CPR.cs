using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPR : MonoBehaviour
{
    private GestureRecongizedLeft gestureRecongizedLeft;
    private GestureRecongizedRight gestureRecongizedRight;
    private bool cprStart;
    private int stage;
    private int endStage;
    private string[,] leftCPRGestureNames;
    private bool leftCorrect;
    private string[,] rightCPRGestureNames;
    private bool rightCorrect;
    private bool checking;
    private bool waiting;
    private int faultCount;
    private bool tryagain;
    [SerializeField]
    private CPRGuide cprGuide;
    [SerializeField]
    private CPRAnim cprAnim;
    //effect관련 스크립트
    [SerializeField] private EffectAudioManager effectAudioManager;
    void Start()
    {
        gestureRecongizedLeft = GameObject.FindGameObjectWithTag("GR").GetComponent<GestureRecongizedLeft>();
        gestureRecongizedRight = GameObject.FindGameObjectWithTag("GR").GetComponent<GestureRecongizedRight>();
        cprStart = false;
        stage = 0;
        endStage = 5;
        leftCPRGestureNames = new string[5, 2];
        rightCPRGestureNames = new string[5, 2];
        SaveCPRGestureNames(); //제스처 
        leftCorrect = false;
        rightCorrect = false;
        checking = false;
        faultCount = 0;
        tryagain = false;
        CPRStartTurnOn();
        waiting = false;
    }

    public void CPRStartTurnOn()
    {
        StartCoroutine(CPRStart());
    }

    void SaveCPRGestureNames()
    {
        for(int i = 0; i < 5; i++)
        {
            switch (i)
            {
                case 0:
                    leftCPRGestureNames[0, 0] = "Left_rock_v1";
                    leftCPRGestureNames[0, 1] = "Left_rock_v2";
                    rightCPRGestureNames[0, 0] = "Right_paper";
                    rightCPRGestureNames[0, 1] = "Right_paper";
                    break;
                case 1:
                    leftCPRGestureNames[1, 0] = "Left_ring";
                    leftCPRGestureNames[1, 1] = "Left_ring";
                    rightCPRGestureNames[1, 0] = "Right_V";
                    rightCPRGestureNames[1, 1] = "Right_V";
                    break;
                case 2:
                    leftCPRGestureNames[2, 0] = "Left_thumb";
                    leftCPRGestureNames[2, 1] = "Left_thumb";
                    rightCPRGestureNames[2, 0] = "Right_rock_v1";
                    rightCPRGestureNames[2, 1] = "Right_rock_v2";
                    break;
                case 3:
                    leftCPRGestureNames[3, 0] = "Left_paper";
                    leftCPRGestureNames[3, 1] = "Left_paper";
                    rightCPRGestureNames[3, 0] = "Right_ring";
                    rightCPRGestureNames[3, 1] = "Right_ring";
                    break;
                case 4:
                    leftCPRGestureNames[4, 0] = "Left_V";
                    leftCPRGestureNames[4, 1] = "Left_V";
                    rightCPRGestureNames[4, 0] = "Right_thumb";
                    rightCPRGestureNames[4, 1] = "Right_thumb";
                    break;
                    
            }
        }
    }

    IEnumerator CPRStart()
    {
        yield return new WaitForSeconds(1);
        cprGuide.CPRGuidStart();
        yield return new WaitForSeconds(3);
        cprGuide.CPREnd();
        cprStart = true;
        StartCoroutine(CPRRun());
    }
    
    IEnumerator CPRRun()
    {
        checking = false;
        waiting = true;
        cprGuide.WaitTimerRun();
        yield return new WaitForSeconds(3);
        waiting = false;
        cprGuide.CPRRunStart(stage); 
        yield return new WaitForSeconds(5);
        cprGuide.CPRRunEnd(stage);
        checking = true;
    }
    //fail
    IEnumerator CPRFail()
    {
        tryagain = true;
        stage = 0;
        faultCount = 0;
        checking = false;
        cprGuide.CPRTryAgainStart();
        yield return new WaitForSeconds(10);
        tryagain = false;
        cprGuide.CPREnd();
        StartCoroutine(CPRRun());
    }
    //start
    IEnumerator CPRAnimStartAndEffect()
    {
        cprAnim.Bumping();
        effectAudioManager.TemporaryHeartBeatEffect();
        yield return new WaitForSeconds(0.2f);
        cprAnim.Idle();
    }


    void Update()
    {
        
        if (cprStart)
        {
            //tryagain waiting Timing
            if (tryagain)
                return;

            //checking 구간
            if (checking)
            {
                stage++;
                if(!leftCorrect || !rightCorrect) //left,right fault once 조건
                {
                    faultCount++;
                }
                else
                {
                    //leftCorrect, rightCorrect 맞는 경우 -> cpr 애니메이션하기
                    if(stage < endStage)
                        StartCoroutine(CPRAnimStartAndEffect());
                }

                //left,right correct 초기화
                leftCorrect = false;
                rightCorrect = false;
                
                //faultCount 일정 수 넘으면 코르틴 호출
                if (faultCount >= 3)
                {
                    StartCoroutine(CPRFail());
                    return;
                }

                //stage가 끝나면 cpr 종료
                if(stage >= endStage)
                {
                    cprStart = false;
                    cprGuide.CPREnding();
                    cprAnim.Bumping();
                    effectAudioManager.HeartBeatEffectTurnOn();

                }
                else
                {   //stage가 남으면 run하기
                    StartCoroutine(CPRRun());
                }
                
            }
            else //gesture 하는 구간
            {

                if (waiting) //기다리는 구간
                    return;

                if (!leftCorrect)
                {
                    //왼쪽 제스처 맞는 경우
                    string leftGestureName = gestureRecongizedLeft.GetGestureLeftName();
                    if (leftGestureName.Equals(leftCPRGestureNames[stage, 0])||leftGestureName.Equals(leftCPRGestureNames[stage,1]))
                    {
                        leftCorrect = true;
                    }
                }

                if(!rightCorrect)
                {
                    //오른쪽 제스처 맞는 경우
                    string rightGestureName = gestureRecongizedRight.GetGestureRightName();
                    if(rightGestureName.Equals(rightCPRGestureNames[stage,0]) || rightGestureName.Equals(rightCPRGestureNames[stage,1]))
                    {
                        rightCorrect = true;
                    }
                }
                

                //leftCorrect과 rightCorrect 모두 true인 경우
                if(leftCorrect && rightCorrect)
                {
                    StopAllCoroutines();
                    //StopCoroutine("CPRRun"); //CPRRUN 코르틴 종료
                    cprGuide.CPRRunEnd(stage); 
                    checking = true;   
                }
            }
            
        }
        else
        {
            return;
        }
    }
}
