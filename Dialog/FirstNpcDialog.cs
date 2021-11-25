using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Dialogue
{
    [TextArea(5, 3)]
    public string dialogue;
}

public class FirstNpcDialog : MonoBehaviour
{
    //deco
    public DecoManager decoManager;
    //heart1
    public PreHeartManager preHeartManager;
    //colon1
    public PreColonManager preColonManager;
    //colon2
    public ColonManager colonManager;
    public TextMeshProUGUI txt_Dialogue;
    static public bool isDialogue = true;

    // 대화가 얼마나 진행 되었는지 확인
    private int count = 0;

    static private String[] dialogue; // 대화가 들어가는 배열

    public bool nextdialogok = false;

    private bool decodia1;
    private bool decodia2;
    private bool preheartdia;
    private bool colon1dia;
    private bool colon2dia1;
    private bool colon2dia2;
    private bool colon2dia3;
    private bool colon2dia4;
    private bool colon2dia5;

    //colon관련 변수 지정->start
    private bool once1 = false;
    private bool once2 = false;
    private bool once3 = false;

    //portal한번만 뜨게 해주기
    private bool decoPortalOnce = false;
    private bool preHeartPortalOnce = false;
    private bool preColonPortalOnce = false;
    private bool colonPortalOnce = false;


    private void Awake()
    {
        dialogue = new String[50];
        dialogue[0] = "[DS1057]\n\n거기 누구 없나요?";
        dialogue[1] = "[DS1057]\n\n반가워요. 저는 기지를 지키던 DS1057이에요.";
        dialogue[2] = "[DS1057]\n\n갑자기 다른 로봇들이\n들어오더니 기지를 부수고\n저를 망가뜨렸어요.";
        dialogue[3] = "[DS1057]\n\n혹시 당신도 나쁜 로봇은\n아니겠죠?";
        dialogue[4] = "[DS1057]\n\n지금 공격당해서\n팔이 망가졌어요.";
        dialogue[5] = "[DS1057]\n\n저기 있는 도구를 이용해서\n제 팔을 고쳐주세요.";
        dialogue[6] = "-퀘스트-\n\n DS1057의 팔을\n고쳐주세요.";
        dialogue[7] = "[DS1057]\n\n고마워요!";
        dialogue[8] = "[DS1057]\n\n아마 다른 장기들도\n점령당했을거에요.";
        dialogue[9] = "[DS1057]\n\n포탈을 통해 이동하여 \n상태가 급한 폐를\n고쳐주세요!";
        dialogue[10] = "-퀘스트-\n\n포탈을 통해 폐로\n이동하세요.";
        dialogue[11] = "[DS1094]\n\n아니 심장이 다시\n뛰고 있잖아?";
        dialogue[12] = "[DS1094]\n\n당신이 고친거야?";
        dialogue[13] = "[DS1094]\n\n고쳐줘서 고마워.";
        dialogue[14] = "[DS1094]\n\n다른 놈들을 막는 사이에\n심장이 멈췄나봐.";
        dialogue[15] = "[DS1094]\n\n나는 계속 심장을 지켜야\n하니까 이 열쇠조각을\n가지고 대장으로 가줘.";
        dialogue[16] = "-퀘스트-\n\n포탈을 통해\n혈관으로 이동하세요.";
        dialogue[17] = "[DS8561]\n\n거기 누구야!";
        dialogue[18] = "[DS8561]\n\n뭐야 다른 구역에서\n교대온건가?";
        dialogue[19] = "[DS8561]\n\n잘 지키고 있으라구";
        dialogue[20] = "[DS8561]\n\n여기마저 뺏기면\n우린 끝이야.";
        dialogue[21] = "-퀘스트-\n\n포탈을 통해 대장\n내부로 진입하세요.";
        dialogue[22] = "[DS3249]\n\n이 나쁜 놈들\n나를 가두다니!";
        dialogue[23] = "[DS3249]\n\n구해주세요!";
        dialogue[24] = "-퀘스트-\n\n갇혀 있는 동료\n나노로봇을 구하세요.";
        dialogue[25] = "[DS3249]\n\n감사합니다. 아직\n멀쩡한 분이 계시다니..";
        dialogue[26] = "[DS3249]\n\n갑자기 동료들이\n이렇게 되다니..";
        dialogue[27] = "[DS3249]\n\n혹시 바쁘시지 않다면 \n저 좀 도와주시겠습니까?";
        dialogue[28] = "[DS3249]\n\n일단 벽에 붙어 있는\n종양들을 제거해주세요.";
        dialogue[29] = "[DS3249]\n\n그냥 물건 잡듯이\n잡고 떼시면 됩니다.";
        dialogue[30] = "-퀘스트-\n\n동료를 도와\n대장을 치료하세요!";
        dialogue[31] = "[DS3249]\n\n전 잠시 할일이 있으니\n종양검사를 진행해주세요.";
        dialogue[32] = "[DS3249]\n\n그리 어렵지 않을겁니다.";
        dialogue[33] = "-퀘스트-\n\n조직검사를 진행하세요.";
        dialogue[34] = "[DS3249]\n\n이런..악성종양에 놈들이\n저 인형을 연결했나보군요.";
        dialogue[35] = "[DS3249]\n\n아직 시간이 더 필요한데...";
        dialogue[36] = "[DS3249]\n\n부탁드립니다...";
        dialogue[37] = "-퀘스트-\n\n악성종양에 연결된\n인형 타겟에 물풍선을\n던져 제거하세요!";
        dialogue[38] = "[DS3249]\n\n아까 보니 이 열쇠 조각이\n필요하실 것 같아서";
        dialogue[39] = "[DS3249]\n\n치료하시는\n동안 고쳤습니다.";
        dialogue[40] = "[DS3249]\n\n가져가서 동료들을\n구해주세요.";


    }
    private void Start()
    {
        // Debug.Log("dialogue.length = " + dialogue.Length);
        ShowDialogue(0);

    }

