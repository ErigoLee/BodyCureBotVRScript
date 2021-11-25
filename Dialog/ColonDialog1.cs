using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColonDialog1 : MonoBehaviour
{
    [SerializeField] private ColonManager colonManager;

    [SerializeField] private TextMeshProUGUI txt_Dialogue;

    [SerializeField] private EffectAudioManager effectAudioManager;

    //대화가 얼마나 진행 되었는지 확인
    private int count = 0;
    static private string[] dialogue; //대화에 들어갈 배열

    public bool nextdialogok = false;

    private bool getMission = false; 
    private void Awake()
    {
        dialogue = new string[3];
        dialogue[0] = "[DS3249]\n\n이 나쁜 놈들\n나를 가두다니!";
        dialogue[1] = "[DS3249]\n\n구해주세요!";
        dialogue[2] = "-퀘스트-\n\n앞에 있는 줄을 당겨\n갇혀 있는 동료\n나노로봇을 구하세요.";
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

    void Update()
    {
        if (nextdialogok)
        {
            if(count < 3)
            {
                NextDialogue();
            }
            if(count == 3)
            {
                if (!getMission) //looptrigger 생성하기
                {
                    colonManager.StartStage0_1();
                    getMission = true;
                }
            }
        }
    }
}
