using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PreHeartDialog : MonoBehaviour
{
    [SerializeField] private PreHeartManager preHeartManager;
    [SerializeField] private TextMeshProUGUI txt_Dialogue;
    [SerializeField] private EffectAudioManager effectAudioManager;

    //대화가 얼마나 진행 되었는지 확인
    private int count = 0;
    static private string[] dialogue; //대화에 들어갈 배열

    public bool nextdialogok = false;

    private bool totalOpen = false;

    private void Awake()
    {
        dialogue = new string[6];
        dialogue[0] = "[DS1094]\n\n아니 심장이 다시\n뛰고 있잖아?";
        dialogue[1] = "[DS1094]\n\n당신이 고친거야?";
        dialogue[2] = "[DS1094]\n\n고쳐줘서 고마워.";
        dialogue[3] = "[DS1094]\n\n다른 놈들을 막는 사이에\n심장이 멈췄나봐.";
        dialogue[4] = "[DS1094]\n\n나는 계속 심장을 지켜야\n하니까 이 열쇠조각을\n가지고 대장으로 가줘.";
        dialogue[5] = "-퀘스트-\n\n포탈을 통해\n혈관으로 이동하세요.";
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
        if(nextdialogok)
        {
            if(count < 6)
            {
                NextDialogue();
            }
            if(count == 6)
            {
                if (!totalOpen)
                {
                    totalOpen = true;
                    preHeartManager.PreHeartEnd();
                }
            }
        }
    }
}
