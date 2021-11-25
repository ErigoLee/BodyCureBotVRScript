using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PreColonDialog : MonoBehaviour
{
    [SerializeField] private PreColonManager preColonManager;

    [SerializeField] private TextMeshProUGUI txt_Dialogue;

    [SerializeField] private EffectAudioManager effectAudioManager;

    //대화가 얼마나 진행 되었는지 확인
    private int count = 0;
    static private string[] dialogue; //대화에 들어갈 배열

    public bool nextdialogok = false;

    private bool dialogueEnd = false; //대화 종료여부 묻는 변수

    private void Awake()
    {
        dialogue = new string[5];
        dialogue[0] = "[DS8561]\n\n거기 누구야!";
        dialogue[1] = "[DS8561]\n\n뭐야 다른 구역에서\n교대온건가?";
        dialogue[2] = "[DS8561]\n\n잘 지키고 있으라구";
        dialogue[3] = "[DS8561]\n\n여기마저 뺏기면\n우린 끝이야.";
        dialogue[4] = "-퀘스트-\n\n포탈을 통해 대장\n내부로 진입하세요.";
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
            if (count < 5)
            {
                NextDialogue();
            }
            if(count == 5)
            {
                if (!dialogueEnd)
                {
                    preColonManager.PreColonEnd();
                    dialogueEnd = true;
                }
            }

        }
    }
}