    public void ShowDialogue(int count_)
    {
        count = count_;
        NextDialogue();
    }


    public void NextDialogue()
    {
        txt_Dialogue.text = dialogue[count];
        count++;
        nextdialogok = false;
    }

    void Update()
    {
        if (decoManager != null)
        {
            decodia1 = decoManager.GetDecodia1();
            decodia2 = decoManager.GetDecodia2();
        }
        if(preHeartManager != null)
        {
            preheartdia = preHeartManager.GetPreHeartdia();
        }
        if (preColonManager != null)
        {
            colon1dia = preColonManager.GetColon1dia();
        }
        if (colonManager != null)
        {
            colon2dia1 = colonManager.GetColon2dia1();
            colon2dia2 = colonManager.GetColon2dia2();
            colon2dia3 = colonManager.GetColon2dia3();
            colon2dia4 = colonManager.GetColon2dia4();
            colon2dia5 = colonManager.GetColon2dia5();
        }
        if (decodia1)
        {
            DecoDialog1();
        }
        if (decodia2)
        {
            if (count < 7)
            {
                count = 7;
            }
            if (count == 7)
            {
                NextDialogue();
            }
            DecoDialog2();
        }
        if (preheartdia)
        {

            if (count < 11)
            {
                count = 11;
            }
            if (count == 11)
            {
                NextDialogue();
            }
            HeartDialog();
        }
        if (colon1dia)
        {
            if (count < 17)
            {
                count = 17;
            }
            if (count == 17)
            {
                NextDialogue();
            }
            Colon1Dialog();
        }
        if (colon2dia1)
        {
            if (count < 22)
            {
                count = 22;
            }
            if (count == 22)
            {
                NextDialogue();
            }
            Colon2Dialog1();
        }
        if (colon2dia2)
        {
            if (count < 25)
            {
                count = 25;
            }
            if (count == 25)
            {
                NextDialogue();
            }
            Colon2Dialog2();
        }
        if (colon2dia3)
        {
            if (count < 31)
            {
                count = 31;
            }
            if (count == 31)
            {
                NextDialogue();
            }
            Colon2Dialog3();
        }
        if (colon2dia4)
        {
            if (count < 34)
            {
                count = 34;
            }
            if (count == 34)
            {
                NextDialogue();
            }
            Colon2Dialog4();
        }
        if (colon2dia5)
        {
            if (count < 38)
            {
                count = 38;
            }
            if (count == 38)
            {
                NextDialogue();
            }
            Colon2Dialog5();
        }
        //portal 뜨게 만듦
        if (count == 11)
        {
            if (!decoPortalOnce)
            {
                decoManager.DecoEnd();
                decoPortalOnce = true;
            }
            
        }
        if (count == 17)
        {
            if (!preHeartPortalOnce)
            {
                preHeartManager.PreHeartEnd();
                preHeartPortalOnce = true;
            }
            
        }
        if (count == 22)
        {
            if (!preColonPortalOnce)
            {
                preColonManager.PreColonEnd();
                preColonPortalOnce = true;
            }
        }
        if (count == 41)
        {
            if (!colonPortalOnce)
            {
                colonManager.ColonEnd();
                colonPortalOnce = true;
            }
            
        }

        //colon 다음 stage로 넘어가기
        if (count == 31)
        {
            if (!once1)
            {
                colonManager.StartStage1();
                once1 = true;
            }
        }
        if (count == 34)
        {
            if (!once2)
            {
                colonManager.PreStartStage2();
                once2 = true;
            }
            
        }
        if (count == 38)
        {
            if(!once3)
            {
                colonManager.PreStartStage3();
                once3 = true;
            }
        }
    }

