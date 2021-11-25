using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DecoDialog : MonoBehaviour
{
    [SerializeField] private DecoManager decoManager;

    [SerializeField] private TextMeshProUGUI txt_Dialogue;

    [SerializeField] private EffectAudioManager effectAudioManager;

    //대화가 얼마나 진행 되었는지 확인
    private int count = 0;
    static private string[] dialogue; //대화에 들어갈 배열

    public bool nextdialogok = false;

    private bool questGiving = false;
    private bool firstMissionClear = false;
    private bool questGiving2 = false;

    private void Awake()
    {
        dialogue = new string[11];
        dialogue[0] = "[DS1057]\n\n거기 누구 없나요?";
        dialogue[1] = "[DS1057]\n\n반가워요. 저는 기지를 \n지키던 DS1057이에요.";
        dialogue[2] = "[DS1057]\n\n갑자기 다른 로봇들이\n들어오더니 기지를 부수고\n저를 망가뜨렸어요.";
        dialogue[3] = "[DS1057]\n\n혹시 당신도 나쁜 로봇은\n아니겠죠?";
        dialogue[4] = "[DS1057]\n\n지금 공격당해서\n팔이 망가졌어요.";
        dialogue[5] = "[DS1057]\n\n저기 있는 도구를 이용해서\n제 팔을 고쳐주세요.";
        dialogue[6] = "-퀘스트-\n\n DS1057의 팔을\n고쳐주세요.";
        dialogue[7] = "[DS1057]\n\n고마워요!";
        dialogue[8] = "[DS1057]\n\n아마 다른 장기들도\n점령당했을거에요.";
        dialogue[9] = "[DS1057]\n\n포탈을 통해 이동하여 \n상태가 급한 폐를\n고쳐주세요!";
        dialogue[10] = "-퀘스트-\n\n포탈을 통해 폐로\n이동하세요.";
    }

    void Start()
    {
        ShowDialogue(0);   
    }

    public void ShowDialogue(int count_)
    {
        count = count_;
        NextDialogue();
    }

    public void NextDialogue()
    {
        if (count != 0)
            effectAudioManager.DialogEffect();
        txt_Dialogue.text = dialogue[count];
        count++;
        nextdialogok = false;
    }

    public void AutoNextPage()
    {
        txt_Dialogue.text = dialogue[count];
        count++;
        nextdialogok = false;
    }

    public void DecoPart1()
    {
        if (count < 7)
        {
            NextDialogue();
        }

        if (count == 7)
        {
            if (!questGiving) //deco 퀘스트 주기 -> 팔 붙이기 미션
            {
                decoManager.EndStep0();
                questGiving = true;
            }
        }
    }

    public void DecoPart2()
    {
        if (count < 11)
        {
            NextDialogue();
        }
        if (count == 11)
        {
            if (!questGiving2)
            {
                decoManager.DecoEnd();
                questGiving2 = true;
            }
        }
    }

    void Update()
    {
        if (nextdialogok)
        {
            //part1
            if (decoManager.GetDecodia1() && !(decoManager.GetDecodia2()))
            {
                DecoPart1();
            }

            //part2
            if (decoManager.GetDecodia2())
            {
                DecoPart2();   
            }
        }

        //자동으로 한 번 넘어가기
        if(decoManager.GetDecodia2() && !(firstMissionClear))
        {
            AutoNextPage();
            firstMissionClear = true;
        }

        
    }
}