    public void DecoDialog1()
    {
        if (isDialogue && (count != 7))
        {
            if (nextdialogok)
            {
                if (count == 6)
                {
                    decoManager.nextBtn.SetActive(false);
                }
                if (count < 7)
                {
                    NextDialogue();
                }
            }
        }
    }

    public void DecoDialog2()
    {
        if (isDialogue && (count != 11))
        {
            if (nextdialogok)
            {
                if (count == 10)
                {
                    decoManager.nextBtn.SetActive(false);
                }
                if (count < 11)
                {
                    NextDialogue();
                }
            }
        }
    }

    public void HeartDialog()
    {
        if (isDialogue && (count != 17))
        {
            if (nextdialogok)
            {
                if (count == 16)
                {
                    preHeartManager.nextBtn.SetActive(false);
                }
                if (count < 17)
                {
                    NextDialogue();
                }
            }
        }
    }

    public void Colon1Dialog()
    {
        if (isDialogue && (count != 22))
        {
            if (nextdialogok)
            {
                if (count == 21)
                {
                    preColonManager.nextBtn.SetActive(false);
                }
                if (count < 22)
                {
                    NextDialogue();
                }
            }
        }
    }

    public void Colon2Dialog1()
    {
        if (isDialogue && (count != 25))
        {
            if (nextdialogok)
            {
                if (count == 24)
                {
                    colonManager.nextBtn1.SetActive(false);
                }
                if (count < 25)
                {
                    NextDialogue();
                }
            }
        }
    }

    public void Colon2Dialog2()
    {
        if (isDialogue && (count != 31))
        {
            if (nextdialogok)
            {
                if (count == 30)
                {
                    colonManager.nextBtn2.SetActive(false);
                }
                if (count < 31)
                {
                    NextDialogue();
                }
            }
        }
    }

    public void Colon2Dialog3()
    {
        if (isDialogue && (count != 34))
        {
            if (nextdialogok)
            {
                if (count == 33)
                {
                    colonManager.nextBtn3.SetActive(false);
                }
                if (count < 34)
                {
                    NextDialogue();
                }
            }
        }
    }

    public void Colon2Dialog4()
    {
        if (isDialogue && (count != 38))
        {
            if (nextdialogok)
            {
                if (count == 37)
                {
                    colonManager.nextBtn4.SetActive(false);
                }
                if (count < 38)
                {
                    NextDialogue();
                }
            }
        }
    }

    public void Colon2Dialog5()
    {
        if (isDialogue && (count != 41))
        {
            if (nextdialogok)
            {
                if (count == 40)
                {
                    colonManager.nextBtn5.SetActive(false);
                }
                if (count < 41)
                {
                    NextDialogue();
                }
            }
        }
    }

}